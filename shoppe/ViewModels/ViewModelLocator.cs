using System;
namespace shoppe.ViewModels
{
    public static class ViewModelLocator
    {
        static bool UseDesignTime => false;

        static FeedbackViewModel feedbackVM;

        public static FeedbackViewModel FeedbackViewModel => feedbackVM ?? (feedbackVM = new FeedbackViewModel(null));

        static ShoppePromotionViewModel shoppePromotionViewModel;

        public static ShoppePromotionViewModel ShoppePromotionViewModel
        {
            get
            {
                if (!UseDesignTime)
                    return null;

                if (shoppePromotionViewModel != null)
                    return shoppePromotionViewModel;

                return shoppePromotionViewModel;
            }
        }

        static ShoppeViewModel shoppeViewModel;

        public static ShoppeViewModel ShoppeViewModel
        {
            get
            {
                if (!UseDesignTime)
                    return null;

                if (shoppeViewModel != null)
                    return shoppeViewModel;

                return shoppeViewModel;
            }
        }
    }
}
