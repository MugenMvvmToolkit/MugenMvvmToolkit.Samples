using System.Runtime.CompilerServices;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Navigation.Portable
{
    public static class Extensions
    {
        public static void TraceNavigation(this IViewModel viewModel, [CallerMemberName] string method = "")
        {
            Tracer.Warn(method + " " + viewModel.GetType().Name);
        }
    }
}