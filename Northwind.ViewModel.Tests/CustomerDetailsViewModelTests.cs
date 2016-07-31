using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Rhino.Mocks;
using Northwind.Model;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class CustomerDetailsViewModelTests
    {
        [TestMethod]
        public void Ctor_Always_CallsGetCustomer()
        { 
            // Arrange
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            const string expectedID = "EXPECTEDID";
            uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(new Customer()); 
            
            // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID); 
            
            // Assert
            uiDataProviderMock.VerifyAllExpectations();
        }
        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        { // Arrange
            IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();
            const string expectedID = "EXPECTEDID";
            Customer expectedCustomer = new Customer
            {
                CustomerID = expectedID
            };
            uiDataProviderStub.Stub(c => c.GetCustomer(expectedID)).Return(expectedCustomer); // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderStub, expectedID); // Assert
            Assert.AreSame(expectedCustomer, target.Customer);
        }
        [TestMethod]
        public void DisplayName_Always_ReturnsCompanyName()
        { // Arrange
            IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();
            const string expectedID = "EXPECTEDID";
            const string expectedCompanyName = "EXPECTEDNAME";
            Customer expectedCustomer = new Customer
            {
                CustomerID = expectedID,
                CompanyName = expectedCompanyName
            };
            uiDataProviderStub.Stub(c => c.GetCustomer(expectedID)).Return(expectedCustomer); // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderStub, expectedID); // Assert
            Assert.AreEqual(expectedCompanyName, target.DisplayName);
        }
    }
}
