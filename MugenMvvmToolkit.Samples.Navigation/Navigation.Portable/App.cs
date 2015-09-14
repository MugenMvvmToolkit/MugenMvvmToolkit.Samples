using System;
using MugenMvvmToolkit;
using Navigation.Portable.ViewModels;

namespace Navigation.Portable
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