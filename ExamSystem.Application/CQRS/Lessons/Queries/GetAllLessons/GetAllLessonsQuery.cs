using ExamSystem.Application.CQRS.Lessons.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Lessons.Queries.GetAllLessons
{
    public class GetAllLessonsQuery : IRequest<List<LessonDto>> { }

}
