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
                    .To(() => (vm, ctx) => vm.Property)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyLabel)
                    .To(() => (vm, ctx) => ctx.GetErrors(vm.Property).FirstOrDefault());

                set.Bind(propertyEx1Tb)
                    .To(() => (vm, ctx) => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnNotifyDataErrors();
                set.Bind(propertyExt1Label)
                    .To(() => (vm, ctx) => ctx.Element<TextBox>("propertyEx1Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());

                set.Bind(propertyEx2Tb)
                    .To(() => (vm, ctx) => vm.PropertyWithException)
                    .TwoWay()
                    .ValidatesOnExceptions();
                set.Bind(propertyExt2Label)
                    .To(() => (vm, ctx) => ctx.Element<TextBox>("propertyEx2Tb").Member<IEnumerable<object>>("Errors").FirstOrDefault());


                set.Bind(propertyEx3Tb)
                    .To(() => (vm, ctx) => vm.PropertyWithException)
                    .TwoWay()
                    .Validate(); //Validate is equivalent to ValidatesOnNotifyDataErrors and ValidatesOnExceptions
                set.Bind(propertyExt3Label)
                    .To(() => (vm, ctx) => ctx.GetErrors(vm.PropertyWithException).FirstOrDefault());

                set.Bind(addErrorButton).To(() => (vm, ctx) => vm.AddErrorCommand);
                set.Bind(clearErrorButton).To(() => (vm, ctx) => vm.RemoveErrorCommand);

                set.Bind(validationSumHeaderLabel, () => l => l.Visible)
                    .To(() => (vm, ctx) => ctx.GetErrors().Any());
                set.Bind(validationSumLabel)
                    .To(() => (vm, ctx) => string.Join(Environment.NewLine, ctx.GetErrors()));
            }
        }
    }
}