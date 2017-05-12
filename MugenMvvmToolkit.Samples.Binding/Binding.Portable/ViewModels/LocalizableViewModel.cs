using System.Collections.Generic;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class LocalizableViewModel : CloseableViewModel
    {
        #region Fields

        private readonly ILocalizationManager _localizationManager;
        private string _selectedCulture;

        #endregion

        #region Constructors

        public LocalizableViewModel(ILocalizationManager localizationManager)
        {
            Should.NotBeNull(localizationManager, nameof(localizationManager));
            _localizationManager = localizationManager;
            Cultures = new[] {"en-US", "ru-RU"};
            SelectedCulture = Cultures[0];
        }

        #endregion

        #region Properties

        public IList<string> Cultures { get; }

        public string SelectedCulture
        {
            get { return _selectedCulture; }
            set
            {
                if (Equals(value, _selectedCulture))
                    return;
                _selectedCulture = value;
                if (_selectedCulture != null)
                    _localizationManager.ChangeCulture(_selectedCulture);
                OnPropertyChanged();
            }
        }

        #endregion
    }
}