using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using Xamarin.Forms;

namespace Binding
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Methods

        private static void OnImageUrlChanged(Image image, AttachedMemberChangedEventArgs<string> args)
        {
            if (string.IsNullOrEmpty(args.NewValue))
                return;
            //for example you can use any cache library to load image
            image.Source = ImageSource.FromUri(new Uri(args.NewValue));
        }

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<Image, string>("ImageUrl", OnImageUrlChanged));
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}