using Keep_Note4.Model;
using Keep_Note4.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Keep_Note4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        public IReminderRepo _repo;
        public ReminderController(IReminderRepo repo)
        {
            _repo = repo;
        }

        //GET: api/<ReminderController>
        [HttpGet("{id}")]
        public IActionResult GetReminders(int id)
        {
            return Ok(_repo.GetReminderById(id));
        }

        // GET api/<ReminderController>/5
        [HttpGet("Users/{id}")]
        public IActionResult GetAllRemindersByUserId(int id)
        {
            var obj = _repo.GetAllRemindersByUserId(id);
            if (obj == null)
            {
                return NotFound("Not found");
            }
            return Ok(obj);
        }

        // POST api/<ReminderController>
        [HttpPost]
        public IActionResult Post([FromBody] Reminder value)
        {
            var obj = _repo.CreateReminder(value);
            return CreatedAtAction("Created", value);
        }

        // PUT api/<ReminderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reminder value)
        {
            var obj = _repo.UpdateReminder(value);
            if (obj == false)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // DELETE api/<ReminderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _repo.DeletReminder(id);
            if (obj == false)
            {
                return NotFound("Category not found");
            }
            return Ok("deleted");
        }
    }
}
