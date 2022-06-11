using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Categories.Commands.CreateCategory;
using Store.Application.Features.Categories.Commands.DeleteCategory;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CategoryListVM>>> GetCategoriesList()
        {
            var dtos = await mediator.Send(new GetCategoriesListQuery());

            return Ok(dtos);
        }

        [HttpGet("getCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryVM>> GetCategoryById(Guid Id)
        {
            var dtos = await mediator.Send(new GetCategoryByIdQuery() { Id = Id});

            return Ok(dtos);
        }

        [HttpPost("addCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await mediator.Send(createCategoryCommand);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            var response = await mediator.Send(new DeleteCategoryCommand());

            return Ok(response);
        }
    }
}
