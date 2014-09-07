using Android.App;
using Android.OS;
using Android.Views;
#if API8
using Fragment = Android.Support.V4.App.Fragment;    
#endif

namespace ApiExamples.Views
{
    public class SimpleFragment2 : Fragment
    {
        #region Overrides of Fragment

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.SimpleView2, null);
        }

        #endregion
    }
}