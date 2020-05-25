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
        public ObservableCollection<Student> ListOfStudents { get; set; }
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> QuestionList { get; set; }
        public ObservableCollection<Exam> _examList
        {
            get { return ExamList; }
            set { ExamList = value; }
        }

        public ObservableCollection<Question> _questionList
        {
            get { return QuestionList; }
            set { QuestionList = value; }
        }
        public ObservableCollection<Student> _listOfStudents
        {
            get { return ListOfStudents; }
            set { ListOfStudents = value; }
        }

        public List<string> alternatives = new List<string>();
        public List<int> correctAnswers = new List<int>();

        public StudentProfileViewModel()
        {
            //_command = new RelayCommand(blablalbalbal);
            alternatives.Add("a");
            alternatives.Add("b");
            alternatives.Add("c");
            alternatives.Add("d");

            correctAnswers.Add(1);

            //Creating lists of Questions/Exams and Students
            _questionList = new ObservableCollection<Question>()
            {
                new Question(correctAnswers, alternatives, 5, "which one holds a?")
            };

            _examList = new ObservableCollection<Exam>()
            {
                new Exam("Mathematics", _questionList.ToList(),"Math 5c",DateTime.Now,50)
            };
            _listOfStudents = new ObservableCollection<Student>()
            {
                new Student(_examList, "Peter", "Petersson", "PeterPetersson", "Petersson123", false)
            };

        }
        public void SeeResults()
        {
        }
    }
}
