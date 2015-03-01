using ApiExamples.Models;
using ApiExamples.Views;
using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.Views;
using UIKit;

namespace ApiExamples.Templates
{
    public class TableCellTemplateSelector : TableCellTemplateSelectorBase<TableItemModel, UITableViewCell>
    {
        #region Fields

        private static readonly NSString EvenIdCellIdentifier = new NSString("even");
        private static readonly NSString OddIdCellIdentifier = new NSString("odd");

        #endregion

        #region Overrides of TableCellTemplateSelectorBase<TableItemModel,UITableViewCell>

        protected override NSString GetIdentifier(TableItemModel item, UITableView container)
        {
            return item.Id % 2 == 0 ? EvenIdCellIdentifier : OddIdCellIdentifier;
        }

        protected override UITableViewCell SelectTemplate(UITableView container, NSString identifier)
        {
            if (identifier == EvenIdCellIdentifier)
                return new CustomViewCell(identifier);
            return new UITableViewCellBindable(UITableViewCellStyle.Subtitle, identifier);
        }

        protected override void Initialize(UITableViewCell template,
            BindingSet<UITableViewCell, TableItemModel> bindingSet)
        {
            template.SetEditingStyle(UITableViewCellEditingStyle.Delete);
            template.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
            template.DetailTextLabel.AdjustsFontSizeToFitWidth = true;

            bindingSet.BindFromExpression(template, "AccessoryButtonTapped $Rel(UIViewController).DataContext.ItemClickCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");
            bindingSet.BindFromExpression(template, "DeleteClick $Rel(UIViewController).DataContext.RemoveCommand, CommandParameter=$self.DataContext, ToggleEnabledState=false");

            bindingSet.Bind(viewCell => viewCell.Selected).To(model => model.IsSelected).TwoWay();
            bindingSet.Bind(viewCell => viewCell.Highlighted).To(model => model.IsHighlighted).OneWayToSource();
            bindingSet.Bind(viewCell => viewCell.Editing).To(model => model.Editing).OneWayToSource();
            bindingSet.BindFromExpression("TitleForDeleteConfirmation $Format('Delete {0}', Name)");

            bindingSet.Bind(label => label.TextLabel.Text).To(model => model.Name);
            bindingSet.BindFromExpression(template.DetailTextLabel,
                        "Text $Format('Selected: {0}, Highlighted: {1}, Editing: {2}', IsSelected, IsHighlighted, Editing)");
        }

        #endregion
    }
}