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

            var pages = Application.Current.MainPage.Navigation.NavigationStack;

            if (pages.Count < 3)
            {
                // Set syncItems to true in order to synchronize the data on startup when running in offline mode
                RefreshItems(true, syncItems: true);
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

