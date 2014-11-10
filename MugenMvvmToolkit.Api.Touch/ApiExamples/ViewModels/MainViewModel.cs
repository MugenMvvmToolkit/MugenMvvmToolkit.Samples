using System;
using System.Collections.Generic;
using System.Windows.Input;
using ApiExamples.Models;
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

        #endregion

        #region Constructors

        public MainViewModel(IToastPresenter toastPresenter)
        {
            _toastPresenter = toastPresenter;
            Items = new[]
            {
                Tuple.Create("Tab bar view", new ViewModelCommandParameter(typeof (TabViewModel))),
                Tuple.Create("Tab bar view (DataTemplate)",
                    new ViewModelCommandParameter(typeof (TabViewModel), Constants.TabTemplateView)),
                Tuple.Create("Table view", new ViewModelCommandParameter(typeof (TableViewModel))),
                Tuple.Create("Table view (DataTemplate)",
                    new ViewModelCommandParameter(typeof (TableViewModel), Constants.TableTemplateView)),
                Tuple.Create("Table view (Checkmark)",
                    new ViewModelCommandParameter(typeof (TableViewModel), Constants.TableViewCheckmark)),
                Tuple.Create("Collection view",
                    new ViewModelCommandParameter(typeof (TableViewModel), Constants.CollectionView)),
                Tuple.Create("View ItemsSource binding",
                    new ViewModelCommandParameter(typeof (TabViewModel), Constants.ViewCollectionView)),
                Tuple.Create("View Content binding", new ViewModelCommandParameter(typeof (ContentViewModel))),
                Tuple.Create("Modal view", new ViewModelCommandParameter(typeof (ModalViewModel))),
                Tuple.Create("Modal view (navigation)",
                    new ViewModelCommandParameter(typeof (ModalViewModel), Constants.ModalNavSupportView))
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
            {
                await viewModel.ShowAsync(parameter.Context);
                _toastPresenter.ShowAsync(viewModel.GetType().Name + " is closed", ToastDuration.Long);
            }
        }

        #endregion
    }
}