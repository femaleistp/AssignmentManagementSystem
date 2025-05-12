using Microsoft.AspNetCore.Mvc;
using AssignmentManagement.API.Controllers;
using AssignmentManagement.API.Models;
using AssignmentManagement.API.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentManagement.API
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
        [HttpGet("{title}")]
        public IActionResult Get(string title)
        {
            var assignment = _service.GetAssignment(title);
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
            return CreatedAtAction(nameof(Get), new { title = assignment.Title }, assignment);
        }

        // PUT api/<AssignmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssignmentController>/5
        [HttpDelete("{title}")]
        public IActionResult Delete(string title)
        {
            _service.Delete(title);
            return NoContent();
        }
    }
}
