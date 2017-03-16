using Android.App;
using ApiExamples.ViewModels.Tabs;
using MugenMvvmToolkit.Attributes;
#if APPCOMPAT
using MvvmActivity = MugenMvvmToolkit.Android.AppCompat.Views.Activities.MvvmAppCompatActivity;
#else
using MugenMvvmToolkit.Android.Views.Activities;
#endif

namespace ApiExamples.Views
{
    [Activity(Label = "ApiExamples")]
    [ViewModel(typeof(TabViewModel), Constants.CardRecyclerView)]
    public class CardRecyclerViewActivity : MvvmActivity
    {
        #region Constructors

        public CardRecyclerViewActivity()
            : base(Resource.Layout.CardRecyclerView)
        {
        }

        #endregion
    }
}