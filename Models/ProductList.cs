namespace ProvaPub.Models
{
    public class ProductList : BaseList<Product>
    {
        public ProductList()
        {
        }
        public ProductList(List<Product> products, int totalCount, int currentPage) : base(products, totalCount, currentPage) { }
    }
}
