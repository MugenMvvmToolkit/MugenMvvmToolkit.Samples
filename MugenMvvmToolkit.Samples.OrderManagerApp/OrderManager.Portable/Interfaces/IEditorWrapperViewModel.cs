using System.Windows.Input;
using MugenMvvmToolkit.Annotations;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace OrderManager.Portable.Interfaces
{
    //NOTE: attribute for resharper plugin
    [Wrapper]
    public interface IEditorWrapperViewModel : IWrapperViewModel, ICloseableViewModel, IHasDisplayName
    {
        ICommand ApplyCommand { get; set; }
    }
}