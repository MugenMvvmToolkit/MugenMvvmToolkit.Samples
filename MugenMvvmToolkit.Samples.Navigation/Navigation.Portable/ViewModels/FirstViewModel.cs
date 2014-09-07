using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Navigation.Portable.ViewModels
{
    public class FirstViewModel : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _displayName;

        #endregion

        #region Constructors

        public FirstViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            DisplayName = "First view model";
        }

        #endregion

        #region Overrides of CloseableViewModel

        protected override Task<bool> OnClosing(object cmdParameter)
        {
            return _messagePresenter
                .ShowAsync("Close FirstViewModel?", string.Empty, MessageButton.YesNo, MessageImage.Question)
                .TryExecuteSynchronously(task => task.Result == MessageResult.Yes);
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