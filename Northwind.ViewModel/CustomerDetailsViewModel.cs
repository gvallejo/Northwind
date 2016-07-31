using Northwind.Application;
using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel
    {
        private readonly IUIDataProvider _dataProvider;
        public Customer Customer { get; set; }

        public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
        {
            _dataProvider = dataProvider;
            Customer = _dataProvider.GetCustomer(customerID);
            if(Customer != null)
                DisplayName = Customer.CompanyName;
        }
    }
}
