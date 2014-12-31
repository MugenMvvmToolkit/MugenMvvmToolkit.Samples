﻿using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class BindingValidationView : ContentPage
    {
        #region Constructors

        public BindingValidationView()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed();
        }

        #endregion
    }
}
