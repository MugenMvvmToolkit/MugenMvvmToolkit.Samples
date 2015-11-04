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
    [Register("TabTemplateViewController")]
    [ViewModel(typeof (TabViewModel), Constants.TabTemplateView)]
    public class TabTemplateViewController : MvvmTabBarController
    {
        #region Overrides of MvvmTabBarController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<TabViewModel>())
            {
                NavigationItem.RightBarButtonItems = new[]
                {
                    new UIBarButtonItem {Title = "Add"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (m, ctx) => m.AddCommand)),
                    new UIBarButtonItem {Title = "Insert"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (m, ctx) => m.InsertCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item).To(() => (m, ctx) => m.RemoveCommand))
                };

                this.SetBindingMemberValue(AttachedMembers.UITabBarController.ItemTemplateSelector,
                    TabTemplateSelector.Instance);
                set.Bind(this, AttachedMemberConstants.ItemsSource).To(() => (m, ctx) => m.ItemsSource);
                set.Bind(this, AttachedMemberConstants.SelectedItem).To(() => (m, ctx) => m.SelectedItem).TwoWay();
                set.Bind(this, () => c => c.Title)
                    .To(() => (m, ctx) => ((ItemViewModel) m.SelectedItem).Name + " " + ((ItemViewModel) m.SelectedItem).Id)
                    .WithFallback("Nothing selected");
            }
        }

        #endregion
    }
}