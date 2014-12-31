using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IBindingManagerMonitor _bindingManagerMonitor;

        #endregion

        #region Constructors

        public MainViewModel(IBindingManagerMonitor bindingManagerMonitor)
        {
            Should.NotBeNull(bindingManagerMonitor, "bindingManagerMonitor");
            _bindingManagerMonitor = bindingManagerMonitor;
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
                Tuple.Create("Performance", typeof (PerformanceViewModel)),
                Tuple.Create("GC.Collect", typeof (object))
            };
            ShowCommand = new RelayCommand<Type>(Show);
        }

        #endregion

        #region Properties

        public IBindingManagerMonitor BindingMonitor
        {
            get { return _bindingManagerMonitor; }
        }

        public IList<Tuple<string, Type>> Items { get; private set; }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; private set; }

        private async void Show(Type type)
        {
            if (type == typeof(object))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                return;
            }
            using (IViewModel viewModel = GetViewModel(type))
                await viewModel.ShowAsync();
        }

        #endregion
    }
}