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
        public ObservableCollection<Student> apiStudents { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Teacher> apiTeachers { get; set; }
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
        }
    }
}
