using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers
{
    public class PutProductHandler : IRequestHandler<PutProductCommand, ProductOutputDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PutProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductOutputDto> Handle(PutProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (product == null) return null;

            _mapper.Map(request.Product, product);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Product, ProductOutputDto>(product);
        }
    }
}
