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
        public int StudentID { get; set; }
        public ObservableCollection<Exam> ListExam { get; set; }


        public Student(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
            
    }   

}
