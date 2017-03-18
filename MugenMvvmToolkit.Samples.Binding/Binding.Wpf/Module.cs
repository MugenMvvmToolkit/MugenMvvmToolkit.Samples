using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
#if NETFX_CORE
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Media.Imaging;
using System.Windows.Controls;
#endif

namespace Binding.Wpf
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<Image, string>("ImageUrl", OnImageUrlChanged));
            return true;
        }

        private static void OnImageUrlChanged(Image image, AttachedMemberChangedEventArgs<string> args)
        {
            if (string.IsNullOrEmpty(args.NewValue))
                return;
            //for example you can use any cache library to load image
#if NETFX_CORE
            image.Source = new BitmapImage(new Uri(args.NewValue));
#else
            image.Source = BitmapFrame.Create(new Uri(args.NewValue));
#endif
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}