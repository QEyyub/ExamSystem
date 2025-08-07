using ExamSystem.Application.Core;
using ExamSystem.Application.Interfaces;
using ExamSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.CreateExam
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ApiResult>
    {
        private readonly IApplicationDbContext _context;

        public CreateExamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = new Exam
            {
                LessonCode = request.LessonCode,
                StudentNumber = request.StudentNumber,
                ExamDate = request.ExamDate,
                Class = request.Class
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync(cancellationToken);

            return ApiResult.SuccessResult("İmtahan əlavə edildi.");
        }
    }

}
