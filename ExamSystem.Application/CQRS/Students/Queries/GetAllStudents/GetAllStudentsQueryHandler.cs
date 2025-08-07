using ExamSystem.Application.CQRS.Students.DTOs;
using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                .Select(s => new StudentDto
                {
                    Number = s.Number,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Class = s.Class
                })
                .ToListAsync(cancellationToken);
        }
    }
}
