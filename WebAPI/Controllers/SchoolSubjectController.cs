using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    public class SchoolSubjectController : Controller
    {
        private readonly ISchoolSubjectService _service;
        public SchoolSubjectController(ISchoolSubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllSubjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SchoolSubject>>> GetAll()
        {
            try
            {
                var subjectsList = await _service.GetAll();

                if (!subjectsList.Any())
                    return NoContent();

                return Ok(subjectsList);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error getting all subjects");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetSubjectById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var subject = await _service.GetById(id);

                if (subject is null)
                    return NotFound();

                return Ok(subject);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error finding subject");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("AddSubject")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Add([FromBody] SchoolSubject subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var subjectAdded = await _service.Add(subject);
                return CreatedAtAction(nameof(GetById), new { id = subjectAdded.Id }, subjectAdded);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error adding subject");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("EditSubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult>Edit([FromBody] SchoolSubject subject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _service.Edit(subject);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error editing subject");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("DeleteSubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _service.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _service.LogError(ex, "Error deleting subject");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}