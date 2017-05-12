using System;
using System.Collections.Generic;
using System.Reflection;
using Binding.Portable;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.UWP;
using MugenMvvmToolkit.UWP.Binding.Infrastructure;
using MugenMvvmToolkit.UWP.Infrastructure;
using MugenMvvmToolkit.ViewModels;

namespace Binding
{
    public class DesignBootstrapper : UwpDesignBootstrapperBase
    {
        #region Properties

        private static DesignBootstrapper Instance
        {
            get
            {
                if (!ServiceProvider.IsDesignMode)
                    return null;
                var designBootstrapper = new DesignBootstrapper();
                designBootstrapper.Initialize();
                return designBootstrapper;
            }
        }

        public BindingModeViewModel BindingModeViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingModeViewModel>());

        public BindingExpressionViewModel BindingExpressionViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingExpressionViewModel>());

        public AttachedMemberViewModel AttachedMemberViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<AttachedMemberViewModel>());

        public BindingResourcesViewModel BindingResourcesViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingResourcesViewModel>());

        public BindingValidationViewModel BindingValidationViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingValidationViewModel>());

        public CollectionBindingViewModel CollectionBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<CollectionBindingViewModel>());

        public CommandBindingViewModel CommandBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<CommandBindingViewModel>());

        public DynamicObjectViewModel DynamicObjectViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<DynamicObjectViewModel>());

        public LocalizableViewModel LocalizableViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<LocalizableViewModel>());

        public MainViewModel MainViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<MainViewModel>());

        public RelativeBindingViewModel RelativeBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<RelativeBindingViewModel>());

        #endregion

        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new MugenContainer();
        }

        protected override void UpdateAssemblies(HashSet<Assembly> assemblies)
        {
            assemblies.Add(typeof(DesignBootstrapper).GetTypeInfo().Assembly);
            assemblies.Add(typeof(MainViewModel).GetTypeInfo().Assembly);
            assemblies.Add(typeof(ServiceProvider).GetTypeInfo().Assembly);
            assemblies.Add(typeof(BindingServiceProvider).GetTypeInfo().Assembly);
            assemblies.Add(typeof(UwpToolkitExtensions).GetTypeInfo().Assembly);
            assemblies.Add(typeof(UwpBindingContextManager).GetTypeInfo().Assembly);
        }

        #endregion
    }
}