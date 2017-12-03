using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmHelpers;
using shoppe.Views;
using Xamarin.Forms;

namespace shoppe.ViewModels
{
    public class ShoppePromotionViewModel : ViewModelBase
    {
        DataManager manager;
        public ObservableRangeCollection<ShopPromotion> ShopPromotionList {get; set;}

        public ShoppePromotionViewModel(Page page): base(page)
        {
            manager = DataManager.DefaultManager;
            ShopPromotionList = new ObservableRangeCollection<ShopPromotion>();
            SelectedShop = new ShopPromotion();
        }

        ShopPromotion selectedShop;
        public ShopPromotion SelectedShop
        {
            get { return selectedShop; }
            set
            {
                selectedShop = value;
                OnPropertyChanged("SelectedShop");

                if (selectedShop == null)
                    return;

                if (ShopPromotionList != null && ShopPromotionList.Count > 0) {
                    page.Navigation.PushAsync(new ShoppePage(selectedShop));
                    SelectedShop = null;
                }
            }
        }

        private Command getShopPromotionCommand;

        public Command GetShopPromotionCommand
        {
            get
            {
                return getShopPromotionCommand ?? (getShopPromotionCommand = new Command(async () => await ExecuteGetShopPromotionCommand(), () => { return !IsBusy; }));
            }
        }

        private async Task ExecuteGetShopPromotionCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            GetShopPromotionCommand.ChangeCanExecute();

            try
            {
                ShopPromotionList.Clear();
                var promotionList = await manager.GetShopPromotionsAsync();
                ShopPromotionList.ReplaceRange(promotionList);
            }catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }finally
            {
                IsBusy = false;
                GetShopPromotionCommand.ChangeCanExecute();
            }
        }
    }
}
