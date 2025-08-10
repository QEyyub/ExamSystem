using MediatR;
using Microsoft.EntityFrameworkCore;
using ExamSystem.Application.Interfaces;
using ExamSystem.Application.CQRS.Exams.DTOs;

namespace ExamSystem.Application.CQRS.Exams.Queries.GetAllExams
{
    public class GetAllExamsQueryHandler : IRequestHandler<GetAllExamsQuery, List<ExamDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExamsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamDto>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            var exams = await _context.Exams
                .Include(e => e.Lesson)
                .Include(e => e.Student)
                .Select(e => new ExamDto
                {
                    LessonCode = e.LessonCode,
                    StudentNumber = e.StudentNumber,
                    ExamDate = e.ExamDate,
                    Grade = e.Grade,
                    LessonName = e.Lesson.Name,
                    StudentName = e.Student.FirstName,
                    StudentSurname = e.Student.LastName
                })
                .ToListAsync(cancellationToken);

            return exams;
        }
    }
}
