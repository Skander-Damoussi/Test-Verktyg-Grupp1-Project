using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class StudentProfileViewModel
    {
        public ObservableCollection<StudentExam> apiStudentExams { get; set; }

        public ICommand _command { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Student> apiStudents { get; set; }
        public ObservableCollection<Exam> _apiExams
        {
            get { return apiExams; }
            set { apiExams = value; }
        }
        public ObservableCollection<Student> _apiStudents
        {
            get { return apiStudents; }
            set { apiStudents = value; }
        }
        public StudentProfileViewModel()
        {
            _apiExams = new ObservableCollection<Exam>();
            _apiStudents = new ObservableCollection<Student>();
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
