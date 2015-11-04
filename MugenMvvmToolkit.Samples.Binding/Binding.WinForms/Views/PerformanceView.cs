using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Binding.Portable.Models;
using MugenMvvmToolkit.Binding;

namespace Binding.WinForms.Views
{
    //NOTE to test performance run the app in release mode without debugger
    public partial class PerformanceView : Form
    {
        #region Constructors

        public PerformanceView()
        {
            InitializeComponent();
            IterationsTb.Text = "1000000";
        }

        #endregion

        #region Methods

        private void Button_Click(object sender, EventArgs e)
        {
            int count = GetIterationsCount();
            Collect();
            nativeLabel.Text = NativeBindingTest(count);

            Collect();
            mugenLabel.Text = MugenBindingTest(count);

            Collect();
            mugenExpLabel.Text = MugenBindingExpTest(count);

            Collect();
            noBindingLabel.Text = NoBindingTest(count);
        }

        private string NativeBindingTest(int count)
        {
            var target = new TestModel { Visible = true };
            var model = new BindingPerformanceModel(target);
            target.DataBindings.Add("Value", model, "Property", false, DataSourceUpdateMode.OnPropertyChanged);
            Controls.Add(target);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";

            startNew.Stop();
            Controls.Remove(target);

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private string MugenBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.Bind(() => t => t.Value)
                .To(model, () => (vm, ctx) => vm.Property)
                .TwoWay()
                .Build();
            Controls.Add(target);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                target.Value = i % 2 == 0 ? "0" : "1";
            startNew.Stop();
            Controls.Remove(target);

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private string MugenBindingExpTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            target.Bind(() => m => m.Value)
                .To(model, () => (vm, ctx) => (vm.Property ?? string.Empty).Length + vm.Property)
                .Build();
            Controls.Add(target);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                model.Property = i % 2 == 0 ? "0" : "1";
            startNew.Stop();
            Controls.Remove(target);

            if (model.SetCount != count)
                throw new Exception();
            return startNew.Elapsed.ToString();
        }

        private string NoBindingTest(int count)
        {
            var target = new TestModel();
            var model = new BindingPerformanceModel(target);
            Controls.Add(target);

            Stopwatch startNew = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                string text = i % 2 == 0 ? "0" : "1";
                target.Value = text;
                model.Property = text;
            }
            startNew.Stop();
            Controls.Remove(target);

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
            int count;
            if (int.TryParse(IterationsTb.Text, out count))
                return count;
            return 1000000;
        }

        #endregion
    }

    public class TestModel : Control
    {
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