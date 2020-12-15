using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands;
using MyProductStore.Application.Commands.Products;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.Products
{
    public class PatchProductHandler : IRequestHandler<PatchProductCommand, ProductOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PatchProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //TODO: How to validate the constraints here??

        public async Task<ProductOutputDto> Handle(PatchProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (product == null) return null;

            var productInputDto = _mapper.Map<ProductInputDto>(product);

            request.JsonPatchDocument.ApplyTo(productInputDto, error =>
            {

                Debug.WriteLine(error.ToString());
            });

            _mapper.Map(productInputDto, product);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Product, ProductOutputDto>(product);

        }
    }
}
