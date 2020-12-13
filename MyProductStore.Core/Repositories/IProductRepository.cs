using MyProductStore.Core.Entities;
using MyProductStore.Core.QueryParameter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProductStore.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CustomQueryParameter parameter);
    }
}

