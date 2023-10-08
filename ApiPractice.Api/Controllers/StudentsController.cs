using ApiPractice.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using ApiPractice.Domain.Entities;
using ApiPractice.Service;
using AutoMapper;

namespace ApiPractice.Api.Controllers
{
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet("students")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudents()
        {
            var students = await _studentService.GetStudents();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_mapper.Map<IEnumerable<StudentResponse>>(students));
        }

        [HttpGet("students/{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<StudentResponse>> GetStudent(string id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null) return NotFound("Student not found!");
            return Ok(_mapper.Map<StudentResponse>(student));
        }
        
        [HttpPut("student/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateStudent(string id, StudentResponse student)
        {
            if (id != student.StudentId)
            {
                return BadRequest("Student's id does not match!");
            }

            if (student == null) return BadRequest("Student is empty!");
            // More validation
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.FirstName)
                                                        || string.IsNullOrEmpty(student.Email))
            {
                return BadRequest("Field must not be empty!");
            }

            var mappedStudent = _mapper.Map<Student>(student);
            var result = await _studentService.UpdateStudent(mappedStudent);
            if (!result) return BadRequest("An error occurred while updating student!");
            return NoContent();
        }
        
        [HttpPost("student")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<StudentResponse>> CreateStudent(StudentResponse student)
        {
            if (student == null) return BadRequest("Student is empty!");
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.FirstName)
                                                        || string.IsNullOrEmpty(student.Email))
            {
                return BadRequest("Field must not be empty!");
            }

            var existingStudent = await _studentService.GetStudent(student.StudentId);
            if (existingStudent != null) return BadRequest("Student already exists!");
            
            var mappedStudent = _mapper.Map<Student>(student);
            var result = await _studentService.AddStudent(mappedStudent);
            if (!result) return BadRequest("An error occurred while creating student!");
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        [HttpDelete("student/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null) return NotFound("Student not found!");
            var result = await _studentService.RemoveStudent(student);
            if (!result) return BadRequest("Student could not be deleted!");
            return NoContent();
        }
    }
}
