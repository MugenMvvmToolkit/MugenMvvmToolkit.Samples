﻿using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace Validation.Views
{
    public partial class DataAnnotationView : ContentPage
    {
        #region Constructors

        public DataAnnotationView()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed(base.OnBackButtonPressed);
        }

        #endregion
    }
}
