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
    [Register("CollectionViewController")]
    [ViewModel(typeof(TableViewModel), Constants.CollectionView)]
    public class CollectionViewController : MvvmCollectionViewController
    {
        #region Constructors

        public CollectionViewController()
            : base(new UICollectionViewFlowLayout())
        {
        }

        #endregion

        #region Overrides of MvvmCollectionViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            CollectionView.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<TableViewModel>())
            {
                NavigationItem.RightBarButtonItems = new[]
                {
                    new UIBarButtonItem {Title = "Add"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.AddCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.RemoveCommand))
                };

                set.BindFromExpression(CollectionView, "ItemTemplate $collectionViewCellTemplate");
                set.Bind(CollectionView, AttachedMemberConstants.ItemsSource)
                    .To(model => model.GridViewModel.ItemsSource);
                set.Bind(CollectionView, AttachedMemberConstants.SelectedItem)
                    .To(model => model.GridViewModel.SelectedItem)
                    .TwoWay();
                set.Bind(this, controller => controller.Title)
                    .To(model => model.GridViewModel.SelectedItem.Name)
                    .WithFallback("Nothing selected");
            }
        }

        #endregion
    }
}