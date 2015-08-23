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
                set.Bind(propertyTb)
                    .To(() => vm => vm.Property)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyLabel)
                    .To(() => vm => BindingSyntaxEx.GetErrors(vm.Property).FirstOrDefault());

                set.Bind(propertyEx1Tb)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyExt1Label)
                    .To(() => vm => BindingSyntaxEx.Element<TextBox>("propertyEx1Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());

                set.Bind(propertyEx2Tb)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnExceptions();
                set.Bind(propertyExt2Label)
                    .To(() => vm => BindingSyntaxEx.Element<TextBox>("propertyEx2Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());


                set.Bind(propertyEx3Tb)
                    .To(() => vm => vm.PropertyWithException)
                    .TwoWay()
                    .Validate(); //Validate is equivalent to ValidatesOnNotifyDataErrors and ValidatesOnExceptions
                set.Bind(propertyExt3Label)
                    .To(() => vm => BindingSyntaxEx.GetErrors(vm.PropertyWithException).FirstOrDefault());

                set.Bind(addErrorButton).To(() => vm => vm.AddErrorCommand);
                set.Bind(clearErrorButton).To(() => vm => vm.RemoveErrorCommand);

                set.Bind(validationSumHeaderLabel, () => l => l.Visible)
                    .To(() => vm => BindingSyntaxEx.GetErrors().Any());
                set.Bind(validationSumLabel)
                    .To(() => vm => string.Join(Environment.NewLine, BindingSyntaxEx.GetErrors()));
            }
        }
    }
}