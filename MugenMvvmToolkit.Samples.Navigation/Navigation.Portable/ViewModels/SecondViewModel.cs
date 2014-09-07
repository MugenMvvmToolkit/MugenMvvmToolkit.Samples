using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class SecondViewModel : CloseableViewModel, INavigableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _displayName;

        #endregion

        #region Constructors

        public SecondViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            DisplayName = "Second view model";
        }

        #endregion

        #region Implementation of INavigableViewModel

        public void OnNavigatedTo(INavigationContext context)
        {
        }

        public Task<bool> OnNavigatingFrom(INavigationContext context)
        {
            return _messagePresenter
                .ShowAsync("Close SecondViewModel?", string.Empty, MessageButton.YesNo,
                    MessageImage.Question)
                .TryExecuteSynchronously(task => task.Result == MessageResult.Yes);
        }

        public void OnNavigatedFrom(INavigationContext context)
        {
        }

        #endregion

        #region Implementation of IHasDisplayName

        /// <summary>
        ///     Gets or sets the display name for the current model.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (Equals(value, _displayName))
                    return;
                _displayName = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}