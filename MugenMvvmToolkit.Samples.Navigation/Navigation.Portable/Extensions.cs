using System.Runtime.CompilerServices;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Navigation.Portable
{
    public static class Extensions
    {
        #region Methods

        public static void TraceNavigation(this IViewModel viewModel, INavigationContext ctx, [CallerMemberName] string method = "")
        {
            Tracer.Warn("Source {0}, method {1}, from {2} to {3} mode {4}", GetName(viewModel), method, GetName(ctx.ViewModelFrom), GetName(ctx.ViewModelTo),
                ctx.NavigationMode);
        }

        private static string GetName(IViewModel viewModel)
        {
            if (viewModel == null)
                return "(null)";
            return viewModel.GetType().Name;
        }

        #endregion
    }
}