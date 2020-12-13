using MyProductStore.Core.Entities;
using MyProductStore.Core.QueryParameter;
using MyProductStore.Core.Repositories;
using MyProductStore.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ProductStoreDbContext ProductStoreDbContext => Context as ProductStoreDbContext;

        public ProductRepository(ProductStoreDbContext context) : base(context)
        {
        }
        public async Task<IPagedList<Product>> GetAllProductsAsync(ProductQueryParameter parameter)
        {
            var products = ProductStoreDbContext.Products.AsQueryable();

            SearchByName(ref products, parameter.Name);
            SearchBySku(ref products, parameter.Sku);

            return await products.ToPagedListAsync(parameter.PageNumber, parameter.PageSize);
        }

        //TODO: GENERIC METHODS?
        private void SearchByName(ref IQueryable<Product> products, string name)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(name)) return;

            products = products.Where(p => p.Name.ToLower().Contains(name.Trim().ToLower()));

        }

        private void SearchBySku(ref IQueryable<Product> products, string name)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(name)) return;

            products = products.Where(p => p.SKU.ToLower().Contains(name.Trim().ToLower()));

        }
    }
}
