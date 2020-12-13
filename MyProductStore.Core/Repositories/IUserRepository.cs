using MyProductStore.Core.Entities;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IPagedList<User>> GetAllUsersAsync();
    }
}
