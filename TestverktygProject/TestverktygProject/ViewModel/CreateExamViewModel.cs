using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
        public Question Question { get; set; }
        public Exam Exam { get; set; }
        public void CreateExam()
        {
            ExamList = new ObservableCollection<Exam>();
            Questions = new ObservableCollection<Question>();

            Questions.Add(new Question
            {
                Alternatives = new List<string>{"1", "2", "3", "4"},
                CorrectAnswer = new List<int> { 1},
                NumberOfPoints = 1,
                QuestionTitle = "Title of Question",
                QuestionValue = "This is a question"
            });
        }
    }
}
