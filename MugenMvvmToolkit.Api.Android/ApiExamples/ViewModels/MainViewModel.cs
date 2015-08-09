using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ApiExamples.Models;
using ApiExamples.ViewModels.Fragments;
using ApiExamples.ViewModels.Menus;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;
        private IList<Tuple<string, ViewModelCommandParameter>> _items;

        #endregion

        #region Constructors

        public MainViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, "toastPresenter");
            _toastPresenter = toastPresenter;
            Items = new[]
            {                
                Tuple.Create("Action bar (Dynamic tabs)", new ViewModelCommandParameter(typeof (TabViewModel))),
                Tuple.Create("Action bar (Static tabs)", new ViewModelCommandParameter(typeof (StaticTabViewModel))),                
                Tuple.Create("Context action bar", new ViewModelCommandParameter(typeof (ContextActionBarViewModel))),
                Tuple.Create("Tab host (Dynamic tabs)", new ViewModelCommandParameter(typeof (TabViewModel), Constants.TabHostView)),
                Tuple.Create("Action bar (Dynamic menu)", new ViewModelCommandParameter(typeof (MenuViewModel))),
                Tuple.Create("Toolbar view", new ViewModelCommandParameter(typeof (ToolbarViewModel))),
                Tuple.Create("Popup menu", new ViewModelCommandParameter(typeof (MenuViewModel), Constants.PopupMenuView)),
                Tuple.Create("Back stack fragment", new ViewModelCommandParameter(typeof (BackStackFragmetViewModel), Constants.PopupMenuView)),
                Tuple.Create("ItemsSource with DataTemplateSelector", new ViewModelCommandParameter(typeof (ListDataTemplateViewModel))),
                Tuple.Create("RecyclerView + CardView", new ViewModelCommandParameter(typeof (TabViewModel), Constants.CardRecyclerView)),
#if APPCOMPAT
                Tuple.Create("Tab layout (Design)", new ViewModelCommandParameter(typeof (TabViewModel), Constants.TabLayoutView)),
                Tuple.Create("View pager (AppCompat)", new ViewModelCommandParameter(typeof (TabViewModel), Constants.ViewPagerView)),
                Tuple.Create("Drawer layout (AppCompat)", new ViewModelCommandParameter(typeof (DrawerViewModel))),
                Tuple.Create("Navigation view (Design)", new ViewModelCommandParameter(typeof (NavigationViewModel)))
#endif
            };
            ShowCommand = RelayCommandBase.FromAsyncHandler<ViewModelCommandParameter>(Show);
        }

        #endregion

        #region Properties

        public IList<Tuple<string, ViewModelCommandParameter>> Items
        {
            get { return _items; }
            private set { _items = value; }
        }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; private set; }

        private async Task Show(ViewModelCommandParameter parameter)
        {
            using (IViewModel viewModel = GetViewModel(parameter.ViewModelType))
            {
                await viewModel.ShowAsync(parameter.Context);
                _toastPresenter.ShowAsync(viewModel.GetType().Name + " is closed", ToastDuration.Long);
            }
        }

        #endregion
    }
}