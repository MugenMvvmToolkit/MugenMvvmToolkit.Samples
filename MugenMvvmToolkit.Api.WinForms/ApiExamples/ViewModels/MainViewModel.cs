using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
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
                Tuple.Create("Tabs", new ViewModelCommandParameter(typeof(TabViewModel))),
                Tuple.Create("Tabs (ItemTemplate)", new ViewModelCommandParameter(typeof(TabViewModel), Constants.TabViewItemTeplate)),
                Tuple.Create("View collection manager", new ViewModelCommandParameter(typeof(TabViewModel), Constants.CollectionViewManager)),
                Tuple.Create("Content binding", new ViewModelCommandParameter(typeof(ContentViewModel))),
                Tuple.Create("Content binding (View content manager)", new ViewModelCommandParameter(typeof(ContentViewModel), Constants.ContentFormContentManager)),
                Tuple.Create("Tree view binding", new ViewModelCommandParameter(typeof(TreeViewBindingViewModel), Constants.ContentFormContentManager))
            };
            ShowCommand = RelayCommandBase.FromAsyncHandler<ViewModelCommandParameter>(Show);
        }

        #endregion

        #region Properties

        public IList<Tuple<string, ViewModelCommandParameter>> Items { get; }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; }

        private async Task Show(ViewModelCommandParameter parameter)
        {
            using (var viewModel = GetViewModel(parameter.ViewModelType))
            {
                await viewModel.ShowAsync(parameter.Context);
            }
        }

        #endregion
    }
}