using System.Windows.Forms;
using Binding.Portable.Infrastructure;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class LocalizableView : Form
    {
        public LocalizableView()
        {
            InitializeComponent();

            using (var set = new BindingSet<LocalizableViewModel>())
            {
                set.Bind(cultureComboBox, AttachedMemberConstants.ItemsSource)
                   .To(() => (vm, ctx) => vm.Cultures);
                set.Bind(cultureComboBox, AttachedMemberConstants.SelectedItem)
                   .To(() => (vm, ctx) => vm.SelectedCulture)
                   .TwoWay();
                set.Bind(addLabel)
                    .To(() => (vm, ctx) => ctx.Resource<object>(LocalizationManager.ResourceName).Member("AddText"));
                set.Bind(editLabel)
                    .To(() => (vm, ctx) => ctx.Resource<object>(LocalizationManager.ResourceName).Member("EditText"));
                set.Bind(delLabel)
                    .To(() => (vm, ctx) => ctx.Resource<object>(LocalizationManager.ResourceName).Member("DeleteText"));
            }
        }
    }
}