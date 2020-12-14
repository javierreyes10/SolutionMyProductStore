using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries;
using MyProductStore.Core.QueryParameter;
using Newtonsoft.Json;
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
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetAllProducts([FromQuery] ProductQueryParameter parameters)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(parameters));

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.Metadata));
            return Ok(products.Items);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductOutputDto>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductInputDto productInputDto)
        {
            var product = await _mediator.Send(new CreateProductCommand(productInputDto));
            return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductInputDto productInputDto)
        {
            var product = await _mediator.Send(new PutProductCommand(id, productInputDto));

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartiallyUpdateProduct(int id,
            [FromBody] JsonPatchDocument<ProductInputDto> patchDocument)
        {
            var product = await _mediator.Send(new PatchProductCommand(id, patchDocument));

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
