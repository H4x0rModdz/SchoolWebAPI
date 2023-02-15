using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAll(string? filter = null) // filter example: filter = educationLevel == HighSchool
        {
            if (string.IsNullOrEmpty(filter))
                return BadRequest("Invalid filter");

            try
            {
                var studentsList = _service.GetAll(filter);

                if (studentsList == null || !studentsList.Any())
                    return NoContent();

                return Ok(studentsList);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error getting student list");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult GetById(Guid id)
        {
            try
            {
                var student = _service.GetById(id);

                if (student == null)
                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error getting student");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Add([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var addedStudent = _service.Add(student);
                return CreatedAtAction(nameof(GetById), new { id = addedStudent.Id }, addedStudent); // used to show the url of the resource without having to search the db again
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error adding student");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("EditStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Edit([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var studentToEdit = _service.GetById(student.Id);

                if (studentToEdit is null)
                    return NotFound();

                return Ok(_service.Edit(student));
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error editing student");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error deleting student");
                return StatusCode(500, "Internal server error");
            }

            return Ok();
        }
    }
}