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
                   .To(() => vm => vm.Cultures);
                set.Bind(cultureComboBox, AttachedMemberConstants.SelectedItem)
                   .To(() => vm => vm.SelectedCulture)
                   .TwoWay();
                set.Bind(addLabel, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName).Member<string>("AddText"));
                set.Bind(editLabel, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName).Member<string>("EditText"));
                set.Bind(delLabel, () => label => label.Text)
                    .To(() => vm => BindingSyntaxEx.Resource<object>(LocalizationManager.ResourceName).Member<string>("DeleteText"));
            }
        }
    }
}