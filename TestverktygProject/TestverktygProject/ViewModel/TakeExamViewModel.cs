using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using Windows.Networking.Sockets;

namespace TestverktygProject.ViewModel
{
    public class TakeExamViewModel
    {
        public ObservableCollection<Question> questions = new ObservableCollection<Question>();
        public List<string> alternatives = new List<string>();
        public List<int> correctanswer = new List<int>();
        public Question q1;
        public ObservableCollection<Question> _questions
        {
            get { return questions; }
            set { questions = value; }
        }
        public TakeExamViewModel()
        {
            alternatives.Add("1");
            alternatives.Add("2");
            alternatives.Add("4");
            alternatives.Add("5");

            correctanswer.Add(2);

            _questions = new ObservableCollection<Question>()
            {
                new Question(correctanswer, alternatives, 3, "What is 1 + 1"),
                new Question(correctanswer, alternatives, 3, "What is 1 + 2"),
                new Question(correctanswer, alternatives, 3, "What is 1 + 3"),
                new Question(correctanswer, alternatives, 3, "What is 1 + 4"),
            };
        }
        
        public void TakeExam()
        {
        }
        public void Questionsleft()
        {
        }
    }
}
