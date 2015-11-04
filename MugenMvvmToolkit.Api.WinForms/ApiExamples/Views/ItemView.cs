using System.Windows.Forms;
using ApiExamples.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;

namespace ApiExamples.Views
{
    public partial class ItemView : UserControl
    {
        public ItemView()
        {
            InitializeComponent();
            AutoSize = true;
            using (var set = new BindingSet<ItemViewModel>())
            {
                set.Bind(label).To(() => (vm, ctx) => vm.Name + " " + vm.Id);
            }
        }
    }
}