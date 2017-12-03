using System;
using Xamarin.Forms;

namespace shoppe.ViewModels
{
    public class ShoppeViewModel: ViewModelBase
    {
        DataManager manager;

        public ShoppeViewModel(ShopPromotion shopPromotion, Page page): base(page)
        {
            manager = DataManager.DefaultManager;
            ShopName = shopPromotion.ShopName;
            ShopDetails = shopPromotion.ShopDetails;
            ShopBannerImageUrl = shopPromotion.ShopBannerImageUrl;
        }

        string shopName = string.Empty;

        public string ShopName
        {
            get { return shopName; }
            set { SetProperty(ref shopName, value); }
        }

        string shopDetails = string.Empty;

        public string ShopDetails
        {
            get { return shopDetails; }
            set { SetProperty(ref shopDetails, value); }
        }

        string shopBannerImageUrl = string.Empty;

        public string ShopBannerImageUrl
        {
            get { return shopBannerImageUrl; }
            set { SetProperty(ref shopBannerImageUrl, value); }
        }
    }
}
