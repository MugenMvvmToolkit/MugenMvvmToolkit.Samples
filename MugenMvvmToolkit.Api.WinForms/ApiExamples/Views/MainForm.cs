using System.Windows.Forms;
using ApiExamples.Templates;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.WinForms.Binding;

namespace ApiExamples.Views
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(tableLayoutPanel1, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.Items);
                tableLayoutPanel1.SetBindingMemberValue(AttachedMembers.Object.ItemTemplateSelector,
                    ButtonItemTemplate.Instance);
            }
        }

        #endregion
    }
}