using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.ModelsDTO.AuthorDTO;
using BlogAPI.Models.ModelsDTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly BlogContext _context;
        public AuthorsController(IMapper mapper, BlogContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public List<GetAuthorDTO> GetAllAuthors()
        {
            var authorDTO = _context.Authors.Select(x => new GetAuthorDTO
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Hobby = x.Hobby,
                Job = x.Job,
                AuthorPosts = x.Author_Posts.Select(y => new GetPostDTO
                {
                    Id = y.PostId,
                    Title = y.Post.Title,
                    Description = y.Post.Description
                }).ToList(),
            }).ToList();

            return authorDTO;
        }

        [HttpGet("{id}")]
        public GetAuthorDTO GetSingleAuthor(int id)
        {
            var authorDTO = _context.Authors.Where(x => x.Id == id).Select(x => new GetAuthorDTO
            {
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Hobby = x.Hobby,
                Job = x.Job,
                AuthorPosts = x.Author_Posts.Select(y => new GetPostDTO
                {
                    Id = y.Id,
                    Title = y.Post.Title,
                    Description = y.Post.Description
                }).ToList(),
            }).FirstOrDefault();

            return authorDTO;
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Authors.Include(x => x.Author_Posts).FirstOrDefault(x => x.Id == id);

            var postIds = author.Author_Posts;

            foreach(var postId in postIds)
            {
                var post = _context.Posts.FirstOrDefault(x => x.Id == postId.Id);

                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult ModifyAuthor(UpdateAuthorDTO authorDTO)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorDTO.Id);

            if(author == null)
            {
                return NotFound();
            }

            author.Name = authorDTO.Name;
            author.Email = authorDTO.Email;
            author.Age = authorDTO.Age;
            author.Hobby = authorDTO.Hobby;
            author.Job = authorDTO.Job;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public Author CreateAuthor(CreateAuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);

            _context.Add(author);

            _context.SaveChanges();

            return author;
        }
    }
}
