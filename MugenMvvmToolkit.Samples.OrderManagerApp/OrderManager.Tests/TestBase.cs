using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Infrastructure.Callbacks;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using OrderManager.Portable;
using OrderManager.Portable.Interfaces;

namespace OrderManager.Tests
{
    public abstract class TestBase : UnitTestBase
    {
        #region Properties

        protected Mock<IMessagePresenter> MessagePresenterMock { get; private set; }

        protected Mock<IWrapperManager> WrapperManagerMock { get; private set; }

        protected Mock<IRepository> RepositoryMock { get; private set; }

        protected Mock<IViewModelPresenter> ViewModelPresenterMock { get; private set; }

        protected Mock<IToastPresenter> ToastPresenterMock { get; private set; }

        protected ISerializer Serializer { get; set; }

        #endregion

        #region Methods

        [TestInitialize]
        public void TestInitialized()
        {
            var presenters = new List<IDynamicViewModelPresenter>();
            RepositoryMock = new Mock<IRepository>();
            MessagePresenterMock = new Mock<IMessagePresenter>();
            WrapperManagerMock = new Mock<IWrapperManager>();
            ViewModelPresenterMock = new Mock<IViewModelPresenter>();
            ToastPresenterMock = new Mock<IToastPresenter>();
            ViewModelPresenterMock.Setup(presenter => presenter.DynamicPresenters)
                                  .Returns(() => presenters);
            Serializer = new Serializer(AppDomain.CurrentDomain.GetAssemblies());
            var container = new AutofacContainer();
            container.BindToConstant(RepositoryMock.Object);
            container.BindToConstant(MessagePresenterMock.Object);
            container.BindToConstant(WrapperManagerMock.Object);
            container.BindToConstant(ViewModelPresenterMock.Object);
            container.BindToConstant(ToastPresenterMock.Object);
            Initialize(container, new DefaultUnitTestModule(), new PortableModule());
            ApplicationSettings.CommandExecutionMode = CommandExecutionMode.None;
            OnTestInitialized();
        }

        protected virtual void OnTestInitialized()
        {
        }

        protected Mock<IEditorWrapperViewModel> SetupEditableWrapper(bool result,
            Action<IViewModel> wrapCallback = null)
        {
            var wrapper = new Mock<IEditorWrapperViewModel>();
            WrapperManagerMock
                .Setup(provider => provider.Wrap(It.IsAny<IViewModel>(), typeof(IEditorWrapperViewModel), It.IsAny<IDataContext>()))
                .Returns<IViewModel, Type, IDataContext>((vm, t, context) =>
                {
                    if (wrapCallback != null)
                        wrapCallback(vm);
                    return wrapper.Object;
                });
            var operation = new NavigationOperation();
            operation.SetResult(OperationResult.CreateResult(OperationType.PageNavigation, wrapper, result));
            ViewModelPresenterMock.Setup(presenter => presenter.ShowAsync(wrapper.Object, It.IsAny<IDataContext>()))
                                  .Returns(() => operation);
            return wrapper;
        }

        protected TState UpdateState<TState>(TState state)
            where TState : IDataContext
        {
            var stream = Serializer.Serialize(state);
            stream.Position = 0;
            return (TState)Serializer.Deserialize(stream);
        }

        #endregion
    }
}