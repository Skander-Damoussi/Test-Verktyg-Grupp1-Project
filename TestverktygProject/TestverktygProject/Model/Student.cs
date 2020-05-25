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


        public Student(int studentId,ObservableCollection<Exam> listExam, string firstName, string lastName,string userName, string password,bool isTeacher)
        {
            StudentID = studentId;
            ListExam = listExam;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            IsTeacher = isTeacher;
        }
    }    
}
