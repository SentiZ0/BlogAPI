using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.ModelsDTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly BlogContext _context;

        public PostsController(IMapper mapper, BlogContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<GetPostDTO>> GetAllPosts()
        {
            var posts = _context.Posts.Select(x => new GetPostDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).ToList();

            if(posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<GetPostDTO> GetSinglePost(int id)
        {

            var post = _context.Posts.Where(x => x.Id == id).Select(x => new GetPostDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
                
            }).FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpDelete]
        public ActionResult DeletePost(int id)
        {
            var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPost(UpdatePostDTO postDTO)
        {
            var authors = _context.Authors.AsNoTracking().Where(x => postDTO.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToList();

            if (authors.Count != postDTO.AuthorIds.Count)
            {
                return BadRequest();
            }

            var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == postDTO.CategoryId);

            if (category == null)
            {
                return BadRequest();
            }

            var post = _context.Posts.Where(x => x.Id == postDTO.Id).Include(a => a.Author_Posts).FirstOrDefault(x => x.Id == postDTO.Id);

            post.Title = postDTO.Title;
            post.Description = postDTO.Description;
            post.CategoryId = postDTO.CategoryId;

            post.Author_Posts.Clear();

            post.Author_Posts = authors.Select(x => new Author_Post
            {
                AuthorId = x
            }).ToList();

            _context.SaveChanges();

            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDTO postDTO)
        {
            var authors = await _context.Authors.AsNoTracking().Where(x => postDTO.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToListAsync();

            if (authors.Count != postDTO.AuthorIds.Count)
            {
                return BadRequest();
            }

            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == postDTO.CategoryId);

            if (category == null)
            {
                return BadRequest();
            }

            var post = _mapper.Map<Post>(postDTO);

            post.Author_Posts = authors.Select(x => new Author_Post
            {
                AuthorId = x
            }).ToList();

            _context.Add(post);

            _context.SaveChanges();

            return Ok();
        }
    }
}
