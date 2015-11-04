using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;
using MugenMvvmToolkit.Android.Design;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using Message = ApiExamples.Models.Message;

namespace ApiExamples.Views
{
    [Activity]
    public class SnackbarView : MvvmAppCompatActivity, IDataTemplateSelector
    {
        #region Constructors

        public SnackbarView() : base(Resource.Layout.SnackbarView)
        {
        }

        #endregion

        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var view = FindViewById(Resource.Id.coordinator_layout);
            this.SetBindingMemberValue(AttachedMembersDesign.Activity.SnackbarView, view);
            //Set template selector to handle the Message class.
            this.SetBindingMemberValue(AttachedMembersDesign.Activity.SnackbarTemplateSelector, this);
        }

        #endregion

        #region Implementation of interfaces

        public object SelectTemplate(object item, object container)
        {
            var message = item as Message;
            //Use default template.
            if (message == null)
                return null;
            return Snackbar
                .Make((View)container, message.Text, Snackbar.LengthIndefinite)
                .SetAction(message.ActionTitle, view => message.Command.Execute(null));
        }

        #endregion
    }
}