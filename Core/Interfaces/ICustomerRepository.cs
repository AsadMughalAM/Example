using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetData();
        Customer? GetById(string id);

        Customer Create(Customer customer);
    }
}
