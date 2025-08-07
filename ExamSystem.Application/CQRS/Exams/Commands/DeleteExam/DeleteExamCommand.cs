using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.DeleteExam
{
    public class DeleteExamCommand : IRequest<bool>
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
    }
}
