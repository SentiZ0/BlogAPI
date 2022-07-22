using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.ModelsDTO.Category;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly BlogContext _context;

        public CategoriesController(IMapper mapper, BlogContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleCategory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyCategory(Category categoryDTO)
        {
            var category = _context.Categories.Where(x => x.Id == categoryDTO.Id).FirstOrDefault(x => x.Id == categoryDTO.Id);

            if(category == null)
            {
                return NotFound();
            }

            category.Name = categoryDTO.Name;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(categoryDTO);

            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok();
        }
    }
}
