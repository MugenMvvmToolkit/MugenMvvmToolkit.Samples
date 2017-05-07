using Binding.Portable.ViewModels;
using MugenMvvmToolkit.ViewModels;

namespace Binding
{
    partial class DesignBootstrapper
    {
        #region Properties

        public BindingModeViewModel BindingModeViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<BindingModeViewModel>());

        public BindingExpressionViewModel BindingExpressionViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<BindingExpressionViewModel>());

        public AttachedMemberViewModel AttachedMemberViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<AttachedMemberViewModel>());

        public BindingResourcesViewModel BindingResourcesViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<BindingResourcesViewModel>());

        public BindingValidationViewModel BindingValidationViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<BindingValidationViewModel>());

        public CollectionBindingViewModel CollectionBindingViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<CollectionBindingViewModel>());

        public CommandBindingViewModel CommandBindingViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<CommandBindingViewModel>());

        public DynamicObjectViewModel DynamicObjectViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<DynamicObjectViewModel>());

        public LocalizableViewModel LocalizableViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<LocalizableViewModel>());

        public MainViewModel MainViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<MainViewModel>());

        public RelativeBindingViewModel RelativeBindingViewModel => GetOrAddDesignViewModel(provider => provider.GetViewModel<RelativeBindingViewModel>());

        #endregion
    }
}