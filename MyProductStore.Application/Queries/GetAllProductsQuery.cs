using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.QueryParameter;

namespace MyProductStore.Application.Queries
{
    public class GetAllProductsQuery : IRequest<PagedListOutputDto<ProductOutputDto>>
    {
        public ProductQueryParameter CustomQueryParameter { get; set; }

        public GetAllProductsQuery(ProductQueryParameter customQueryParameter)
        {
            CustomQueryParameter = customQueryParameter;
        }
    }
}
