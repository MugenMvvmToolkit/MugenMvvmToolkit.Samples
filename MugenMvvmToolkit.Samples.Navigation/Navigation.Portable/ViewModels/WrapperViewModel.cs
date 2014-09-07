using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.ViewModels;
using Navigation.Portable.Interfaces;

namespace Navigation.Portable.ViewModels
{
    public class WrapperWindowViewModel : WrapperViewModelBase<IViewModel>, IWrapper
    {
    }

    public class WrapperPageViewModel : WrapperWindowViewModel
    {
    }
}