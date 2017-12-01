
using Xamarin.Forms;
using MvvmHelpers;

namespace shoppe.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        protected Page page;

        public ViewModelBase(Page page)
        {
            this.page = page;
        }
    }
}