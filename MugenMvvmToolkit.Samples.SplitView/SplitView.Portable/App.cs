using System;
using System.Collections.Generic;
using System.Reflection;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using SplitView.Portable.Presenters;
using SplitView.Portable.ViewModels;

namespace SplitView.Portable
{
    public class App : MvvmApplication
    {
        #region Methods

        public override Type GetStartViewModelType()
        {
            return typeof(MainViewModel);
        }

        protected override void OnInitialize(IList<Assembly> assemblies)
        {
#if DEBUG
            Tracer.TraceInformation = true;
            Tracer.TraceWarning = true;
#endif
            base.OnInitialize(assemblies);
            IocContainer.Get<IViewModelPresenter>().DynamicPresenters.Add(IocContainer.Get<SplitViewViewModelPresenter>());
        }

        #endregion
    }
}