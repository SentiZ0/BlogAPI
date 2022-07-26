using AutoMapper;
using BlogAPI.Features.Category.Commands.Create;
using BlogAPI.Features.Category.Commands.Delete;
using BlogAPI.Features.Category.Commands.Update;
using BlogAPI.Features.Category.Queries.Get;
using BlogAPI.Features.Category.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var response = await _mediator.Send(new GetAllCategoryQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleCategory(int id)
        {
            var command = new GetSingleCategoryQuery(id);

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if(response == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ModifyCategory(UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if(response == null)
            { 
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
