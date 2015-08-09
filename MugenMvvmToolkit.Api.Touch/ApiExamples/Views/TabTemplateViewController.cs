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
    [ViewModel(typeof(TabViewModel), Constants.TabTemplateView)]
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
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(() => model => model.AddCommand)),
                    new UIBarButtonItem {Title = "Insert"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(() => model => model.InsertCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(() => model => model.RemoveCommand))
                };

                set.Bind(this, AttachedMemberConstants.ItemsSource).To(() => model => model.ItemsSource);
                set.Bind(this, AttachedMemberConstants.SelectedItem).To(() => model => model.SelectedItem).TwoWay();
                set.Bind(this, () => c => c.Title)
                    .To(() => m => ((ItemViewModel)m.SelectedItem).Name + " " + ((ItemViewModel)m.SelectedItem).Id)
                    .WithFallback("Nothing selected");
                this.SetBindingMemberValue(AttachedMembers.UITabBarController.ItemTemplateSelector, TabTemplateSelector.Instance);
            }
        }

        #endregion
    }
}