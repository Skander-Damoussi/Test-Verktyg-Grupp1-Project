using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Student : User
    {
        public Student() { }
        public Student(ObservableCollection<Exam> listExam, string firstName, string lastName, string userName, string password, bool isTeacher)
        {
            ListExam = listExam;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            IsTeacher = isTeacher;
        }
        public ObservableCollection<Exam> ListExam { get; set; }
        public int StudentID { get; set; }
        public IList<StudentExam> StudentExam { get; set; }
    }    
}
