using Binding.Portable.ViewModels;
using Binding.Touch.Templates;
using Foundation;
using MonoTouch.Dialog;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;

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
            using (var bindingSet = new BindingSet<MainViewModel>())
            {
                var root = new RootElement("Main view");
                var section = new Section();
                var element = new MultilineElement(string.Empty);
                bindingSet.Bind(element, () => e => e.Caption)
                    .To(() => (vm, ctx) => vm.ResourceUsageInfo);
                section.Add(element);
                root.Add(section);

                section = new Section("Samples");
                root.Add(section);
                bindingSet.Bind(section, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.Items);
                section.SetBindingMemberValue(AttachedMembers.Element.ItemTemplateSelector, ButtonItemTemplate.Instance);
                return root;
            }
        }

        #endregion
    }
}