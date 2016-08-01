using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application.CustomerService;
using Rhino.Mocks;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application.Tests
{
    [TestClass()]
    public class UIDataProviderTest
    {
        /// <summary> 
        ///A test for GetCustomer 
        ///</summary> 
        [TestMethod()]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            // Arrange 
            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();
            UIDataProvider target = new UIDataProvider(customerServiceMock);
            var customerDtos = new Service.Customer[] { new Service.Customer()};

            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);
            // Act 
            target.GetCustomers();
            // Assert 
            customerServiceMock.AssertWasCalled(c => c.GetCustomers());
        }
        /// <summary> 
        ///A test for GetCustomer 
        ///</summary> 
        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_DtoPassedToTranslator()
        {
            // Arrange 
            ICustomerService customerServiceStub = MockRepository.GenerateStub<ICustomerService>();
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceStub);
            var expected = new Service.Customer();
            var customerDtos = new Service.Customer[] {
     expected
    };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);
            // Act 
            target.GetCustomers();
            // Assert 
            CustomerTranslator.Instance.AssertWasCalled(c => c.CreateModel(expected));
        }
        /// <summary> 
        ///A test for GetCustomer 
        ///</summary> 
        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_ModelReturnedFromTranslator()
        {
            // Arrange 
            ICustomerService customerServiceStub = MockRepository.GenerateStub<ICustomerService>();
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceStub);
            var dto = new Service.Customer();
            var expected = new Model.Customer();
            var customerDtos = new Service.Customer[] {
     dto
    };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(expected);
            // Act 
            var actual = target.GetCustomers();
            // Assert 
            Assert.AreSame(expected, actual[0]);
        }

        /// <summary> 
        ///A test for GetCustomers 
        ///</summary> 
        [TestMethod()]
        public void GetCustomer_Always_CallsGetCustomer()
        {
            // Arrange 
            const string expectedID = "expectedID";
            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceMock);
            var dto = new Service.Customer
            {
                CustomerID = expectedID
            };
            var model = new Model.Customer
            {
                CustomerID = expectedID
            };
            var customerDtos = new Service.Customer[] {
    dto
   };
            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(model);
            target.GetCustomers();
            // Load session data
         // Act 
   target.GetCustomer(expectedID);
            // Assert 
            customerServiceMock.AssertWasCalled(c => c.GetCustomer(expectedID));
        }
    }
}