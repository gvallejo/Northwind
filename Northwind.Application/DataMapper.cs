using Service = Northwind.Application.CustomerService;
namespace Northwind.Application
{
    public static class DataMapper
    {
        public static Model.Customer Update(this Model.Customer model, Service.Customer dto)
        {
            model.CustomerID = dto.CustomerID;
            model.CompanyName = dto.CompanyName;
            model.ContactName = dto.ContactName;
            model.Address = dto.Address;
            model.City = dto.City;
            model.Region = dto.Region;
            model.Country = dto.Country;
            model.PostalCode = dto.PostalCode;
            model.Phone = dto.Phone;
            return model;
        }
    }
}