using MediatR;
using MyProductStore.Application.DTOs.Output;
using System.Collections.Generic;

namespace MyProductStore.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductOutputDto>>
    {
    }
}
