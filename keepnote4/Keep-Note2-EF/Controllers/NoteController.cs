using Keep_Note4.Model;
using Keep_Note4.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Keep_Note4.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public INoteRepo _repo;
        public NoteController(INoteRepo repo)
        {
            _repo = repo;
        }
        //GET: api/<NoteController>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetNoteByNoteId(id));
        }

        // GET api/<NoteController>/5
        [HttpGet("Users/{id}")]
        public IActionResult GetNotesByUserId(int id)
        {
            var obj = _repo.GetAllNotesByUserId(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/<NoteController>
        [HttpPost]
        public IActionResult Post(Note note)
        {
            var obj = _repo.CreateNote(note);
            if (obj != null)
            {
                return CreatedAtAction("Done", obj);
            }
            return Ok(obj);
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Note note)
        {
            var obj = _repo.UpdateNote(id, note);
            if (obj == false)
            {
                return BadRequest("False");
            }
            return Ok("Updated");

        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _repo.DeleteNote(id);
            if (obj == true)
            {
                return Ok("Deleted");
            }
            return BadRequest();
        }
    }
}
