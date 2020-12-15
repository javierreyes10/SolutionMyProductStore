using MyProductStore.Core.Entities;
using MyProductStore.Core.QueryParameter;
using MyProductStore.Core.Repositories;
using MyProductStore.Infrastructure.Data;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ProductStoreDbContext ProductStoreDbContext => Context as ProductStoreDbContext;

        public UserRepository(ProductStoreDbContext context) : base(context)
        {
        }

        public async Task<IPagedList<User>> GetAllUsersAsync(UserQueryParameter parameter)
        {
            var users = ProductStoreDbContext.Users.AsQueryable();

            return await users.ToPagedListAsync(parameter.PageNumber, parameter.PageSize);
        }
    }
}
