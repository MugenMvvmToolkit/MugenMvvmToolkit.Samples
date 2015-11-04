using Android.Support.V4.Widget;
using Android.Widget;

namespace SplitView.Android
{
    public class LinkerInclude
    {
        #region Constructors

        public LinkerInclude()
        {
            new DrawerLayout(null, null);

            var l = new ListView(null, null);
            l.ItemClick += (sender, args) => { args.View.ToString(); };
            l.ItemClick -= (sender, args) => { };
        }

        #endregion
    }
}