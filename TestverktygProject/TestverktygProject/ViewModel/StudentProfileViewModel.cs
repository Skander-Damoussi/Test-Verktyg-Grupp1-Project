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

    }
}
