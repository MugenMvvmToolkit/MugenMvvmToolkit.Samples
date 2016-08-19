using Binding.Portable.ViewModels;
using MugenMvvmToolkit.ViewModels;

namespace Binding
{
    partial class DesignBootstrapper
    {
        #region Properties

        public BindingModeViewModel BindingModeViewModel => GetOrAddViewModel(provider => provider.GetViewModel<BindingModeViewModel>());

        public BindingExpressionViewModel BindingExpressionViewModel => GetOrAddViewModel(provider => provider.GetViewModel<BindingExpressionViewModel>());

        public AttachedMemberViewModel AttachedMemberViewModel => GetOrAddViewModel(provider => provider.GetViewModel<AttachedMemberViewModel>());

        public BindingResourcesViewModel BindingResourcesViewModel => GetOrAddViewModel(provider => provider.GetViewModel<BindingResourcesViewModel>());

        public BindingValidationViewModel BindingValidationViewModel => GetOrAddViewModel(provider => provider.GetViewModel<BindingValidationViewModel>());

        public CollectionBindingViewModel CollectionBindingViewModel => GetOrAddViewModel(provider => provider.GetViewModel<CollectionBindingViewModel>());

        public CommandBindingViewModel CommandBindingViewModel => GetOrAddViewModel(provider => provider.GetViewModel<CommandBindingViewModel>());

        public DynamicObjectViewModel DynamicObjectViewModel => GetOrAddViewModel(provider => provider.GetViewModel<DynamicObjectViewModel>());

        public LocalizableViewModel LocalizableViewModel => GetOrAddViewModel(provider => provider.GetViewModel<LocalizableViewModel>());

        public MainViewModel MainViewModel => GetOrAddViewModel(provider => provider.GetViewModel<MainViewModel>());

        public RelativeBindingViewModel RelativeBindingViewModel => GetOrAddViewModel(provider => provider.GetViewModel<RelativeBindingViewModel>());

        #endregion
    }
}