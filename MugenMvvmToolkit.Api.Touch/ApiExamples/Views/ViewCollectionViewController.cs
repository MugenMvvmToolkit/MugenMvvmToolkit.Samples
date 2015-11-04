using ApiExamples.ContentManagers;
using ApiExamples.Templates;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("ViewCollectionViewController")]
    [ViewModel(typeof(TabViewModel), Constants.ViewCollectionView)]
    public class ViewCollectionViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<TabViewModel>())
            {
                NavigationItem.RightBarButtonItems = new[]
                {
                    new UIBarButtonItem {Title = "Add"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (vm, ctx) => vm.AddCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (vm, ctx) => vm.RemoveCommand))
                };

                set.Bind(View, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                View.SetBindingMemberValue(AttachedMembers.UIView.ItemTemplateSelector, LabelItemTemplateSelector.Instance);
                View.SetBindingMemberValue(AttachedMembers.UIView.CollectionViewManager, CollectionViewManager.Instance);
            }
        }

        #endregion
    }
}