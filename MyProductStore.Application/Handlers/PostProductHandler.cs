using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers
{
    public class PostProductHandler : IRequestHandler<ProductCommand, ProductOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductOutputDto> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductCommand, Product>(request);

            await _unitOfWork.Products.AddAsync(product);
            var result = await _unitOfWork.CommitAsync();

            if (result <= 0) throw new Exception("The product could not be created. Please try again");

            return _mapper.Map<Product, ProductOutputDto>(product);

        }
    }
}
