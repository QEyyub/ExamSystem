using ExamSystem.Domain.Entities;
using ExamSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamSystem.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            var random = new Random();

            var lessonNames = new[] { "Riyaziyyat", "Fizika", "Kimya", "Biologiya", "Azərbaycan dili", "Tarix", "Coğrafiya", "İngilis dili", "Ədəbiyyat", "İnformatika" };
            var teacherFirstNames = new[] { "Aysel", "Rauf", "Elçin", "Zülfiyyə", "Kamran", "Lalə", "Murad", "Ramil", "Səbinə", "Vüsal" };
            var teacherLastNames = new[] { "Quliyeva", "Hüseynov", "Əliyev", "Məmmədova", "Ələkbərov", "Süleymanov", "İsmayılov", "Səfərov", "Xəlilova", "Məmmədov" };

            var studentFirstNames = new[] { "Nurlan", "Aylin", "Murad", "Zəhra", "Elnur", "Rəna", "Cavid", "Turan", "Nigar", "Elvin" };
            var studentLastNames = new[] { "Hüseynov", "Qəhrəmanova", "Mustafayev", "Əlizadə", "Tağıyev", "İmanova", "Həsənov", "Cəfərov", "Orucova", "Baxşəliyev" };

            if (!context.Lessons.Any())
            {
                var lessons = new List<Lesson>();
                for (int i = 0; i < 10; i++)
                {
                    lessons.Add(new Lesson
                    {
                        Code = $"L{i + 1:D2}",
                        Name = lessonNames[i],
                        Class = random.Next(5, 11),
                        TeacherFirstName = teacherFirstNames[i],
                        TeacherLastName = teacherLastNames[i]
                    });
                }

                context.Lessons.AddRange(lessons);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                var students = new List<Student>();
                for (int i = 0; i < 10; i++)
                {
                    students.Add(new Student
                    {
                        Number = 10000 + i,
                        FirstName = studentFirstNames[i],
                        LastName = studentLastNames[i],
                        Class = random.Next(5, 11)
                    });
                }

                context.Students.AddRange(students);
                context.SaveChanges();
            }

            if (!context.Exams.Any())
            {
                var lessons = context.Lessons.ToList();
                var students = context.Students.ToList();
                var exams = new List<Exam>();

                for (int i = 0; i < 10; i++)
                {
                    var student = students[random.Next(students.Count)];
                    var lesson = lessons[random.Next(lessons.Count)];

                    exams.Add(new Exam
                    {
                        LessonCode = lesson.Code,
                        StudentNumber = student.Number,
                        ExamDate = DateTime.Now.AddDays(-random.Next(1, 100)),
                        Class = random.Next(0, 11)
                    });
                }

                context.Exams.AddRange(exams);
                context.SaveChanges();
            }
        }
    }
}
