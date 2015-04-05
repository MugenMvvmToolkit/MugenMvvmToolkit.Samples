using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingExpressionViewModel : CloseableViewModel
    {
        #region Fields

        private string _text = IsDesignMode ? "Design text" : string.Empty;

        #endregion

        #region Properties
        //TODO FIX
        public string Text
        {
            get { return _text; }
            set
            {
                if (Equals(_text, value))
                    return;
                _text = value;
                OnPropertyChanged();
                OnPropertyChanged(() => NullableText);
            }
        }

        public string NullableText
        {
            get { return string.IsNullOrEmpty(Text) ? null : Text; }
        }

        #endregion
    }
}