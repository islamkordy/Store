using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Categories.Commands.CreateCategory;
using Store.Application.Features.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getCategoriesList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVM>>> GetCategoriesList()
        {
            var dtos = await mediator.Send(new GetCategoriesListQuery());

            return Ok(dtos);
        }

        [HttpGet("getCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryVM>> GetCategoryById(Guid Id)
        {
            var dtos = await mediator.Send(new GetCategoryByIdQuery());

            return Ok(dtos);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryVM>> Get()
        {
            var dtos = await mediator.Send(new GetCategoryByIdQuery());

            return Ok(dtos);
        }

        [HttpPost("addCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await mediator.Send(createCategoryCommand);

            return Ok(response);
        }
    }
}
