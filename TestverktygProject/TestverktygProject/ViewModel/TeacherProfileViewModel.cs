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

        public Student Student { get; set; }

        public void SeeResults()
        {

        }

        public void ListOfStudents()
        {
            StudentList = new ObservableCollection<Student>();
            //    StudentList.Add(new Student (" David", " Sten"){StudentID = 1} );

            Student student = new Student(" testar", " testsson");
            student.ListExam = new ObservableCollection<Exam>();
            student.ListExam.Add(new Exam { ExamDate = new DateTime().Date });
            StudentList.Add(student);
        }

        //public void ListOfExams()
        //{
        //    ExamList = new ObservableCollection<Exam>();
        //    ExamList.Add(new Exam { ExamDate = new DateTime().Date });
        //}

        //public void ReadMethod(object obj)
        //{
        //    Student = obj as Student;
        //}

    }
}
