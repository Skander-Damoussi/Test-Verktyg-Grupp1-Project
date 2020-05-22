using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Student : User
    {
        public int StudentID { get; set; }
        public List<Exam> ListExam { get; set; }
        public IList<StudentExam> StudentExam { get; set; }
    }
}
