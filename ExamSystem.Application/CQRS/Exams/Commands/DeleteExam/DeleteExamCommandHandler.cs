using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.DeleteExam
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams
                .FirstOrDefaultAsync(e => e.LessonCode == request.LessonCode && e.StudentNumber == request.StudentNumber, cancellationToken);

            if (exam == null)
                return false;

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
