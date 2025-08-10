using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.UpdateExam
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams
                .FirstOrDefaultAsync(e => e.LessonCode == request.OldLessonCode &&
                                          e.StudentNumber == request.OldStudentNumber, cancellationToken);

            if (exam == null)
                return false;

            var lessonExists = await _context.Lessons
                .AnyAsync(l => l.Code == request.LessonCode, cancellationToken);
            if (!lessonExists)
                throw new Exception("Lesson tapılmadı!");

            var studentExists = await _context.Students
                .AnyAsync(s => s.Number == request.StudentNumber, cancellationToken);
            if (!studentExists)
                throw new Exception("Student tapılmadı!");

            exam.LessonCode = request.LessonCode;
            exam.StudentNumber = request.StudentNumber;
            exam.ExamDate = request.ExamDate;
            exam.Grade = request.Grade;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
