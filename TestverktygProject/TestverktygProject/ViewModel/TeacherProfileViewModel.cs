using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class TeacherProfileViewModel
    {
        public ObservableCollection<Exam> MockupTest { get; set; }
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Student> StudentList { get; set; }
        public ObservableCollection<Student> _studentList
        {
            get { return StudentList; }
            set { StudentList = value; }
        }
        public ObservableCollection<Teacher> TeacherList { get; set; }
        public ObservableCollection<Teacher> _teacherList
        {
            get { return TeacherList; }
            set { TeacherList = value; }
        }

        public ObservableCollection<Exam> _mockupTest
        {
            get { return MockupTest; }
            set { MockupTest = value; }
        }

        public TeacherProfileViewModel() 
        {
            StudentList = new ObservableCollection<Student>()
           {
               new Student(1,MockupTest, "david", "sten", "davidsten", "davidsten1234", false)
           };
            MockupTest = new ObservableCollection<Exam>()
            {
                new Exam(1, "math", "math 3c", DateTime.Now, "55/10")
            };
            TeacherList = new ObservableCollection<Teacher>()
            {
                new Teacher(1, "johan", "johansson", "johanjohansson", "johanjohansson1234", true)
            };
        }
       




        public Student Student { get; set; }

        public void SeeResults()
        {

        }



        public void ListOfStudents()
        {





         //   student.ListExam = new ObservableCollection<Exam>();



            //    StudentList.Add(new Student (" David", " Sten"){StudentID = 1} );

            //Student student = new Student(" testar", " testsson");
            //
            //student.ListExam.Add(new Exam { ExamDate = new DateTime().Date });
            //StudentList.Add(student);

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
