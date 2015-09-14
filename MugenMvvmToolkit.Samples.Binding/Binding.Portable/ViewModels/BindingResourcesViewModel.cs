using System;
using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingResourcesViewModel : CloseableViewModel
    {
        #region Fields

        private readonly BindingResourceObject _objResource;

        #endregion

        #region Constructors

        public BindingResourcesViewModel()
        {
            var resourceResolver = BindingServiceProvider.ResourceResolver;
            _objResource = new BindingResourceObject("String value");
            resourceResolver.AddObject("obj", _objResource);
            resourceResolver.AddMethod("Method", new BindingResourceMethod(Method, typeof(object)));
            resourceResolver.AddType("CustomType", typeof(BindingResourcesViewModel));
            UpdateResourceCommand = new RelayCommand(UpdateResource);
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

        #region Overrides of ViewModelBase

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
                BindingServiceProvider.ResourceResolver.RemoveMethod("Method");
            base.OnDispose(disposing);
        }

        #endregion

        #endregion

        #region Commands

        public ICommand UpdateResourceCommand { get; private set; }

        private void UpdateResource()
        {
            _objResource.Value = Guid.NewGuid();
        }

        #endregion
    }
}