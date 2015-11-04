using System;
using System.Linq;
using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using Validation.Portable.ViewModels;

namespace Validation.WinForms.Views
{
    public partial class DataAnnotationView : Form
    {
        public DataAnnotationView()
        {
            InitializeComponent();
            using (var set = new BindingSet<DataAnnotationViewModel>())
            {
                set.Bind(nameTextBox)
                   .To(() => (vm, ctx) => vm.NameInVm)
                   .TwoWay()
                   .Validate();
                set.Bind(nameErrorLabel)
                   .To(() => (vm, ctx) => ctx.GetErrors(vm.NameInVm).FirstOrDefault());

                set.Bind(descriptionTextBox)
                   .To(() => (vm, ctx) => vm.Description)
                   .TwoWay()
                   .Validate();
                set.Bind(descErrorLabel)
                   .To(() => (vm, ctx) => ctx.GetErrors(vm.Description).FirstOrDefault());

                set.Bind(customErrorTextBox)
                   .To(() => (vm, ctx) => vm.CustomError)
                   .TwoWay();
                set.Bind(checkBox1)
                   .To(() => (vm, ctx) => vm.DisableDescriptionValidation)
                   .TwoWay();
                set.Bind(notValidLabel, () => t => t.Visible)
                   .To(() => (vm, ctx) => !vm.IsValid);
                set.Bind(validLabel, () => t => t.Visible)
                   .To(() => (vm, ctx) => vm.IsValid);
                set.Bind(summaryLabel)
                   .To(() => (vm, ctx) => string.Join(Environment.NewLine, ctx.GetErrors()));
            }
        }
    }
}