using ApiExamples.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;

namespace ApiExamples.Views
{
    [Register("TabViewController")]
    public class TabViewController : MvvmTabBarController
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
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.AddCommand)),
                    new UIBarButtonItem {Title = "Insert"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.InsertCommand)),
                    new UIBarButtonItem {Title = "Remove"}.SetBindings(set,
                        (bindingSet, item) => bindingSet.Bind(item, "Clicked").To(model => model.RemoveCommand))
                };

                set.Bind(this, AttachedMemberConstants.ItemsSource).To(model => model.ItemsSource);
                set.Bind(this, AttachedMemberConstants.SelectedItem).To(model => model.SelectedItem).TwoWay();
                set.Bind(this, controller => controller.Title).To("SelectedItem.Id");
            }
        }

        #endregion
    }
}