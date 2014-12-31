using System.ComponentModel;
using MugenMvvmToolkit.Binding.Interfaces;

namespace Binding.Portable.Interfaces
{
    public interface IBindingManagerMonitor : INotifyPropertyChanged, IBindingManager
    {
        int BindingCount { get; }

        int CollectedBindingCount { get; }

        int LiveBindingCount { get; }
    }
}