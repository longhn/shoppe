using System;
namespace shoppe.ViewModels
{
    public static class ViewModelLocator
    {
        static bool UseDesignTime => false;

        static FeedbackViewModel feedbackVM;

        public static FeedbackViewModel FeedbackViewModel
        => feedbackVM ?? (feedbackVM = new FeedbackViewModel(null));
    }
}
