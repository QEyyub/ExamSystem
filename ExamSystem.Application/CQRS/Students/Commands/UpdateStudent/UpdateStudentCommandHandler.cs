using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Number == request.Number, cancellationToken);

            if (student == null)
                return false;

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Class = request.Class;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
