using Microsoft.AspNetCore.Mvc;
using AssignmentManagement.Core.Models;
using AssignmentManagement.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private readonly IAssignmentService _service;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _service = assignmentService;
        }

        // GET: api/<AssignmentController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var assignments = _service.GetAll();
            return Ok(assignments);
        }

        // GET api/<AssignmentController>/title
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var assignment = _service.GetAssignment(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public IActionResult Create([FromBody] Assignment assignment)
        {
            _service.Add(assignment);
            return CreatedAtAction(nameof(Get), new { id = assignment.Id }, assignment);
        }

        // PUT api/<AssignmentController>/5
        [HttpPut("{id:guid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssignmentController>/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
