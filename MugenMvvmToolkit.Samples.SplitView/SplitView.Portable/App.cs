using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using SplitView.Portable.ViewModels;

namespace SplitView.Portable
{
    public class App : MvvmApplication
    {
        #region Fields

        //Use this value for iOS tablet
        private readonly bool _isSelectedItemViewModel;

        #endregion

        #region Constructors

        public App()
        {
        }

        public App(bool isSelectedItemViewModel)
        {
            _isSelectedItemViewModel = isSelectedItemViewModel;
        }

        #endregion

        #region Methods

        public override Type GetStartViewModelType()
        {
            //We use different implementations to match the navigation system adopted for the current platform.
            var platformType = Platform.Platform;
            if (platformType == PlatformType.Android || platformType.Id.Contains("XamarinForms"))
            {
                if (platformType == PlatformType.XamarinFormsWinRT || platformType == PlatformType.XamarinFormsiOS ||
                    platformType == PlatformType.XamarinFormsWinRTPhone)
                    return typeof(SelectedItemMainViewModel);
                return typeof(BackStackMainViewModel);
            }
            if (_isSelectedItemViewModel)
                return typeof(SelectedItemMainViewModel);
            return typeof(MainViewModel);
        }

        #endregion
    }
}