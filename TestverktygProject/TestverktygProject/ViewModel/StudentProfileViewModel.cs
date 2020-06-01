using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestverktygProject.Model;
using TestverktygProject.Services;
using TestverktygProject.View;

namespace TestverktygProject.ViewModel
{
    public class StudentProfileViewModel
    {
        APIService api { get; set; }
        public Student tempstudent { get; set; }
        public ObservableCollection<Exam> listOfStudentsExams { get; set; }
        public ObservableCollection<StudentExam> apiStudentExams { get; set; }
        public ICommand _command { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Student> apiStudents { get; set; }
        public ObservableCollection<Exam> _listOfStudentsExams
        {
            get { return examstudentbind(tempstudent); }
            set { listOfStudentsExams = value; }
        }
        public ObservableCollection<StudentExam> _apiStudentExams
        {
            get { return Task.Run(async () => await api.GetAllStudentExamsAsync(tempstudent)).GetAwaiter().GetResult(); }
            set { apiStudentExams = value; }

        }
        public ObservableCollection<Exam> _apiExams
        {
            get { return Task.Run(async () => await api.GetAllExamsAsync()).GetAwaiter().GetResult(); }
            set { apiExams = value; }
        }
        public ObservableCollection<Student> _apiStudents
        {
            get { return apiStudents; }
            set { apiStudents = value; }
        }
        public StudentProfileViewModel()
        {
            api = new APIService();
            _apiExams = new ObservableCollection<Exam>();
            _apiStudents = new ObservableCollection<Student>();
        }
        public ObservableCollection<Exam> examstudentbind(Student student)
        {
            student.ListExam = new ObservableCollection<Exam>();

            foreach (StudentExam item in _apiStudentExams)
            {
                foreach (var exam in _apiExams)
                {
                    if (item.ExamID == exam.ExamID)
                    {
                        student.ListExam.Add(exam);
                    }
                }
            }
            return student.ListExam;
        }
    }
}
