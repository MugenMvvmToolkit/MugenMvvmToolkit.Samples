using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
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
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.AddCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.RemoveCommand))
                };

                set.Bind(View, AttachedMemberConstants.ItemsSource).To(model => model.ItemsSource);
                set.BindFromExpression(View, "ItemTemplate $labelItemTemplate");
                set.BindFromExpression(View, "CollectionViewManager $collectionViewManager");
            }
        }

        #endregion
    }
}