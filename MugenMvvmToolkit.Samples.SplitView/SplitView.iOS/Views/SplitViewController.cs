using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Converters;
using MugenMvvmToolkit.iOS.Views;
using SplitView.Portable.ViewModels;
using UIKit;

namespace SplitView.iOS.Views
{
    [ViewModel(typeof (SelectedItemMainViewModel))]
    public class SplitViewController : MvvmSplitViewController
    {
        #region Constructors

        public SplitViewController()
        {
            this.SetBindingMemberValue(AttachedMembers.UISplitViewController.MasterView, new UINavigationController(new MainViewController()));
        }

        #endregion

        #region Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Bind(AttachedMembers.UISplitViewController.DetailView)
                .To<SelectedItemMainViewModel>(() => (vm, ctx) => vm.SelectedItem)
                .WithConverter(ViewModelToViewConverter.Instance)
                .Build();
        }

        #endregion
    }
}