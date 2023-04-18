namespace ProvaPub.Models
{
    public class CustomerList : BaseList<Customer>
    {
        public CustomerList() { }
        public CustomerList(List<Customer> customers, int totalCount, int currentPage) : base(customers, totalCount, currentPage) {}
    }
}
