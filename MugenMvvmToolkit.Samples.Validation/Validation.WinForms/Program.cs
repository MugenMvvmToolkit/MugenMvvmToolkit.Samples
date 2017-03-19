using System;
using System.Windows.Forms;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.WinForms.Infrastructure;
using Validation.Portable;

namespace Validation.WinForms
{
    internal static class Program
    {
        #region Methods

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapper = new Bootstrapper<App>(new MugenContainer());
            bootstrapper.Start();
        }

        #endregion
    }
}