using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        public string Subject { get; set; }
        public List<Question> Questions { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int Results { get; set; }
        public IList<StudentExam> StudentExam { get; set; }
    }
}
