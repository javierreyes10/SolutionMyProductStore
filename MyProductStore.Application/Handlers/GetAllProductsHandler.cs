using AutoMapper;
using MediatR;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductOutputDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductOutputDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var products = await _unitOfWork.Products.GetAllProductsAsync(request.CustomQueryParameter);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductOutputDto>>(products);
        }
    }
}
