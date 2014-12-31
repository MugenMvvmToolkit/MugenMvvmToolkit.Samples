using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Validation;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using OrderManager.Portable.Infrastructure;
using OrderManager.Portable.Interfaces;
using OrderManager.Portable.Validators;

namespace OrderManager.Portable
{
    public class PortableModule : ModuleBase
    {
        #region Constructors

        public PortableModule()
            : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        protected override bool LoadInternal()
        {
            if (Mode == LoadMode.Design)
                IocContainer.Bind<IRepository, DesignRepository>(DependencyLifecycle.SingleInstance);

            IocContainer.BindToConstant<IViewModelSettings>(new DefaultViewModelSettings
            {
                DefaultBusyMessage = UiResources.DefaultBusyMessage
            });
            var validatorProvider = IocContainer.Get<IValidatorProvider>();
            validatorProvider.Register<OrderModelValidator>();
            validatorProvider.Register<ProductModelValidator>();
            return true;
        }

        protected override void UnloadInternal()
        {
            var validatorProvider = IocContainer.Get<IValidatorProvider>();
            validatorProvider.Unregister<OrderModelValidator>();
            validatorProvider.Unregister<ProductModelValidator>();
        }

        #endregion
    }
}