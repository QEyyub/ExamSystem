using ExamSystem.Application.CQRS.Students.Commands.CreateStudent;
using ExamSystem.Application.CQRS.Students.Commands.DeleteStudent;
using ExamSystem.Application.CQRS.Students.Commands.UpdateStudent;
using ExamSystem.Application.CQRS.Students.Queries.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Tələbə yaradıldı") : BadRequest("Tələbə yaratmaq mümkün olmadı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        [HttpDelete("{number}")]
        public async Task<IActionResult> Delete(int number)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { Number = number });
            return result ? Ok("Tələbə silindi") : NotFound("Tələbə tapılmadı");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Tələbə tapılmadı");

            return Ok("Tələbə uğurla yeniləndi");
        }
    }
}
