using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingModeViewModel : CloseableViewModel
    {
        #region Fields

        private string _text = "Hello from view model";

        #endregion

        #region Properties

        public string Text
        {
            get { return _text; }
            set
            {
                if (Equals(_text, value))
                    return;
                _text = value;
                OnPropertyChanged();                
            }
        }

        #endregion
    }
}