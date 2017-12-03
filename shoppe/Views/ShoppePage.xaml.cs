using System;
using System.Collections.Generic;
using shoppe.ViewModels;
using Xamarin.Forms;

namespace shoppe.Views
{
    public partial class ShoppePage : ContentPage
    {
        ShoppeViewModel viewModel;

        public ShoppePage(ShopPromotion shopPromotion)
        {
            InitializeComponent();
            BindingContext = viewModel = new ShoppeViewModel(shopPromotion, this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
