using System;
using Android.Widget;

namespace ApiExamples
{
    public class LinkerInclude
    {
        private static void Include()
        {
            var tuple = Tuple.Create<object, object>(null, null);
            var item1 = tuple.Item1;
            var item2 = tuple.Item2;

            var scrollView = new ScrollView(null);

            var l = new ListView(null);
            l.ItemLongClick += (sender, args) => { args.View.ToString(); };
            l.ItemLongClick -= (sender, args) => { };

            Toolbar toolbar = new Toolbar(null);
            toolbar.Menu.ToString();
            toolbar.Title = toolbar.Title;
        }
    }
}