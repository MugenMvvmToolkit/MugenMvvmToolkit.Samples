using MugenMvvmToolkit.Android.AppCompat.Infrastructure;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class DrawerViewModel : ViewModelBase
    {
        #region Fields

        private bool _isLeftDrawerOpened;
        private bool _isRightDrawerOpened;

        #endregion

        #region Properties

        public bool IsLeftDrawerOpened
        {
            get { return _isLeftDrawerOpened; }
            set
            {
                if (_isLeftDrawerOpened == value)
                    return;
                _isLeftDrawerOpened = value;
                if (value)
                    IsRightDrawerOpened = false;
                OnPropertyChanged();
            }
        }

        public bool IsRightDrawerOpened
        {
            get { return _isRightDrawerOpened; }
            set
            {
                if (_isRightDrawerOpened == value)
                    return;
                _isRightDrawerOpened = value;
                if (value)
                    IsLeftDrawerOpened = false;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}