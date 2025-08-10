using ExamSystem.Application.CQRS.Lessons.Commands.CreateLesson;
using ExamSystem.Application.CQRS.Lessons.Commands.DeleteLesson;
using ExamSystem.Application.CQRS.Lessons.Commands.UpdateLesson;
using ExamSystem.Application.CQRS.Lessons.Queries.GetAllLessons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Dərs yaradıldı") : BadRequest("Dərs yaratmaq mümkün olmadı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLessonsQuery());
            return Ok(result);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest("Dərs kodu boş ola bilməz.");

            var result = await _mediator.Send(new DeleteLessonCommand { Code = code });
            return result ? Ok("Dərs silindi") : NotFound("Dərs tapılmadı");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLessonCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.Code))
                return BadRequest("Dərs məlumatları və kodu mütləqdir.");

            var result = await _mediator.Send(command);
            return result ? Ok("Dərs yeniləndi") : NotFound("Dərs tapılmadı");
        }

        [HttpGet("codes")]
        public async Task<IActionResult> GetLessonCodes()
        {
            var lessons = await _mediator.Send(new GetAllLessonsQuery());
            var codes = lessons.Select(l => l.Code).ToList();
            return Ok(codes);
        }
    }
}
