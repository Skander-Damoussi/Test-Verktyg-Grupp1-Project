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
        public List<int> CorrectAnswer { get; set; }
        public List<string> Alternatives { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
        public TextBox Alternative1 { get; set; }

        public Question(List<int> correctanswer, List<string> alternative, int numberofpoints, string questiontitle, TextBox alternative1)
        {
            CorrectAnswer = correctanswer;
            Alternatives = alternative;
            NumberOfPoints = numberofpoints;
            QuestionTitle = questiontitle;
            Alternative1 = alternative1;
        }

        public Question()
        {

        }
    }
}
