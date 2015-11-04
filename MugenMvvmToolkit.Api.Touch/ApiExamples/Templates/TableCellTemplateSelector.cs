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
                .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<TableViewModel>().ItemClickCommand)
                .OneTime()
                .WithCommandParameter(() => (m, ctx) => m)
                .ToggleEnabledState(false);
            bindingSet.Bind(AttachedMembers.UITableViewCell.DeleteClickEvent)
                .To(() => (m, ctx) => ctx.Relative<UIViewController>().DataContext<TableViewModel>().RemoveCommand)
                .OneTime()
                .WithCommandParameter(() => (m, ctx) => m)
                .ToggleEnabledState(false);

            bindingSet.Bind(() => viewCell => viewCell.Selected).To(() => (m, ctx) => m.IsSelected).TwoWay();
            bindingSet.Bind(() => viewCell => viewCell.Highlighted).To(() => (m, ctx) => m.IsHighlighted).OneWayToSource();
            bindingSet.Bind(() => viewCell => viewCell.Editing).To(() => (m, ctx) => m.Editing).OneWayToSource();
            bindingSet.Bind(AttachedMembers.UITableViewCell.TitleForDeleteConfirmation)
                      .To(() => (m, ctx) => "Delete " + m.Name);
            bindingSet.Bind(template.TextLabel).To(() => (m, ctx) => m.Name);
            bindingSet.Bind(template.DetailTextLabel)
                .To(() => (m, ctx) => string.Format("Selected: {0}, Highlighted: {1}, Editing: {2}", m.IsSelected, m.IsHighlighted, m.Editing));
        }

        #endregion
    }
}