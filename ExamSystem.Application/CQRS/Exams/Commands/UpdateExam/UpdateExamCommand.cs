using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.UpdateExam
{
    public class UpdateExamCommand : IRequest<bool>
    {
        // Köhnə
        public string OldLessonCode { get; set; }
        public int OldStudentNumber { get; set; }

        // Yeni
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
    }

}
