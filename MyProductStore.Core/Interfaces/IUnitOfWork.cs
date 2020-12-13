using MyProductStore.Core.Repositories;
using System.Threading.Tasks;

namespace MyProductStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
