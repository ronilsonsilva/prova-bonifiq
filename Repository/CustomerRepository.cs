using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class CustomerRepository : Repository<Customer, CustomerList>
    {
        public CustomerRepository(TestDbContext context) : base(context)
        {
        }

        public override async Task<CustomerList> List(int page)
        {
            if (page <= 0) throw new InvalidOperationException($"Page deve ser maior que 0");

            var customers = await _context.Customers.Skip((page - 1) * 10).Take(10).Include(x => x.Orders).ToListAsync();
            return new CustomerList(customers, _context.Products.Count(), page);
        }
    }
}
