using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.DTOs
{
    public class ExamDto
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
        public string LessonName { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

    }
}
