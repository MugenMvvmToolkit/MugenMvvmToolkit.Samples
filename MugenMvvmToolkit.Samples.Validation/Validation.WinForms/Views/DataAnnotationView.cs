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
                set.Bind(nameTextBox, () => t => t.Text)
                   .To(() => m => m.NameInVm)
                   .TwoWay()
                   .Validate();
                set.Bind(nameErrorLabel, () => t => t.Text)
                   .To(() => m => BindingSyntaxEx.GetErrors(m.NameInVm).FirstOrDefault());

                set.Bind(descriptionTextBox, () => t => t.Text)
                   .To(() => m => m.Description)
                   .TwoWay()
                   .Validate();
                set.Bind(descErrorLabel, () => t => t.Text)
                   .To(() => m => BindingSyntaxEx.GetErrors(m.Description).FirstOrDefault());

                set.Bind(customErrorTextBox, () => t => t.Text)
                   .To(() => m => m.CustomError)
                   .TwoWay();
                set.Bind(checkBox1, () => t => t.Checked)
                   .To(() => m => m.DisableDescriptionValidation)
                   .TwoWay();
                set.Bind(notValidLabel, () => t => t.Visible)
                   .To(() => m => !m.IsValid);
                set.Bind(validLabel, () => t => t.Visible)
                   .To(() => m => m.IsValid);
                set.Bind(summaryLabel, () => t => t.Text)
                   .To(() => m => string.Join(Environment.NewLine, BindingSyntaxEx.GetErrors()));
            }
        }
    }
}