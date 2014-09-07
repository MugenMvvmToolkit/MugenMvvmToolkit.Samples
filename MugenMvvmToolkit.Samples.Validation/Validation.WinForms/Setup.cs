//NOTE you can replace standard Program.cs by this file;
using System;
using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Validation.Portable.ViewModels;

namespace Validation.WinForms
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