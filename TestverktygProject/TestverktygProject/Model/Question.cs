using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TestverktygProject.Model
{
    public class Question
    {
        public List<int> CorrectAnswer { get; set; } = new List<int>();
        public List<string> Alternatives { get; set; } = new List<string>();
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }

        public Question(List<int> correctanswer, List<string> alternative, int numberofpoints, string questiontitle)
        {
            CorrectAnswer = correctanswer;
            Alternatives = alternative;
            NumberOfPoints = numberofpoints;
            QuestionTitle = questiontitle;
        }

        public Question()
        {

        }
    }
}
