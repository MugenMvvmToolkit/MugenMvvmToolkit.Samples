using System;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;

namespace Navigation.Portable.ViewModels
{
    public class BackgroundViewModel : NavigationViewModelBase
    {
        #region Fields

        private DateTime? _backgroundTime;
        private string _text;

        #endregion

        #region Constructors

        public BackgroundViewModel(IMessagePresenter messagePresenter) : base(messagePresenter)
        {
            Text = "Go to background and then back";
        }

        #endregion

        #region Properties

        public string Text
        {
            get { return _text; }
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        protected override void OnNavigatedFrom(INavigationContext context)
        {
            base.OnNavigatedFrom(context);
            if (context.NavigationMode == NavigationMode.Background)
                _backgroundTime = DateTime.Now;
        }

        protected override void OnNavigatedTo(INavigationContext context)
        {
            base.OnNavigatedTo(context);
            if (context.NavigationMode == NavigationMode.Foreground && _backgroundTime.HasValue)
                Text = "Background time " + (DateTime.Now - _backgroundTime);
        }

        #endregion
    }
}