using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string Subject { get; set; }
        public List<Question> Questions { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string Results { get; set; }
        public IList<StudentExam> StudentExam { get; set; }
    }
}
