using System;
using System.Collections.Generic;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingResourcesViewModel : CloseableViewModel
    {
        #region Constructors

        public BindingResourcesViewModel()
        {
            IBindingResourceResolver resourceResolver = BindingServiceProvider.ResourceResolver;

            resourceResolver.AddObject("obj", "String value");
            resourceResolver.AddMethod("Method", new BindingResourceMethod(Method, typeof (object)));
            resourceResolver.AddType("CustomType", typeof (BindingResourcesViewModel));            
        }

        #endregion

        #region Methods

        private object Method(IList<Type> types, object[] arg3, IDataContext dataContext)
        {
            return "Custom method result";
        }

        public static string StaticMethod()
        {
            return "Result from StaticMethod";
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                BindingServiceProvider.ResourceResolver.RemoveMethod("Method");
            base.OnDispose(disposing);
        }

        #endregion
    }
}