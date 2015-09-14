using System;
using MugenMvvmToolkit;
using OrderManager.Portable.ViewModels;

namespace OrderManager.Portable
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