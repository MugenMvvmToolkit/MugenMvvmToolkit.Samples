using System.ComponentModel;
using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Interfaces.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms.Views
{
    public partial class OpenedViewModelsView : Form, IViewModelAwareView<OpenedViewModelsViewModel>
    {
        #region Constructors

        public OpenedViewModelsView()
        {
            InitializeComponent();
            using (var set = new BindingSet())
            {
                listBox.DisplayMember = "Name";
                set.Bind(listBox, nameof(listBox.DataSource)).To(nameof(OpenedViewModelsViewModel.OpenedViewModels));
            }
            listBox.ContextMenuStrip = new ContextMenuStrip();
            listBox.ContextMenuStrip.Opening += ContextMenuOnOpening;
            listBox.MouseDown += ListBoxOnMouseDown;
        }

        #endregion

        #region Properties

        public OpenedViewModelsViewModel ViewModel { get; set; }

        #endregion

        #region Methods

        private void ListBoxOnMouseDown(object sender, MouseEventArgs e)
        {
            //select the item under the mouse pointer
            if (e.Button == MouseButtons.Right)
            {
                listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
                if (listBox.SelectedIndex != -1)
                    listBox.ContextMenuStrip.Show();
            }
        }

        private void ContextMenuOnOpening(object sender, CancelEventArgs cancelEventArgs)
        {
            var menuStrip = (ContextMenuStrip)sender;
            var listBoxSelectedItem = listBox.SelectedItem;
            var items = ViewModel.GetMenuItems((OpenedViewModelsViewModel.OpenedViewModelInfo)listBoxSelectedItem);
            menuStrip.Items.Clear();
            if (items == null)
                cancelEventArgs.Cancel = true;
            else
            {
                foreach (var item in items)
                {
                    var toolStripItem = menuStrip.Items.Add(item.Name);
                    toolStripItem.Click += (o, args) => item.Command.Execute(item.CommandParameter);
                }
            }
        }

        #endregion
    }
}