using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Binding.Portable.ViewModels
{
    public class MainViewModel : CloseableViewModel
    {
        #region Constructors

        public MainViewModel(IResourceMonitor resourceMonitor)
        {
            Should.NotBeNull(resourceMonitor, nameof(resourceMonitor));
            BindingMonitor = resourceMonitor;
            Items = new[]
            {
                Tuple.Create("GC.Collect", typeof(object)),
                Tuple.Create("Binding mode", typeof(BindingModeViewModel)),
                Tuple.Create("Relative binding", typeof(RelativeBindingViewModel)),
                Tuple.Create("Command binding", typeof(CommandBindingViewModel)),
                Tuple.Create("Validation binding", typeof(BindingValidationViewModel)),
                Tuple.Create("Binding to dynamic object", typeof(DynamicObjectViewModel)),
                Tuple.Create("Binding expressions", typeof(BindingExpressionViewModel)),
                Tuple.Create("Binding resources", typeof(BindingResourcesViewModel)),
                Tuple.Create("Attached members", typeof(AttachedMemberViewModel)),
                Tuple.Create("Localizable binding", typeof(LocalizableViewModel)),
                Tuple.Create("Collection binding", typeof(CollectionBindingViewModel)),
                Tuple.Create("Performance", typeof(PerformanceViewModel))
            };
            ShowCommand = new AsyncRelayCommand<Type>(ShowAsync, false);
            resourceMonitor.PropertyChanged += ReflectionExtensions.MakeWeakPropertyChangedHandler(this,
                (model, o, arg3) => model.OnPropertyChanged(() => vm => vm.ResourceUsageInfo));
        }

        #endregion

        #region Properties

        public IResourceMonitor BindingMonitor { get; }

        public IList<Tuple<string, Type>> Items { get; }

        public string ResourceUsageInfo =>
            $"Bindings/ViewModels/Views: total - {BindingMonitor.BindingCount}/{BindingMonitor.ViewModelCount}/{BindingMonitor.ViewCount}, live - {BindingMonitor.LiveBindingCount}/{BindingMonitor.LiveViewModelCount}/{BindingMonitor.LiveViewCount}, collected - {BindingMonitor.CollectedBindingCount}/{BindingMonitor.CollectedViewModelCount}/{BindingMonitor.CollectedViewCount}.";

        #endregion

        #region Commands

        public ICommand ShowCommand { get; }

        private async Task ShowAsync(Type type)
        {
            if (type == typeof(object))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                return;
            }
            using (var viewModel = GetViewModel(type))
            {
                await viewModel.ShowAsync();
            }
        }

        #endregion
    }
}