using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public string Code { get; set; }
    }
}
