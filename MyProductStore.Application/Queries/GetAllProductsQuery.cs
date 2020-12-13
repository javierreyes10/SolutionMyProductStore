using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.QueryParameter;
using System.Collections.Generic;

namespace MyProductStore.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductOutputDto>>
    {
        public CustomQueryParameter CustomQueryParameter { get; set; }

        public GetAllProductsQuery(CustomQueryParameter customQueryParameter)
        {
            CustomQueryParameter = customQueryParameter;
        }
    }
}
