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
    public class PostProductHandler : IRequestHandler<PostProductCommand, ProductOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductOutputDto> Handle(PostProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<PostProductCommand, Product>(request);

            await _unitOfWork.Products.AddAsync(product);
            var result = await _unitOfWork.CommitAsync();

            //TODO: Create my own exceptions
            if (result <= 0) throw new Exception("The product cannot be created");

            return _mapper.Map<Product, ProductOutputDto>(product);

        }
    }
}
