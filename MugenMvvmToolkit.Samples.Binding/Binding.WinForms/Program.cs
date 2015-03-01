using System;
using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;

namespace Binding.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapper = new Bootstrapper<MainViewModel>(new AutofacContainer());
            bootstrapper.Start();
        }
    }
}