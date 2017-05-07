using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;

namespace Navigation.Portable.ViewModels
{
    public class DialogViewModel : NavigationViewModelBase
    {
        #region Constructors

        public DialogViewModel(IMessagePresenter messagePresenter) : base(messagePresenter)
        {
        }

        #endregion

        #region Properties

        public string Text => "Dialog view model";

        #endregion

        #region Methods

        protected override Task<bool> OnClosing(IDataContext context)
        {
            return ShowCloseQuestionAsync("dialog");
        }

        #endregion
    }
}