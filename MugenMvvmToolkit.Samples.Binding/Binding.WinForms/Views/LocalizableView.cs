using System.Windows.Forms;
using Binding.Portable.Infrastructure;
using Binding.Portable.Resources;
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
                   .To(() => vm => vm.Cultures);
                set.Bind(cultureComboBox, AttachedMemberConstants.SelectedItem)
                   .To(() => vm => vm.SelectedCulture)
                   .TwoWay();
                set.Bind(addLabel)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName, () => LocalizableResources.AddText));
                set.Bind(editLabel)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName, () => LocalizableResources.EditText));
                set.Bind(delLabel)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName, () => LocalizableResources.DeleteText));
            }
        }
    }
}