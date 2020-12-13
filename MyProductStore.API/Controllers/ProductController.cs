using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProductStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
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
        public async Task<ActionResult> CreateProduct([FromBody] ProductCommand postProductCommand)
        {
            var product = await _mediator.Send(postProductCommand);
            return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductCommand putProductCommand)
        {
            putProductCommand.Id = id;
            var product = await _mediator.Send(putProductCommand);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _mediator.Send(new DeleteProductCommand(id));

            if (product == null) return NotFound();

            return NoContent();
        }
    }
}
