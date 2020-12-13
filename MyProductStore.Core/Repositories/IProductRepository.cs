using MyProductStore.Core.Entities;
using MyProductStore.Core.QueryParameter;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IPagedList<Product>> GetAllProductsAsync(ProductQueryParameter parameter);
    }
}

