using ApiExamples.Models;
using ApiExamples.ViewModels;
using ApiExamples.Views;
using Foundation;
using MugenMvvmToolkit.Binding.Extensions.Syntax;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace ApiExamples.Templates
{
    public class TableCellTemplateSelector : TableCellTemplateSelectorBase<TableItemModel, UITableViewCell>
    {
        #region Fields

        public static readonly TableCellTemplateSelector Instance = new TableCellTemplateSelector();

        private static readonly NSString EvenIdCellIdentifier = new NSString("even");
        private static readonly NSString OddIdCellIdentifier = new NSString("odd");

        #endregion

        #region Constructors

        private TableCellTemplateSelector()
        {
        }

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

            bindingSet.Bind(AttachedMembers.UITableViewCell.AccessoryButtonTappedEvent)
                .To(() => m => BindingSyntaxEx.Relative<UIViewController>().DataContext<TableViewModel>().ItemClickCommand)
                .OneTime()
                .WithCommandParameter(() => model => model)
                .ToggleEnabledState(false);
            bindingSet.Bind(AttachedMembers.UITableViewCell.DeleteClickEvent)
                .To(() => m => BindingSyntaxEx.Relative<UIViewController>().DataContext<TableViewModel>().RemoveCommand)
                .OneTime()
                .WithCommandParameter(() => model => model)
                .ToggleEnabledState(false);

            bindingSet.Bind(() => viewCell => viewCell.Selected).To(() => model => model.IsSelected).TwoWay();
            bindingSet.Bind(() => viewCell => viewCell.Highlighted).To(() => model => model.IsHighlighted).OneWayToSource();
            bindingSet.Bind(() => viewCell => viewCell.Editing).To(() => model => model.Editing).OneWayToSource();
            bindingSet.Bind(AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                      .To(() => m => "Delete " + m.Name);
            bindingSet.Bind(template.TextLabel).To(() => model => model.Name);
            bindingSet.Bind(template.DetailTextLabel)
                .To(() => m => string.Format("Selected: {0}, Highlighted: {1}, Editing: {2}", m.IsSelected, m.IsHighlighted, m.Editing));
        }

        #endregion
    }
}