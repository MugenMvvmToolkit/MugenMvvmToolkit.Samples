using System;
using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WinForms.Infrastructure;

namespace Navigation.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapper = new Bootstrapper<Portable.App>(new AutofacContainer());
            bootstrapper.Start();
        }
    }
}