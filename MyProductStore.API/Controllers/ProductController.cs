using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.API.Filters;
using MyProductStore.API.Helpers;
using MyProductStore.Application.Commands.Products;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.Queries.Products;
using MyProductStore.Core.QueryParameter;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyProductStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve a list of all the products created. A "X-Pagination" Response Header is added for more details about pagination
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <response code="200">List of all the products with filters and pagination applied. By Default PageNumer = 1 and PageSize = 10</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetAllProducts([FromQuery] ProductQueryParameter parameters)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(parameters));

            Response.AddPaginationMetadata(products.Metadata);
            
            return Ok(products.Items);
        }

        /// <summary>
        /// Retrieve a single product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Product requested by Id</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductOutputDto>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null) return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Create a new product.  For this action you must be authenticated thru /api/users/authenticate
        /// </summary>
        /// <param name="productInputDto"></param>
        /// <returns></returns>
        /// <response code="201">Product created successfully. For getting the product created, please go to the HTTP Response "location" field</response>        
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult> CreateProduct([FromBody] ProductInputDto productInputDto)
        {
            var product = await _mediator.Send(new CreateProductCommand(productInputDto));
            return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);
        }


        /// <summary>
        /// Update an existing product by Id.  For this action you must be authenticated thru /api/users/authenticate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productInputDto"></param>
        /// <returns></returns>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductInputDto productInputDto)
        {
            var product = await _mediator.Send(new PutProductCommand(id, productInputDto));

            if (product == null) return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Use this endpoint for updating a specific product field.  For this action you must be authenticated thru /api/users/authenticate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<ActionResult> PartiallyUpdateProduct(int id,
            [FromBody] JsonPatchDocument<ProductInputDto> patchDocument)
        {
            var product = await _mediator.Send(new PatchProductCommand(id, patchDocument));

            if (product == null) return NotFound();

            return Ok(product);

        }

        /// <summary>
        /// Delete an existing product by Id.  For this action you must be authenticated thru /api/users/authenticate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Product deleted succesfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _mediator.Send(new DeleteProductCommand(id));

            if (product == null) return NotFound();

            return NoContent();
        }
    }
}
