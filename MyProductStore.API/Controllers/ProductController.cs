using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;
using MyProductStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProductStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetAllProducts()
        {

            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductOutputDto>>(products));
        }
    }
}
