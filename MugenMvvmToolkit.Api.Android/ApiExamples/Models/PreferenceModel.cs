using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
    public class PreferenceModel : NotifyPropertyChangedBase
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private object _value;

        #endregion

        #region Constructors

        public PreferenceModel(string key, string title, bool isCheckbox, IToastPresenter toastPresenter)
        {
            Key = key;
            Title = title;
            _toastPresenter = toastPresenter;
            IsCheckbox = isCheckbox;
        }

        #endregion

        #region Properties

        public string Key { get; private set; }

        public string Title { get; private set; }

        public bool IsCheckbox { get; private set; }

        public object Value
        {
            get { return _value; }
            set
            {
                if (value == _value)
                    return;
                _toastPresenter.ShowAsync(string.Format("Value changed from '{0}' to '{1}'", _value, value), ToastDuration.Short);
                _value = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}