﻿using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class BindingExpressionViewModel : CloseableViewModel
    {
        #region Fields

        private string _text = IsDesignMode ? "Design text" : string.Empty;

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