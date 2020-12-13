using MediatR;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserOutputDto>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
