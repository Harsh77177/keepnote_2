using Keep_Note4.Model;
using Keep_Note4.Repository;
using Microsoft.AspNetCore.Mvc;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Keep_Note4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepo _repo;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<UserController>

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.Info("SampleController: Get method called");
            var obj = _repo.GetUserById(id);
            if (obj == null)
                return BadRequest("No User Found");
            return Ok(obj);
        }

        [HttpGet("Validate/{id}")]
        public IActionResult ValidateUser(int id, string password)
        {
            var obj = _repo.ValidateUser(id, password);
            if (obj == false)
            {
                return NotFound("User Does Not Exist");
            }
            return Ok("Users Exist");
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var obj = _repo.RegisterUser(user);
            return CreatedAtAction("User Created", user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User value)
        {
            var obj = _repo.UpdateUser(id, value);
            if (obj == false)
            {
                return BadRequest("No User Found");
            }
            return Ok(obj);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _repo.DeleteUser(id);
            if (obj == false)
            {
                return BadRequest("No Data found");
            }
            return Ok("deleted");
        }
    }
}
