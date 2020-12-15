using MediatR;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Queries.Products
{
    public class GetProductByIdQuery : IRequest<ProductOutputDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
