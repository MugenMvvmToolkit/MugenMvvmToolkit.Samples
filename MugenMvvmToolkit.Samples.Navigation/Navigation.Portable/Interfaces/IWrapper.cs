using MugenMvvmToolkit.Annotations;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Navigation.Portable.Interfaces
{
    //NOTE Wrapper anotation for reshaper plugin.
    [Wrapper]
    public interface IWrapper : IWrapperViewModel, IHasDisplayName
    {
    }
}