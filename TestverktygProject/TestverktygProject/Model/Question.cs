using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Question
    {
        public Question(List<int> correctanswer, List<string> alternative, int numberofpoints, string questiontitle)
        {
            CorrectAnswer = correctanswer;
            Alternatives = alternative;
            NumberOfPoints = numberofpoints;
            QuestionTitle = questiontitle;
        }
        public List<int> CorrectAnswer { get; set; }
        public List<string> Alternatives { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
    }
}
