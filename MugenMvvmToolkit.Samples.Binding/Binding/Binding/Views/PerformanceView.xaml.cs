using System;
using System.Diagnostics;
using Binding.Portable.Models;
using MugenMvvmToolkit.Xamarin.Forms;
using MugenMvvmToolkit.Binding;
using Xamarin.Forms;

namespace Binding.Views
{
    //NOTE to test performance run the app in release mode without debugger
    public partial class PerformanceView : ContentPage
    {
        #region Constructors

        public PerformanceView()
        {
            InitializeComponent();
            IterationsTb.Text = "100000";
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion

        #region Methods

        private void Click(object sender, EventArgs args)
        {
            int count = GetIterationsCount();
            Collect();
            NativeTb.Text = NativeBindingTest(count);

            Collect();
            MugenTb.Text = MugenBindingTest(count);

            Collect();
            MugenExpTb.Text = MugenBindingExpTest(count);

            Collect();
            NoBindingTb.Text = NoBindingTest(count);
        }

        private static string NativeBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.BindingContext = model;
            var binding = new Xamarin.Forms.Binding("Property", BindingMode.TwoWay);
            target.SetBinding(TestModel.ValueProperty, binding);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private static string MugenBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.Bind(() => t => t.Value)
                .To(model, () => (vm, ctx) => vm.Property)
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

        private static string MugenBindingExpTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.Bind(() => m => m.Value)
                .To(model, () => (vm, ctx) => (vm.Property ?? string.Empty).Length + vm.Property)
                .Build();

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                model.Property = i % 2 == 0 ? "0" : "1";
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private static string NoBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Value")
                    model.Property = ((TestModel)sender).Value;
            };

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";
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
        }

        private int GetIterationsCount()
        {
            int count;
            if (int.TryParse(IterationsTb.Text, out count))
                return count;
            return 100000;
        }

        #endregion
    }

    public class TestModel : Element
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            "Value", typeof(string), typeof(TestModel), null, BindingMode.Default);

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
