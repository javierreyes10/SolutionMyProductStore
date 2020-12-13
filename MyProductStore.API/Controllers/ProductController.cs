﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries;
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
        private readonly IMediator _mediator;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductOutputDto>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateProduct([FromBody] PostProductCommand postProductCommand)
        {
            var product = await _mediator.Send(postProductCommand);
            return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] PutProductCommand putProductCommand)
        {
            putProductCommand.Id = id;
            var product = await _mediator.Send(putProductCommand);

            if (product == null) return NotFound();

            return Ok(product);
        }


    }
}
