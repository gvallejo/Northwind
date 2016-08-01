using Northwind.Application;
using Northwind.Application.CustomerService;

namespace Northwind.ViewModel
{
    public class ViewModelLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;

        public static MainWindowViewModel MainWindowViewModelStatic
        {
            get
            {
                // return the value of _mainWindowViewModel if _mainWindowViewModel is NOT null; otherwise,
                // if _mainWindowViewModel = null, return -1.
                return _mainWindowViewModel ?? (_mainWindowViewModel = new MainWindowViewModel(new UIDataProvider(new CustomerServiceClient())));
            }
        }
    }
}