using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(l => l.Code == request.Code, cancellationToken);

            if (lesson == null)
                return false;

            lesson.Name = request.Name;
            lesson.Class = request.Class;
            lesson.TeacherFirstName = request.TeacherFirstName;
            lesson.TeacherLastName = request.TeacherLastName;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
