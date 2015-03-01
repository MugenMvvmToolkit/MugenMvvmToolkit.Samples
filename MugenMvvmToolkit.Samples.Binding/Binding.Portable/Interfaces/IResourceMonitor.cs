using System.ComponentModel;
using MugenMvvmToolkit.Binding.Interfaces;

namespace Binding.Portable.Interfaces
{
    public interface IResourceMonitor : INotifyPropertyChanged, IBindingManager
    {
        int BindingCount { get; }

        int CollectedBindingCount { get; }

        int LiveBindingCount { get; }

        int ViewCount { get; }

        int CollectedViewCount { get; }

        int LiveViewCount { get; }

        int ViewModelCount { get; }

        int CollectedViewModelCount { get; }

        int LiveViewModelCount { get; }
    }
}