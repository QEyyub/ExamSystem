using ExamSystem.Application.Interfaces;
using ExamSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Commands.CreateLesson //Koda tekrar baxacam
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public CreateLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = new Lesson
            {
                Code = request.Code,
                Name = request.Name,
                Class = request.Class,
                TeacherFirstName = request.TeacherFirstName,
                TeacherLastName = request.TeacherLastName
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
