using MyProductStore.Core.Repositories;
using System.Threading.Tasks;

namespace MyProductStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}
