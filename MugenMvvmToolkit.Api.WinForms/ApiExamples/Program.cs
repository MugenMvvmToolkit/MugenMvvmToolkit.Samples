using System;
using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WinForms.Infrastructure;

namespace ApiExamples
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