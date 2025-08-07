using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Number { get; set; }
    }
}
