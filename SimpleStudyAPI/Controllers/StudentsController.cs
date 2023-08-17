using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleStudyAPI.DTO;
using SimpleStudyAPI.Models;
using SimpleStudyAPI.Repository;
using SimpleStudyAPI.Services;
using System.Runtime.InteropServices;

namespace SimpleStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : ControllerBase
    {
        // Criar autenticação para API!!

        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentDTO>))]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var studentDto = await _studentService.GetAllAsync();
            if (studentDto is null)
                return NotFound("Students Not Found!!");
            return Ok(studentDto);
        }

        [HttpGet("id", Name = "GetStudents")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var student = await _studentService.GetByIdAsync(id);
            if (student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("StudentByName")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentDTO>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetName([FromBody] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var studentName = await _studentService.GetStudentByNameAsync(name);
            if (studentName is null)
                return NotFound();
            return Ok(studentName);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (studentDTO is null)
                return BadRequest("Data Invalid!!");
            await _studentService.CreateAsync(studentDTO);
            return new CreatedAtRouteResult("GetStudents", new { id = studentDTO.Id }, studentDTO);
        }

        [HttpPut("id")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Put(int id, [FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != studentDTO.Id)
                return BadRequest();
            await _studentService.UpdateAsync(studentDTO);
            return Ok(studentDTO);
        }

        [HttpDelete("id")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var studentDelete = await _studentService.GetByIdAsync(id);
            if (studentDelete == null)
                return NotFound();
            await _studentService.Remove(id);
            return Ok(studentDelete);
        }

    }
}
