using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Products.Commands;
using Store.Application.Features.Products.Commands.DeleteProduct;
using Store.Application.Features.Products.Queries.GetProductById;
using Store.Application.Features.Products.Queries.GetProductsList;
using System;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);

            return Ok(response);
        }

        [HttpGet("getProductsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductCommandResponse>> GetProductsList()
        {
            var response = await _mediator.Send(new GetProductListQuery());

            return Ok(response);
        }

        [HttpGet("getProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductCommandResponse>> GetProductById(Guid Id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery() { Id = Id});

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteProduct([FromBody] DeleteProductCommand deleteProductCommand)
        {
            var response = await _mediator.Send(new DeleteProductCommand());

            return Ok(response);
        }
    }
}
