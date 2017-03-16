using System;
using Android.App;
using Android.Runtime;
using MugenMvvmToolkit.Android.AppCompat.Views.Activities;

namespace ApiExamples.Views
{
    [Activity]
    public class CompatPreferenceView : MvvmAppCompatActivity
    {
        #region Constructors

        public CompatPreferenceView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CompatPreferenceView() : base(Resource.Layout.CompatPreferenceView)
        {            
        }

        #endregion
    }
}