using System;
using System.Threading.Tasks;
using shoppe.ViewModels;
using Xamarin.Forms;

namespace shoppe.Views
{
    public partial class ShoppePromotion : ContentPage
    {
        ShoppePromotionViewModel viewModel;

        public ShoppePromotion()
        {
            InitializeComponent();
            BindingContext = viewModel = new ShoppePromotionViewModel(this);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
            RefreshItems(true, syncItems: true);
        }

        // Event handlers
        public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var shop = e.SelectedItem as ShopPromotion;

            if (Device.RuntimePlatform != Device.iOS && shop != null)
            {
                // Not iOS - the swipe-to-delete is discoverable there
                if (Device.RuntimePlatform == Device.Android)
                {
                    
                }
                else
                {
                    // Windows, not all platforms support the Context Actions yet
                }
            }

        }

        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;

            try
            {
                RefreshItems(false, true);
            }catch (Exception ex){
                error = ex;
            }finally{
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

        public async void OnSyncItems(object sender, EventArgs e)
        {
            RefreshItems(true, true);
        }

        private void RefreshItems(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                viewModel.GetShopPromotionCommand.Execute(null);
            }
        }
    }
}

