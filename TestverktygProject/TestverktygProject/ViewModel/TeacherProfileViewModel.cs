using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class TeacherProfileViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Student> StudentList { get; set; } 

        public void SeeResults()
        {
           
        }

        public void ListOfStudents()
        {
            StudentList = new ObservableCollection<Student>();
            StudentList.Add(new Student (" David", " Sten"){StudentID = 1});
        }

 

    }
}
