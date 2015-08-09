using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
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

        #region Overrides of MvvmActivity

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetItemAnimator(new DefaultItemAnimator());
        }

        #endregion
    }
}