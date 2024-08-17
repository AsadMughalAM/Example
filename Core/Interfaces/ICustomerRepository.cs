using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetData();
        Customer Create(Customer customer);
        Customer Update(Customer customer);
    }
}
