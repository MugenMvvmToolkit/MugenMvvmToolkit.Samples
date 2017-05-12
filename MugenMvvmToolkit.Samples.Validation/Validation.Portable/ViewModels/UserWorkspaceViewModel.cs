using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Validation.Portable.Interfaces;
using Validation.Portable.Models;
using Validation.Portable.Validators;

namespace Validation.Portable.ViewModels
{
    public class UserWorkspaceViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private readonly IUserRepository _userRepository;
        private GridViewModel<UserModel> _userGridViewModel;
        private UserEditorViewModel _userValidatableViewModel;

        #endregion

        #region Constructors

        public UserWorkspaceViewModel(IUserRepository userRepository, IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(userRepository, nameof(userRepository));
            Should.NotBeNull(messagePresenter, nameof(messagePresenter));
            _userRepository = userRepository;
            _messagePresenter = messagePresenter;

            AddUserCommand = new RelayCommand(AddUser, CanAddUser, this);
            RemoveUserCommand = RelayCommandBase.FromAsyncHandler(RemoveUser, CanRemoveUser, this);
        }

        #endregion

        #region Properties

        public UserEditorViewModel UserEditorViewModel
        {
            get { return _userValidatableViewModel; }
            private set
            {
                if (Equals(value, _userValidatableViewModel)) return;
                _userValidatableViewModel = value;
                OnPropertyChanged();
            }
        }

        public GridViewModel<UserModel> UserGridViewModel
        {
            get { return _userGridViewModel; }
            private set
            {
                if (Equals(value, _userGridViewModel)) return;
                _userGridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void AddUser()
        {
            UserEditorViewModel.ApplyChanges();
            var entity = UserEditorViewModel.Entity;
            UserGridViewModel.ItemsSource.Add(entity);
            UserGridViewModel.SelectedItem = entity;
            _userRepository.Add(entity);
            InitializeNewUser();
        }

        private bool CanAddUser()
        {
            return UserEditorViewModel.IsValid;
        }

        private async Task RemoveUser()
        {
            var selectedItem = UserGridViewModel.SelectedItem;
            if (await _messagePresenter.ShowAsync("Are you sure you want to remove the selected user?", string.Empty,
                    MessageButton.YesNo) != MessageResult.Yes)
                return;
            _userRepository.Remove(selectedItem);
            UserGridViewModel.ItemsSource.Remove(selectedItem);
            UserGridViewModel.SelectedItem = null;
            UserEditorViewModel.ValidateAsync();
        }

        private bool CanRemoveUser()
        {
            return UserGridViewModel.SelectedItem != null;
        }

        private void InitializeNewUser()
        {
            var userModel = new UserModel();
            UserEditorViewModel.InitializeEntity(userModel, true);
            //NOTE: to show how you can manually add validator
            UserEditorViewModel.AddValidator<UserEmailValidator>(userModel);
        }

        protected override void OnInitialized()
        {
            UserGridViewModel = GetViewModel<GridViewModel<UserModel>>();
            UserEditorViewModel = GetViewModel<UserEditorViewModel>();

            UserGridViewModel.UpdateItemsSource(_userRepository.GetUsers());
            InitializeNewUser();
        }

        #endregion

        #region Commands

        public ICommand AddUserCommand { get; }

        public ICommand RemoveUserCommand { get; }

        #endregion
    }
}