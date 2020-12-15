using AutoMapper;
using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace MyProductStore.Application.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedListOutputDto<ProductOutputDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedListOutputDto<ProductOutputDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var products = await _unitOfWork.Products.GetAllProductsAsync(request.CustomQueryParameter);
            var productsAsEnumerable = await products.ToListAsync();

            return new PagedListOutputDto<ProductOutputDto>
            {
                Items = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductOutputDto>>(productsAsEnumerable),
                Metadata = new PaginationMetadataOutput
                {
                    TotalCount = products.TotalItemCount,
                    PageSize = products.PageSize,
                    TotalPages = products.PageCount,
                    CurrentPage = products.PageNumber,
                    IsFirstPage = products.IsFirstPage,
                    IsLastPage = products.IsLastPage,
                    HasNextPage = products.HasNextPage,
                    HasPreviousPage = products.HasPreviousPage
                }
            };


        }
    }
}
