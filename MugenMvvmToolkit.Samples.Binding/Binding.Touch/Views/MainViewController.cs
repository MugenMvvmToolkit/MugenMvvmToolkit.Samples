using Binding.Portable.ViewModels;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace Binding.Touch.Views
{
    [Register("MainViewController")]
    public class MainViewController : MvvmDialogViewController
    {
        #region Constructors

        public MainViewController()
            : base(CreateRootElement())
        {
        }

        #endregion

        #region Methods

        private static RootElement CreateRootElement()
        {
            var root = new RootElement("Main view");
            var section = new Section("Examples");
            root.Add(section);
            using (var bindingSet = new BindingSet<MainViewModel>())
            {
                bindingSet.Bind(section, AttachedMemberConstants.ItemsSource).To(model => model.Items);
                bindingSet.BindFromExpression(section, "ItemTemplate $buttonTemplate");
            }
            return root;
        }

        #endregion
    }
}