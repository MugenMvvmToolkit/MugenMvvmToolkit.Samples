using ApiExamples.Templates;
using ApiExamples.ViewModels;
using Foundation;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;

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
                bindingSet.Bind(section, AttachedMemberConstants.ItemsSource).To(() => model => model.Items);
                section.SetBindingMemberValue(AttachedMembers.Element.ItemTemplateSelector,
                    ButtonItemTemplateSelector.Instance);
                return root;
            }
        }

        #endregion
    }
}