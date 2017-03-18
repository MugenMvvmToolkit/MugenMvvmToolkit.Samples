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
                    new UIBarButtonItem {Title = "Add"},
                    new UIBarButtonItem {Title = "Insert"},
                    new UIBarButtonItem {Title = "Remove"}
                };
                set.Bind(NavigationItem.RightBarButtonItems[0]).To(() => (vm, ctx) => vm.AddCommand);
                set.Bind(NavigationItem.RightBarButtonItems[1]).To(() => (vm, ctx) => vm.InsertCommand);
                set.Bind(NavigationItem.RightBarButtonItems[2]).To(() => (vm, ctx) => vm.RemoveCommand);

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