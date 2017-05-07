using ApiExamples.Models;
using ApiExamples.Views;
using CoreGraphics;
using Foundation;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using UIKit;

namespace ApiExamples.Templates
{
    public class CollectionViewCellTemplateSelector :
        CollectionCellTemplateSelectorBase<TableItemModel, CollectionViewCell>
    {
        #region Fields

        public static readonly CollectionViewCellTemplateSelector Instance = new CollectionViewCellTemplateSelector();
        private static readonly NSString CellIdentifier = new NSString("CollectionCellId");

        #endregion

        #region Constructors

        private CollectionViewCellTemplateSelector()
        {
        }

        #endregion

        #region Overrides of CollectionCellTemplateSelectorBase<TableItemModel,CollectionViewCell>

        protected override void Initialize(UICollectionView container)
        {
            var layout = container.CollectionViewLayout as UICollectionViewFlowLayout;
            if (layout != null)
                layout.ItemSize = new CGSize(container.Frame.Width - 20, 30);
            container.RegisterClassForCell(typeof(CollectionViewCell), CellIdentifier);
        }

        protected override NSString GetIdentifier(TableItemModel item, UICollectionView container)
        {
            return CellIdentifier;
        }

        protected override void InitializeTemplate(UICollectionView container, CollectionViewCell cell,
            BindingSet<CollectionViewCell, TableItemModel> bindingSet)
        {
            bindingSet.Bind(cell.Label).To(() => (m, ctx) => $"Name {m.Name}, Selected: {m.IsSelected}");
            bindingSet.Bind(() => viewCell => viewCell.Selected).To(() => (m, ctx) => m.IsSelected).TwoWay();
        }

        #endregion
    }
}