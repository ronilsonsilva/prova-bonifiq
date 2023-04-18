using ProvaPub.Models;

namespace ProvaPub.Services
{
    public interface ICustomerService
    {
        Task<CustomerList> ListCustomers(int page);
        Task<bool> CanPurchase(int customerId, decimal purchaseValue);
    }
}
