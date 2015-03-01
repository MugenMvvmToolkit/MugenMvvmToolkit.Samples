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

        void INavigableViewModel.OnNavigatedTo(INavigationContext context)
        {
            this.TraceNavigation();
        }

        Task<bool> INavigableViewModel.OnNavigatingFrom(INavigationContext context)
        {
            this.TraceNavigation();
            return _messagePresenter
                .ShowAsync("Close SecondViewModel?", string.Empty, MessageButton.YesNo,
                    MessageImage.Question)
                .TryExecuteSynchronously(task => task.Result == MessageResult.Yes);
        }

        void INavigableViewModel.OnNavigatedFrom(INavigationContext context)
        {
            this.TraceNavigation();
        }

        #endregion

        #region Implementation of IHasDisplayName

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