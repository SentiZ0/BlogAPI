using AutoMapper;
using BlogAPI.Features.Category.Commands.Create;
using BlogAPI.Features.Category.Commands.Delete;
using BlogAPI.Features.Category.Commands.Update;
using BlogAPI.Features.Category.Queries.Get;
using BlogAPI.Features.Category.Queries.GetAll;
using BlogAPI.Models;
using BlogAPI.Models.ModelsDTO.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private readonly BlogContext _context;

        public CategoriesController(IMapper mapper, BlogContext context, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
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

            var response = await _mediator.Send(new GetSingleCategoryQuery() { Id = id });

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
