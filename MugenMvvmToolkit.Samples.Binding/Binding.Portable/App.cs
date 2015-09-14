using System;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;

namespace Binding.Portable
{
    public class App : MvvmApplication
    {
        #region Methods

        public override Type GetStartViewModelType()
        {
            return typeof (MainViewModel);
        }

        #endregion
    }
}