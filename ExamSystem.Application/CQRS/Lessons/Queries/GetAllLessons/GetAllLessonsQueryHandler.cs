using ExamSystem.Application.CQRS.Lessons.DTOs;
using ExamSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Queries.GetAllLessons
{
    public class GetAllLessonsQueryHandler : IRequestHandler<GetAllLessonsQuery, List<LessonDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLessonsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonDto>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Lessons
                .Select(l => new LessonDto
                {
                    Code = l.Code,
                    Name = l.Name,
                    Class = l.Class,
                    TeacherFirstName = l.TeacherFirstName,
                    TeacherLastName = l.TeacherLastName
                })
                .ToListAsync(cancellationToken);
        }
    }
}
