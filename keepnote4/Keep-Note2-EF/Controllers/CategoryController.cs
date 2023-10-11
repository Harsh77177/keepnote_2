using Keep_Note4.Model;
using Keep_Note4.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Keep_Note4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryRepo _repo;
        public CategoryController(ICategoryRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<CategoryController>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetCategoryById(id));
        }

        // GET api/<CategoryController>/5
        [HttpGet("User/{id}")]
        public IActionResult GetAllNotes(int id)
        {
            var obj = _repo.GetAllCategoriesByUserId(id);
            if (obj == null)
            {
                return NotFound("Not found");
            }
            return Ok(obj);

        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            var obj = _repo.CreateCategory(category);
            return CreatedAtAction("Created", category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Category category)
        {
            var obj = _repo.UpdateCategory(category);
            if (obj == false)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _repo.DeleteCategory(id);
            if (obj == false)
            {
                return NotFound("Category not found");
            }
            return Ok("deleted");
        }
    }
}
