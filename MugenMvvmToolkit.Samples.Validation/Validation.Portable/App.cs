using System;
using MugenMvvmToolkit;
using Validation.Portable.ViewModels;

namespace Validation.Portable
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