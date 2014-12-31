using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using OrderManager.Portable.ViewModels.Orders;

namespace OrderManager.Infrastructure
{
    public class WrapperManagerEx : WrapperManager
    {
        #region Fields

        public const string OrderViewName = "OrderViewName";

        #endregion

        #region Constructors

        public WrapperManagerEx(IViewModelProvider viewModelProvider)
            : base(viewModelProvider)
        {
        }

        #endregion

        #region Overrides of WrapperManager

        /// <summary>
        ///     Creates the wrapper view model.
        /// </summary>
        protected override object WrapInternal(object item, WrapperRegistration wrapperRegistration,
            IDataContext dataContext)
        {
            object result = base.WrapInternal(item, wrapperRegistration, dataContext);

            //Changing default wrapper view to TabbedPage.
            if (item is OrderEditorViewModel)
                ((IViewModel) result).Settings.Metadata.Add(NavigationConstants.ViewName, OrderViewName);
            return result;
        }

        #endregion
    }
}