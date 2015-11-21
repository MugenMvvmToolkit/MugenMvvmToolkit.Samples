using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;
using Binding.Portable.Models;
using MugenMvvmToolkit.Binding;

namespace Binding.UniversalApp.Views
{
    //NOTE to test performance run the app in release mode without debugger
    public sealed partial class PerformanceView : Page
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public PerformanceView()
        {
            InitializeComponent();

            _navigationHelper = new NavigationHelper(this);
            IterationsTb.Text = "100000";
        }

        #endregion

        #region Methods

        private void Click(object sender, RoutedEventArgs e)
        {
            int count = GetIterationsCount();
            MugenTb.Text = MugenBindingTest(count);
            MugenExpTb.Text = MugenBindingExpTest(count);
            NativeTb.Text = NativeBindingTest(count);
            NoBindingTb.Text = NoBindingTest(count);
        }

        private static string NativeBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            var binding = new Windows.UI.Xaml.Data.Binding
            {
                Source = model,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("Property"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(target, TestModel.ValueProperty, binding);

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
            target.ValueChanged += (sender, args) => model.Property = ((TestModel)sender).Value;

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";
            startNew.Stop();

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private int GetIterationsCount()
        {
            int count;
            if (int.TryParse(IterationsTb.Text, out count))
                return count;
            return 100000;
        }

        #endregion

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }

    public class TestModel : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(TestModel), new PropertyMetadata(null, OnValueChanged));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        //NOTE you can comment this event and model will be used the dependency property to observe value.
        public event EventHandler ValueChanged;

        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            EventHandler handler = ((TestModel)sender).ValueChanged;
            if (handler != null)
                handler(sender, EventArgs.Empty);
        }
    }
}