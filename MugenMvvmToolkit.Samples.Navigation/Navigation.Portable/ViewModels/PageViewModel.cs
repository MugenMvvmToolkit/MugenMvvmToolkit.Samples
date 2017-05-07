using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;

namespace Navigation.Portable.ViewModels
{
    public class PageViewModel : NavigationViewModelBase
    {
        #region Constructors

        public PageViewModel(IMessagePresenter messagePresenter) : base(messagePresenter)
        {
        }

        #endregion

        #region Properties

        public string Text => "Page view model";

        #endregion

        #region Methods

        protected override Task<bool> OnClosing(IDataContext context)
        {
            return ShowCloseQuestionAsync("page");
        }

        #endregion
    }
}