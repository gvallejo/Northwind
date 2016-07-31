using System.Collections.Generic;
using System.ServiceModel;
namespace Northwind.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomer(string customerID);
    }
}