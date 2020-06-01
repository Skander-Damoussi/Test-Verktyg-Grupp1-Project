using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.Services;

namespace TestverktygProject.ViewModel
{
    
    public class TeacherProfileViewModel
    {
        APIService apicall = new APIService();
        public ObservableCollection<Student> apiStudents { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Teacher> apiTeachers { get; set; }
        public ObservableCollection<StudentExam> apiStudentExams { get; set; }
        public ObservableCollection<Student> _apiStudents
        {
            get { return apiStudents; }
            set { apiStudents = value; }
        }
        public ObservableCollection<Exam> _apiExams
        {
            get { return apiExams; }
            set { apiExams = value; }
        }
        public ObservableCollection<Teacher> _apiTeachers
        {
            get { return apiTeachers; }
            set { apiTeachers = value; }
        }

        public TeacherProfileViewModel()
        {
            _apiStudents = new ObservableCollection<Student>();
            _apiExams = new ObservableCollection<Exam>();
            _apiTeachers = new ObservableCollection<Teacher>();
            _apiStudentExams = new ObservableCollection<StudentExam>();
        }

        public ObservableCollection<StudentExam> _apiStudentExams
        {
            get { return apiStudentExams; }
            set { apiStudentExams = value; }
        }
        public async void apiGet()
        {
            var students = await apicall.GetAllStudentsAsync();
            foreach (Student student in students)
            {
                _apiStudents.Add(student);
            }

            var exams = await apicall.GetAllExamsAsync();

            foreach (Exam exam in exams)
            {
                _apiExams.Add(exam);
            }

            var teachers = await apicall.GetAllTeachersAsync();
            foreach (Teacher teacher in teachers)
            {
                _apiTeachers.Add(teacher);
            }

            var studentexam = await apicall.GetAllStudentExamsAsync();
            foreach (StudentExam item in studentexam)
            {
                _apiStudentExams.Add(item);
            }
        }

        public ObservableCollection<Exam> examstudentbind(Student student) 
        {
            student.ListExam = new ObservableCollection<Exam>();

            foreach (var item in apiStudentExams)
            {
                if (item.StudentID == student.StudentID)
                {
                    foreach (var exam in apiExams)
                    {
                        if (item.ExamID == exam.ExamID)
                        {
                            student.ListExam.Add(exam);
                        }
                    }
                }
            }
            return student.ListExam;
        }
    }

}
