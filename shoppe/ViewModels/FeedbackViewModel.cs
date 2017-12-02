using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

namespace shoppe.ViewModels
{
    public class FeedbackViewModel: ViewModelBase
    {
        DataManager manager;

        public FeedbackViewModel(Page page) : base(page)
        {
            manager = DataManager.DefaultManager;
            Title = "Your Feedback";
        }

        public async Task<IEnumerable<ShopPromotion>> GetShopsAsync()
        {
            if (IsBusy)
                return new List<ShopPromotion>();

            IsBusy = true;

            try
            {
                return await manager.GetShopPromotionsAsync2() ?? new List<ShopPromotion>();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await page.DisplayAlert("Uh Oh :(", "Unable to gather shop.", "OK");
            }
            finally
            {
                IsBusy = false;
            }

            return new List<ShopPromotion>();
        }

        bool requiresCall = false;

        public bool RequiresCall
        {
            get { return requiresCall; }
            set { SetProperty(ref requiresCall, value); }
        }


        string phone = string.Empty;

        public string PhoneNumber
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string message = "Loading...";

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        string text = string.Empty;

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }


        int rating = 10;

        public int Rating
        {
            get { return rating; }
            set
            {
                SetProperty(ref rating, value);
            }
        }

        DateTime date = DateTime.Today;

        public DateTime Date
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
            }
        }

        public string ShopName { get; set; } = string.Empty;
    }
}
