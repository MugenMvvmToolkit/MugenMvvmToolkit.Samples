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
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (m, ctx) => m.AddCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (m, ctx) => m.RemoveCommand))
                };

                CollectionView.SetBindingMemberValue(AttachedMembers.UICollectionView.ItemTemplateSelector,
                    CollectionViewCellTemplateSelector.Instance);
                set.Bind(CollectionView, AttachedMemberConstants.ItemsSource)
                    .To(() => (m, ctx) => m.GridViewModel.ItemsSource);
                set.Bind(CollectionView, AttachedMemberConstants.SelectedItem)
                    .To(() => (m, ctx) => m.GridViewModel.SelectedItem)
                    .TwoWay();
                set.Bind(this, () => controller => controller.Title)
                    .To(() => (m, ctx) => m.GridViewModel.SelectedItem.Name)
                    .WithFallback("Nothing selected");
            }
        }

        #endregion
    }
}