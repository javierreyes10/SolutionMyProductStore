using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Core.QueryParameter;

namespace MyProductStore.Application.Queries.User
{
    public class GetAllUsersQuery : IRequest<PagedListOutputDto<UserOutputDto>>
    {
        public UserQueryParameter CustomQueryParameter { get; set; }

        public GetAllUsersQuery(UserQueryParameter customQueryParameter)
        {
            CustomQueryParameter = customQueryParameter;
        }
    }
}
