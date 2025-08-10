using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Domain.Entities
{
    public class Lesson
    {
        [Key]
        [StringLength(3)]
        public string Code { get; set; } 

        [Required]
        [StringLength(30)]
        public string Name { get; set; } 

        [Range(1, 11)]
        public int Class { get; set; }

        [Required]
        [StringLength(20)]
        public string TeacherFirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string TeacherLastName { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }

}
