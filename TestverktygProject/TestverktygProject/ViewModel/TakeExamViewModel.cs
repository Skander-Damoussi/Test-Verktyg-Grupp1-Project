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
        public int index = 0;
        public int startindex = 1;
        public Question temp;

        public ObservableCollection<Question> questions = new ObservableCollection<Question>();
        public List<string> alternatives1 = new List<string>();
        public List<string> alternatives2 = new List<string>();
        public List<string> alternatives3 = new List<string>();
        public List<string> alternatives4 = new List<string>();
        public List<int> correctanswer = new List<int>();

        public ObservableCollection<Question> tempQuest = new ObservableCollection<Question>();
        public ObservableCollection<Question> _questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public ObservableCollection<Question> _tempquest
        {
            get { return tempQuest; }
            set { tempQuest = value; }
        }

        public TakeExamViewModel()
        {
            alternatives1.Add("1");
            alternatives1.Add("2");
            alternatives1.Add("4");
            alternatives1.Add("5");

            alternatives2.Add("20");
            alternatives2.Add("40");
            alternatives2.Add("3");
            alternatives2.Add("9");

            alternatives3.Add("100");
            alternatives3.Add("200");
            alternatives3.Add("4");
            alternatives3.Add("400");

            alternatives4.Add("1000");
            alternatives4.Add("2000");
            alternatives4.Add("5");
            alternatives4.Add("5000");

            correctanswer.Add(2);

           /* _questions = new ObservableCollection<Question>()
            {
                new Question(correctanswer, alternatives1, 3, "Question 1 What is 1 + 1"),
                new Question(correctanswer, alternatives2, 3, "Question 2 What is 1 + 2"),
                new Question(correctanswer, alternatives3, 3, "Question 3 What is 1 + 3"),
                new Question(correctanswer, alternatives4, 3, "Question 4 What is 1 + 4"),
            };*/
        }
        
        public void TakeExam()
        {
        }
        public void Questionsleft()
        {
        }
        public void nextQuestion()
        {
            if (index <= questions.Count)
            {                
                index++;
                startindex++;
                temp = questions[index];

                updateAlternatives();
            }
            else
            {
            }
        }
        public void prevQuestion()
        {
            if (index <= questions.Count || index >= 1)
            {
                index--;
                startindex--;
                temp = questions[index];

                updateAlternatives();
            }
            else
            {
            }
        }
        public void updateAlternatives()
        {
            tempQuest.Clear();
            tempQuest.Add(questions[index]);
        }
    }
}
