using ExamSystem.Application.CQRS.Exams.Commands.CreateExam;
using ExamSystem.Application.CQRS.Exams.Commands.DeleteExam;
using ExamSystem.Application.CQRS.Exams.Commands.UpdateExam;
using ExamSystem.Application.CQRS.Exams.DTOs;
using ExamSystem.Application.CQRS.Exams.Queries;
using ExamSystem.Application.CQRS.Exams.Queries.GetAllExams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamDto>>> GetAll()
        {
            var exams = await _mediator.Send(new GetAllExamsQuery());
            return Ok(exams);
        }

        [HttpPut("{lessonCode}/{studentNumber}")]
        public async Task<IActionResult> Update(string lessonCode, int studentNumber, [FromBody] UpdateExamCommand command)
        {
            command.OldLessonCode = lessonCode;
            command.OldStudentNumber = studentNumber;

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("İmtahan tapılmadı");

            return Ok("İmtahan uğurla yeniləndi");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string lessonCode, [FromQuery] int studentNumber)
        {
            var command = new DeleteExamCommand
            {
                LessonCode = lessonCode,
                StudentNumber = studentNumber
            };

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("İmtahan tapılmadı");

            return Ok("İmtahan uğurla silindi");
        }
    }
}
