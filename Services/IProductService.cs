using ProvaPub.Models;

namespace ProvaPub.Services
{
    public interface IProductService
	{
		Task<ProductList> ListProducts(int page);
    }
}
