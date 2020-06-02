using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class TakeExamPage
    {
        public TakeExamPage() { }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public TakeExamPage(Student student, Exam exam)
        {
            Student = student;
            Exam = exam;
        }
    }
}
