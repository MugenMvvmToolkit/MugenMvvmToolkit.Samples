using Android.Widget;

namespace ApiExamples
{
    public class LinkerInclude
    {
        private static void Include()
        {
            var scrollView = new ScrollView(null);

            var l = new ListView(null);
            l.ItemLongClick += (sender, args) => { args.View.ToString(); };
            l.ItemLongClick -= (sender, args) => { };
        }
    }
}