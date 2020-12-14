using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers
{
    public class PostProductHandler : IRequestHandler<CreateProductCommand, ProductOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductOutputDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductInputDto, Product>(request.Product);

            await _unitOfWork.Products.AddAsync(product);
            var result = await _unitOfWork.CommitAsync();

            if (result <= 0) throw new Exception("The product could not be created. Please try again");

            return _mapper.Map<Product, ProductOutputDto>(product);

        }
    }
}
