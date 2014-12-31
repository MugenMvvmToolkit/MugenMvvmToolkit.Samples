//NOTE This file uses to force load MugenMvvmToolkit.Xamarin.Forms.iOS.dll.

using System.Reflection;
using MugenMvvmToolkit;

namespace OrderManager.iOS
{
    internal static class RuntimeLoadAssembly
    {
        static RuntimeLoadAssembly()
        {
            // ReSharper disable once UnusedVariable
            Assembly assembly = typeof (PlatformExtensions).Assembly;
        }
    }
}