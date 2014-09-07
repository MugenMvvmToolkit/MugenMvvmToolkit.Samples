using System;
using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Constructors

        public MainViewModel()
        {
            Items = new[]
            {
                Tuple.Create("Binding mode", typeof (BindingModeViewModel)),
                Tuple.Create("Relative binding", typeof (RelativeBindingViewModel)),
                Tuple.Create("Command binding", typeof (CommandBindingViewModel)),
                Tuple.Create("Validation binding", typeof (BindingValidationViewModel)),
                Tuple.Create("Binding to dynamic object", typeof (DynamicObjectViewModel)),
                Tuple.Create("Binding expressions", typeof (BindingExpressionViewModel)),
                Tuple.Create("Binding resources", typeof (BindingResourcesViewModel)),
                Tuple.Create("Attached members", typeof (AttachedMemberViewModel)),
                Tuple.Create("Localizable binding", typeof (LocalizableViewModel)),
                Tuple.Create("Performance", typeof (PerformanceViewModel))
            };
            ShowCommand = new RelayCommand<Type>(Show);
        }

        #endregion

        #region Properties

        public IList<Tuple<string, Type>> Items { get; private set; }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; private set; }

        private async void Show(Type type)
        {
            using (IViewModel viewModel = GetViewModel(type))
                await viewModel.ShowAsync();
        }

        #endregion
    }
}