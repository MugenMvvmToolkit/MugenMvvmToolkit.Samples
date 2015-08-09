using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class BindingValidationView : Form
    {
        public BindingValidationView()
        {
            InitializeComponent();

            using (var set = new BindingSet<BindingValidationViewModel>())
            {
                set.Bind(propertyTb, () => box => box.Text)
                    .To(() => vm => vm.Property)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyLabel, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.GetErrors(vm.Property).FirstOrDefault());

                set.Bind(propertyEx1Tb, () => box => box.Text)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyExt1Label, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.Element<TextBox>("propertyEx1Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());

                set.Bind(propertyEx2Tb, () => box => box.Text)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnExceptions();
                set.Bind(propertyExt2Label, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.Element<TextBox>("propertyEx2Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());


                set.Bind(propertyEx3Tb, () => box => box.Text)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .Validate(); //Validate is equivalent to ValidatesOnNotifyDataErrors and ValidatesOnExceptions
                set.Bind(propertyExt3Label, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.GetErrors(vm.PropertyWithException).FirstOrDefault());

                set.Bind(addErrorButton, "Click").To(() => vm => vm.AddErrorCommand);
                set.Bind(clearErrorButton, "Click").To(() => vm => vm.RemoveErrorCommand);

                set.Bind(validationSumHeaderLabel, () => l => l.Visible)
                    .To(() => vm => BindingSyntaxEx.GetErrors().Any());
                set.Bind(validationSumLabel, () => l => l.Text)
                    .To(() => vm => string.Join(Environment.NewLine, BindingSyntaxEx.GetErrors()));
            }
        }
    }
}