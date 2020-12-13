using MyProductStore.Core.Entities;
using MyProductStore.Core.QueryParameter;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IPagedList<User>> GetAllUsersAsync(UserQueryParameter parameter);
    }
}
