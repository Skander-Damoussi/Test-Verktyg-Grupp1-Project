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
        //declaration of new answer is needed to avoid getting null reference exceptions
        public List<string> Alternatives { get; set; } = new List<string>{"", "", "", ""};
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }

        public Question( List<string> answers, int numberofpoints, string questiontitle)
        {
            Alternatives = answers;
            NumberOfPoints = numberofpoints;
            QuestionTitle = questiontitle;
        }

        public Question()
        {

        }
    }
}