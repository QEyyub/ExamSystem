using ExamSystem.Application.CQRS.Exams.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Queries.GetAllExams
{
    public class GetAllExamsQuery : IRequest<List<ExamDto>>
    {
    }
}
