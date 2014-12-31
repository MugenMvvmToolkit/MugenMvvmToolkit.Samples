using System;
using System.Linq;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace Binding.Android
{
    public class LinkerInclude
    {
        private static void Include()
        {
            var tuple = Tuple.Create<object, object>(null, null);
            var item1 = tuple.Item1;
            var item2 = tuple.Item2;
            var view = new View(null);
            view.Tag = view.Tag;
            "test".Count(c => c == 'a');
            var scrollView = new ScrollView(null);
            var seekBar = new SeekBar(null);
            seekBar.ProgressChanged += (sender, args) => { };
            seekBar.ProgressChanged -= (sender, args) => { };
            seekBar.Max = seekBar.Max;

            TextChangedEventArgs textChangedEvent = null;
            textChangedEvent.AfterCount.GetHashCode();
        }
    }
}