using System;
using System.Diagnostics;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Binding.Portable.Models;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;
using MugenMvvmToolkit.Binding;

namespace Binding.Android.Views
{
    [Activity(Label = "Binding.Android")]
    public class PerformanceActivityView : MvvmAppCompatActivity
    {
        #region Constructors

        public PerformanceActivityView()
            : base(Resource.Layout.PerformanceView)
        {
        }

        #endregion

        #region Overrides of MvvmActivity

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var button = FindViewById<Button>(Resource.Id.StartButton);
            button.Click += Click;
        }

        #endregion

        #region Methods

        private void Click(object sender, EventArgs e)
        {
            int count = GetIterationsCount();

            Collect();
            FindViewById<TextView>(Resource.Id.MugenTextView).Text = MugenBindingTest(count);

            Collect();
            FindViewById<TextView>(Resource.Id.MugenExpTextView).Text = MugenBindingExpTest(count);

            Collect();
            FindViewById<TextView>(Resource.Id.NoBindingTextView).Text = NoBindingTest(count);
        }

        private string MugenBindingTest(int count)
        {
            var target = new TestModel(this);
            var model = new BindingPerformanceModel(target);
            target.Bind(() => t => t.Value)
                .To(model, () => (m, ctx) => m.Property)
                .TwoWay()
                .Build();

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private string MugenBindingExpTest(int count)
        {
            var target = new TestModel(this);
            var model = new BindingPerformanceModel(target);
            target.Bind(() => m => m.Value)
                .To(model, () => (pm, ctx) => (pm.Property ?? string.Empty).Length + pm.Property)
                .Build();

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                model.Property = i % 2 == 0 ? "0" : "1";
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private string NoBindingTest(int count)
        {
            var target = new TestModel(this);
            var model = new BindingPerformanceModel(target);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                string text = i % 2 == 0 ? "0" : "1";
                target.Value = text;
                model.Property = text;
            }
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private static void Collect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Thread.Sleep(100);
        }

        private int GetIterationsCount()
        {
            var editText = FindViewById<EditText>(Resource.Id.IterationsText);
            int count;
            if (int.TryParse(editText.Text, out count))
                return count;
            return 100000;
        }

        #endregion
    }

    public class TestModel : View
    {
        public TestModel(Context context)
            : base(context)
        {
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                var handler = ValueChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;
    }
}