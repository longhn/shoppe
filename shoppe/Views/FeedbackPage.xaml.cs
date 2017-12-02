using System;
using System.Collections.Generic;
using System.Diagnostics;
using shoppe.ViewModels;
using Xamarin.Forms;

namespace shoppe.Views
{
    public partial class FeedbackPage : ContentPage
    {
        FeedbackViewModel viewModel;
        public FeedbackPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FeedbackViewModel(this);
            PickerRating.SelectedIndex = 10;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var shops = await viewModel.GetShopsAsync();

                foreach (var shop in shops)
                    PickerStore.Items.Add(shop.ShopName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

