using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.ViewModels;

namespace Binding
{
    partial class DesignBootstrapper
    {
        #region Properties

        private static DesignBootstrapper Instance
        {
            get
            {
                if (!ServiceProvider.IsDesignMode)
                    return null;
                var designBootstrapper = new DesignBootstrapper();
                designBootstrapper.Initialize();
                return designBootstrapper;
            }
        }

        public static BindingModeViewModel BindingModeViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingModeViewModel>());

        public static BindingExpressionViewModel BindingExpressionViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingExpressionViewModel>());

        public static AttachedMemberViewModel AttachedMemberViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<AttachedMemberViewModel>());

        public static BindingResourcesViewModel BindingResourcesViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingResourcesViewModel>());

        public static BindingValidationViewModel BindingValidationViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<BindingValidationViewModel>());

        public static CollectionBindingViewModel CollectionBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<CollectionBindingViewModel>());

        public static CommandBindingViewModel CommandBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<CommandBindingViewModel>());

        public static DynamicObjectViewModel DynamicObjectViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<DynamicObjectViewModel>());

        public static LocalizableViewModel LocalizableViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<LocalizableViewModel>());

        public static MainViewModel MainViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<MainViewModel>());

        public static RelativeBindingViewModel RelativeBindingViewModel => Instance.GetDesignViewModel(provider => provider.GetViewModel<RelativeBindingViewModel>());

        #endregion
    }
}