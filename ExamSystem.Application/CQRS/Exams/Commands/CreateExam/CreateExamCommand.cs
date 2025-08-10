﻿using ExamSystem.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.CQRS.Exams.Commands.CreateExam
{
    public class CreateExamCommand : IRequest<ApiResult>
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
    }

}
