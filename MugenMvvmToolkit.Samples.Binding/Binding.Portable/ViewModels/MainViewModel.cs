using System;
using System.Collections.Generic;
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

        private readonly IResourceMonitor _resourceMonitor;

        #endregion

        #region Constructors

        public MainViewModel(IResourceMonitor resourceMonitor)
        {
            Should.NotBeNull(resourceMonitor, "ResourceMonitor");
            _resourceMonitor = resourceMonitor;
            Items = new[]
            {
                Tuple.Create("GC.Collect", typeof (object)),
                Tuple.Create("Binding mode", typeof (BindingModeViewModel)),
                Tuple.Create("Relative binding", typeof (RelativeBindingViewModel)),
                Tuple.Create("Command binding", typeof (CommandBindingViewModel)),
                Tuple.Create("Validation binding", typeof (BindingValidationViewModel)),
                Tuple.Create("Binding to dynamic object", typeof (DynamicObjectViewModel)),
                Tuple.Create("Binding expressions", typeof (BindingExpressionViewModel)),
                Tuple.Create("Binding resources", typeof (BindingResourcesViewModel)),
                Tuple.Create("Attached members", typeof (AttachedMemberViewModel)),
                Tuple.Create("Localizable binding", typeof (LocalizableViewModel)),
                Tuple.Create("Collection binding", typeof (CollectionBindingViewModel)),
                Tuple.Create("Performance", typeof (PerformanceViewModel))
            };
            ShowCommand = new RelayCommand<Type>(Show);
            resourceMonitor.PropertyChanged += ReflectionExtensions.MakeWeakPropertyChangedHandler(this,
                (model, o, arg3) => model.OnPropertyChanged("ResourceUsageInfo"));
        }

        #endregion

        #region Properties

        public IResourceMonitor BindingMonitor
        {
            get { return _resourceMonitor; }
        }

        public IList<Tuple<string, Type>> Items { get; private set; }

        public string ResourceUsageInfo
        {
            get
            {
                return string.Format(
                    "Bindings/ViewModels/Views: total - {0}/{1}/{2}, live - {3}/{4}/{5}, collected - {6}/{7}/{8}.",
                    BindingMonitor.BindingCount, BindingMonitor.ViewModelCount, BindingMonitor.ViewCount,
                    BindingMonitor.LiveBindingCount, BindingMonitor.LiveViewModelCount, BindingMonitor.LiveViewCount,
                    BindingMonitor.CollectedBindingCount, BindingMonitor.CollectedViewModelCount,
                    BindingMonitor.CollectedViewCount);
            }
        }

        #endregion

        #region Commands

        public ICommand ShowCommand { get; private set; }

        private async void Show(Type type)
        {
            if (type == typeof (object))
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