using AutoMapper;
using BlogAPI.Features.Author.Commands.Create;
using BlogAPI.Features.Author.Commands.Delete;
using BlogAPI.Features.Author.Commands.Update;
using BlogAPI.Features.Author.Queries.GetAll;
using BlogAPI.Features.Author.Queries.GetSingle;
using BlogAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthors()
        {
            var response = await _mediator.Send(new GetAllAuthorsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleAuthor(int id)
        {
            var query = new GetSingleAuthorQuery(id);
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAuthor(DeleteAuthorCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ModifyAuthor(UpdateAuthorCommand command)
        {
            var repsonse = await _mediator.Send(command);

            if (repsonse == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(CreateAuthorCommand command)
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
