using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}
