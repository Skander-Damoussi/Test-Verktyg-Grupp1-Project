using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class StudentExam
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
    }
}
