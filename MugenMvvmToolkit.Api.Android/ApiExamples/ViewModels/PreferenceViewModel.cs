using System.Collections.Generic;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class PreferenceViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private bool _checked;
        private string _text;
        private string _listValue;

        #endregion

        #region Constructors

        public PreferenceViewModel(IToastPresenter toastPresenter)
        {
            _toastPresenter = toastPresenter;
            Preferences = new[]
            {
                new PreferenceModel("1", "Dynamic edit text", false, toastPresenter) {Value = "default value"},
                new PreferenceModel("2", "Dynamic checkbox", true, toastPresenter)
            };
            Values = new[]
            {
                "Value 1",
                "Value 2"
            };
            Command = new RelayCommand(Execute, CanExecute, this);
        }

        #endregion

        #region Properties

        public IList<PreferenceModel> Preferences { get; private set; }

        public IList<string> Values { get; private set; }

        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value == _checked)
                    return;
                _toastPresenter.ShowAsync(string.Format("Checked property changed from {0} to {1}", _checked, value),
                    ToastDuration.Short);
                _checked = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (value == _text)
                    return;
                _toastPresenter.ShowAsync(string.Format("Text property changed from {0} to {1}", _text, value),
                    ToastDuration.Short);
                _text = value;
                OnPropertyChanged();
            }
        }

        public string ListValue
        {
            get { return _listValue; }
            set
            {
                if (_listValue == value)
                    return;
                _toastPresenter.ShowAsync(string.Format("ListValue property changed from {0} to {1}", _listValue, value),
                    ToastDuration.Short);
                _listValue = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand Command { get; private set; }

        private void Execute()
        {
            _toastPresenter.ShowAsync("Command invoked", ToastDuration.Short);
        }

        private bool CanExecute()
        {
            return Checked;
        }

        #endregion
    }
}