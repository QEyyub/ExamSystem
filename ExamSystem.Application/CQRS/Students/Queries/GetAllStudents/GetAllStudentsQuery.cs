using ExamSystem.Application.CQRS.Students.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentDto>> { }

}
