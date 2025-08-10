using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Domain.Entities
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string LessonCode { get; set; }
        public Lesson Lesson { get; set; }

        [Required]
        public int StudentNumber { get; set; }
        public Student Student { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Range(0, 10)]
        public int Grade { get; set; } 
    }

}
