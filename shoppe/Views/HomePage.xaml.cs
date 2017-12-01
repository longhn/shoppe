using System;
using System.Collections.Generic;
using Xamarin.Forms;
using shoppe.ViewModels;

namespace shoppe.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel(this);

            ButtonPromotions.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ShoppePromotion());
            };

            ButtonLeaveFeedback.Clicked += async (sender, e) =>
            {
                //await Navigation.PushAsync(new FeedbackPage());
            };
        }
    }
}
