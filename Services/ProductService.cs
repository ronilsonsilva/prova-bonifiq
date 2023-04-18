using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{

    public class ProductService : IProductService
	{
		private readonly IRepository<Product, ProductList> _repository;

        public ProductService(IRepository<Product, ProductList> repository)
        {
            _repository = repository;
        }

        public async Task<ProductList> ListProducts(int page)
		{
            return await _repository.List(page);
		}
	}
}
