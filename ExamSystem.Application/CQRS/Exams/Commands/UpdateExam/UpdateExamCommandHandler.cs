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
                .FirstOrDefaultAsync(e => e.LessonCode == request.LessonCode && e.StudentNumber == request.StudentNumber, cancellationToken);

            if (exam == null)
                return false;

            exam.ExamDate = request.ExamDate;
            exam.Class = request.Class;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
