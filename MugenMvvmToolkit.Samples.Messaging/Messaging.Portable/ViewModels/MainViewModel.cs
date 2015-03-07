using System.Windows.Input;
using Messaging.Portable.Messages;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Messaging.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel, IHandler<ViewModelMessage>
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Constructors

        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            OpenViewMessagingCommand = new RelayCommand(OpenViewMessaging);
            SendGlobalMessageCommand = new RelayCommand(SendGlobalMessage);

            //Using the global IEventAggregator
            _eventAggregator.Subscribe<AppGlobalMessage>(AppGlobalMessageHandler);
        }

        #endregion

        #region Commands

        public ICommand OpenViewMessagingCommand { get; private set; }

        public ICommand SendGlobalMessageCommand { get; private set; }

        private void SendGlobalMessage()
        {
            _eventAggregator.Publish(this, new GlobalMessage());
        }

        private async void OpenViewMessaging()
        {
            using (var vm = GetViewModel<ViewMessageViewModel>(ObservationMode.None))
                await vm.ShowAsync();
        }

        #endregion

        #region Properties

        public LeftViewModel LeftViewModel { get; private set; }

        public RightViewModel RightViewModel { get; private set; }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            //When you create a ViewModel you can specify ObservationMode, the default value is ParentObserveChild from static property ApplicationSettings.ViewModelObservationMode.
            //  ParentObserveChild - MainViewModel listens created ViewModel, equivalently to RightViewModel.Subscribe(this)
            //  ChildObserveParent - created ViewModel listens MainViewModel, equivalently to this.Subscribe(RightViewModel)           
            //  Both - ParentObserveChild and ChildObserveParent
            RightViewModel = GetViewModel<RightViewModel>(ObservationMode.Both);
            LeftViewModel = GetViewModel<LeftViewModel>();
        }

        #endregion

        #region Methods

        private void AppGlobalMessageHandler(object sender, AppGlobalMessage appGlobalMessage)
        {
            Extensions.TraceMessage(this, sender, appGlobalMessage);
        }

        #endregion

        #region Implementation of IHandler<in ViewModelMessage>

        public void Handle(object sender, ViewModelMessage message)
        {
            Extensions.TraceMessage(this, sender, message);

            if (!message.IsLeftViewModel)
                Publish(message);
        }

        #endregion
    }
}