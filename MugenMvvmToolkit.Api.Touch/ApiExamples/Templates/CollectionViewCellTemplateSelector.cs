using System.Drawing;
using ApiExamples.Models;
using ApiExamples.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Infrastructure;

namespace ApiExamples.Templates
{
    public class CollectionViewCellTemplateSelector : CollectionCellTemplateSelectorBase<TableItemModel, CollectionViewCell>
    {
        #region Fields

        private static readonly NSString CellIdentifier = new NSString("CollectionCellId");

        #endregion

        #region Overrides of CollectionCellTemplateSelectorBase<TableItemModel,CollectionViewCell>

        protected override void Initialize(UICollectionView container)
        {
            var layout = container.CollectionViewLayout as UICollectionViewFlowLayout;
            if (layout != null)
                layout.ItemSize = new SizeF(container.Frame.Width - 20, 30);
            container.RegisterClassForCell(typeof(CollectionViewCell), CellIdentifier);
        }

        protected override NSString GetIdentifier(TableItemModel item, UICollectionView container)
        {
            return CellIdentifier;
        }

        protected override void InitializeTemplate(UICollectionView container, CollectionViewCell cell,
            BindingSet<CollectionViewCell, TableItemModel> bindingSet)
        {
            bindingSet.BindFromExpression(cell.Label,
                "Text $Format('Name {0}, Selected: {1}, Highlighted: {2}', Name, IsSelected, IsHighlighted)");
            bindingSet.Bind(viewCell => viewCell.Selected).To(model => model.IsSelected).TwoWay();
            bindingSet.Bind(viewCell => viewCell.Highlighted).To(model => model.IsHighlighted).TwoWay();
        }

        #endregion
    }
}