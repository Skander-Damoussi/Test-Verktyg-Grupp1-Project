using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class StudentExam
    {
        public StudentExam() { }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
