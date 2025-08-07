using ExamSystem.Application.Interfaces;
using ExamSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Number = request.Number,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Class = request.Class
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
