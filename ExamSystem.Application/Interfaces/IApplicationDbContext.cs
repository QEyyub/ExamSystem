using ExamSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Exam> Exams { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
