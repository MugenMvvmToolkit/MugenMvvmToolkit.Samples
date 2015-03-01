using ApiExamples.ViewModels;
using Foundation;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace ApiExamples.Views
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
            using (var bindingSet = new BindingSet<MainViewModel>())
            {
                var root = new RootElement("Main view");
                var section = new Section("Examples");
                root.Add(section);
                bindingSet.Bind(section, AttachedMemberConstants.ItemsSource).To(model => model.Items);
                bindingSet.BindFromExpression(section, "ItemTemplate $buttonTemplate");
                return root;
            }
        }

        #endregion
    }
}