using MyProductStore.Core.Entities;
using MyProductStore.Core.Repositories;
using System.Threading.Tasks;

namespace MyProductStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        Task<int> CommitAsync();
    }
}
