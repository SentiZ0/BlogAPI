using AutoMapper;
using BlogAPI.Features.Post.Commands.Create;
using BlogAPI.Features.Post.Commands.Delete;
using BlogAPI.Features.Post.Commands.Update;
using BlogAPI.Features.Post.Queries.GetAll;
using BlogAPI.Features.Post.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            var response = await _mediator.Send(new GetAllPostsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSinglePost(int id)
        {
            var command = new GetSinglePostQuery(id);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public ActionResult DeletePost(DeletePostCommand command)
        {
            var response = _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPost(UpdatePostCommand command)
        {
            var response = _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(CreatePostCommand command)
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
