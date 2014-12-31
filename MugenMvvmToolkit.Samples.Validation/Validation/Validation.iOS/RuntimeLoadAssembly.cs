//NOTE This file uses to force load MugenMvvmToolkit.Xamarin.Forms.iOS.dll.

using System.Reflection;
using MugenMvvmToolkit;

namespace Validation.iOS
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