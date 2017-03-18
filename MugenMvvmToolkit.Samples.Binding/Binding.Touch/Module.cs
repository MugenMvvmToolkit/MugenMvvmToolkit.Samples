using System.Threading.Tasks;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using UIKit;

namespace Binding.Touch
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => int.MinValue;

        #endregion

        #region Methods

        private static void OnImageUrlChanged(UIImageView uiImageView, AttachedMemberChangedEventArgs<string> args)
        {
            if (string.IsNullOrEmpty(args.NewValue))
                return;
            //for example you can use any cache library to load image
            var urlSt = args.NewValue;
            var weakRef = ServiceProvider.WeakReferenceFactory(uiImageView);
            Task.Run(() =>
            {
                using (var url = new NSUrl(urlSt))
                using (var data = NSData.FromUrl(url))
                    return UIImage.LoadFromData(data);
            }).ContinueWith(task =>
            {
                var view = (UIImageView)weakRef.Target;
                if (view != null)
                    view.Image = task.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<UIImageView, string>("ImageUrl", OnImageUrlChanged));
            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}