using MugenMvvmToolkit.Models;

namespace Navigation.Portable
{
    public static class Constants
    {
        public static readonly DataConstant<bool> WindowPreferably = DataConstant.Create(() => WindowPreferably);

        public static readonly DataConstant<bool> PagePreferably = DataConstant.Create(() => PagePreferably);
    }
}