using System;
using System.Diagnostics;
using System.Threading;
using Binding.Portable.Models;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace Binding.Touch.Views
{
    public class TestModel : NSObject
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                EventHandler handler = ValueChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;
    }

    [Register("PerformanceViewController")]
    public class PerformanceViewController : MvvmViewController
    {
        #region Fields

        private UITextField _iterationsTf;
        private UILabel _mugenExpLabel;
        private UILabel _mugenLabel;
        private UILabel _noBindingLabel;

        #endregion

        #region Constructors

        //compiled reflection
        /*static PerformanceViewController()
                {
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledMemberGetter(typeof(Binding.Portable.Models.BindingPerformanceModel), "Property", true, item => (System.Object)((Binding.Portable.Models.BindingPerformanceModel)item).Property);
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledDelegateFactory(typeof(MugenMvvmToolkit.Binding.Infrastructure.EventListenerList), "Raise", typeof(System.ComponentModel.PropertyChangedEventHandler), item => new System.ComponentModel.PropertyChangedEventHandler(((MugenMvvmToolkit.Binding.Infrastructure.EventListenerList)item).Raise), typeof(System.Object), typeof(System.ComponentModel.PropertyChangedEventArgs));
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledMethodDelegate(typeof(Binding.Portable.Models.BindingPerformanceModel), "add_PropertyChanged", (item, args) => { ((Binding.Portable.Models.BindingPerformanceModel)item).PropertyChanged += (System.ComponentModel.PropertyChangedEventHandler)args[0]; return null; }, typeof(System.ComponentModel.PropertyChangedEventHandler));
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledMethodDelegate(typeof(Binding.Touch.Views.TestModel), "add_ValueChanged", (item, args) => { ((Binding.Touch.Views.TestModel)item).ValueChanged += (System.EventHandler)args[0]; return null; }, typeof(System.EventHandler));
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledMemberSetter<System.Object>(typeof(Binding.Portable.Models.BindingPerformanceModel), "Property", true, (item, value) => ((Binding.Portable.Models.BindingPerformanceModel)item).Property = (System.String)value);
                    MugenMvvmToolkit.Infrastructure.ExpressionReflectionManager.AddCompiledMethodDelegate(typeof(System.Func<MugenMvvmToolkit.Interfaces.Models.IDataContext, System.String, System.String>), "Invoke", (item, args) => ((System.Func<MugenMvvmToolkit.Interfaces.Models.IDataContext, System.String, System.String>)item).Invoke((MugenMvvmToolkit.Interfaces.Models.IDataContext)args[0], (System.String)args[1]), typeof(MugenMvvmToolkit.Interfaces.Models.IDataContext), typeof(System.String));
                }*/

        #endregion


        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            var scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height))
            {
                ScrollEnabled = true,
                ContentSize = new CGSize(View.Bounds.Size.Width, View.Bounds.Size.Height),
                AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
            };
            View.AddSubview(scrollView);

            UIFont font = UIFont.SystemFontOfSize(10);

            var label = new UILabel(new CGRect(20, 0, View.Frame.Width - 40, 25))
            {
                Text = "Mugen binding",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = font
            };
            scrollView.AddSubview(label);

            label = new UILabel(new CGRect(20, 25, View.Frame.Width - 40, 25))
            {
                Text = "no results",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                TextColor = UIColor.Green,
                Font = font
            };
            scrollView.AddSubview(label);
            _mugenLabel = label;


            label = new UILabel(new CGRect(20, 50, View.Frame.Width - 40, 25))
            {
                Text = "Mugen binding ((Property ?? $string.Empty).Length + Property):",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = font
            };
            scrollView.AddSubview(label);

            label = new UILabel(new CGRect(20, 75, View.Frame.Width - 40, 25))
            {
                Text = "no results",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                TextColor = UIColor.Green,
                Font = font
            };
            scrollView.AddSubview(label);
            _mugenExpLabel = label;

            label = new UILabel(new CGRect(20, 100, View.Frame.Width - 40, 25))
            {
                Text = "No binding:",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Font = font
            };
            scrollView.AddSubview(label);

            label = new UILabel(new CGRect(20, 125, View.Frame.Width - 40, 25))
            {
                Text = "no results",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                TextColor = UIColor.Green,
                Font = font
            };
            scrollView.AddSubview(label);
            _noBindingLabel = label;

            _iterationsTf = new UITextField(new CGRect(20, 150, View.Frame.Width - 40, 30))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Text = "100000"
            };
            scrollView.AddSubview(_iterationsTf);


            UIButton button = UIButton.FromType(UIButtonType.System);
            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            button.Frame = new CGRect(20, 180, View.Frame.Width - 40, 30);
            button.SetTitle("Start", UIControlState.Normal);
            button.TouchUpInside += Button_Click;
            scrollView.AddSubview(button);
        }

        #endregion

        #region Methods

        private void Button_Click(object sender, EventArgs e)
        {
            int count = GetIterationsCount();
            Collect();
            _mugenLabel.Text = MugenBindingTest(count);

            Collect();
            _mugenExpLabel.Text = MugenBindingExpTest(count);

            Collect();
            _noBindingLabel.Text = NoBindingTest(count);
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
            if (int.TryParse(_iterationsTf.Text, out count))
                return count;
            return 100000;
        }

        #endregion
    }
}