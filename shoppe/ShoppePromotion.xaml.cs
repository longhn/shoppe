using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace shoppe
{
    public partial class ShoppePromotion : ContentPage
    {
        DataManager manager;

        public ShoppePromotion()
        {
            InitializeComponent();

            manager = DataManager.DefaultManager;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
            await RefreshItems(true, syncItems: true);
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

            // prevents background getting highlighted
            promotionList.SelectedItem = null;
        }

        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;

            try
            {
                await RefreshItems(false, true);
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
            await RefreshItems(true, true);
        }

        private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                promotionList.ItemsSource = await manager.GetShopPromotionsAsync(syncItems);
            }
        }
    }
}

