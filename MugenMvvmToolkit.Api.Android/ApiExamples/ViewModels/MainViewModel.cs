using System;
using System.Collections.Generic;
using System.Windows.Input;
using ApiExamples.Models;
using ApiExamples.ViewModels.Fragments;
using ApiExamples.ViewModels.Menus;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Constructors

        public MainViewModel()
        {
            Items = new[]
            {
                Tuple.Create("Action bar (Dynamic tabs)", new ViewModelCommandParameter(typeof (TabViewModel))),
                Tuple.Create("Action bar (Static tabs)", new ViewModelCommandParameter(typeof (StaticTabViewModel))),
                Tuple.Create("Context action bar", new ViewModelCommandParameter(typeof (ContextActionBarViewModel))),
#if !API8
                Tuple.Create("Tab host (Dynamic tabs)", new ViewModelCommandParameter(typeof (TabViewModel), Constants.TabHostView)),
#endif
                Tuple.Create("Action bar (Dynamic menu)", new ViewModelCommandParameter(typeof (MenuViewModel))),
                Tuple.Create("Popup menu", new ViewModelCommandParameter(typeof (MenuViewModel), Constants.PopupMenuView)),
                Tuple.Create("Back stack fragment", new ViewModelCommandParameter(typeof (BackStackFragmetViewModel), Constants.PopupMenuView)),
                Tuple.Create("ItemsSource with DataTemplateSelector", new ViewModelCommandParameter(typeof (ListDataTemplateViewModel))),
            };
            ShowCommand = new RelayCommand<ViewModelCommandParameter>(Show);
        }

        #endregion

        #region Properties

        public IList<Tuple<string, ViewModelCommandParameter>> Items { get; private set; }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; private set; }

        private async void Show(ViewModelCommandParameter parameter)
        {
            using (IViewModel viewModel = GetViewModel(parameter.ViewModelType))
                await viewModel.ShowAsync(parameter.Context);
        }

        #endregion
    }
}