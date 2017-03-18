using System.Net;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Widget;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;

namespace Binding.Android
{
    public class Module : IModule
    {
        #region Properties

        public int Priority => ApplicationSettings.ModulePriorityDefault;

        #endregion

        #region Methods

        private static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }

            return imageBitmap;
        }

        private static void OnImageUrlChanged(ImageView imageView, AttachedMemberChangedEventArgs<string> args)
        {
            if (string.IsNullOrEmpty(args.NewValue))
                return;
            //for example you can use any cache library to load image
            var urlSt = args.NewValue;
            var weakRef = ServiceProvider.WeakReferenceFactory(imageView);
            Task.Run(() => GetImageBitmapFromUrl(urlSt)).ContinueWith(task =>
            {
                var view = (ImageView) weakRef.Target;
                view?.SetImageBitmap(task.Result);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Implementation of interfaces

        public bool Load(IModuleContext context)
        {
            //Registering attached property
            var memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<ImageView, string>("ImageUrl", OnImageUrlChanged));

            return true;
        }

        public void Unload(IModuleContext context)
        {
        }

        #endregion
    }
}