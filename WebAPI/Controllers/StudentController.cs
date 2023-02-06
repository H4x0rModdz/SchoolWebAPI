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
        public ActionResult GetAll(string filter = null) // filter example: filter = educationLevel == HighSchool
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
                return BadRequest("There was an error processing your request");
            }
        }

        [HttpGet]
        [Route("GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(Guid id)
        {
            try
            {
                var student = _service.GetById(id);

                if (student == null)
                    return BadRequest();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Add([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var addedStudent = _service.Add(student);
                return CreatedAtAction(nameof(GetById), new { id = addedStudent.Id }, addedStudent);
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
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}