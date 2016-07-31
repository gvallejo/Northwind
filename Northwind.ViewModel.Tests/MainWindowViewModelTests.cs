using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application.CustomerService;
using Northwind.Application;
using Rhino.Mocks;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void Customers_Always_CallsGetCustomers()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            uiDataProviderMock.Expect(c => c.GetCustomers()); 
            // Inject stub
            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);
            IList<Customer> customers = target.Customers;
            uiDataProviderMock.VerifyAllExpectations();
        }
    }
}
