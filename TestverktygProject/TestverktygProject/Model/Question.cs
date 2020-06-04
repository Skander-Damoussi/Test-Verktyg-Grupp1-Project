using System.Collections.Generic;

namespace TestverktygProject.Model
{
    public class Question
    {
        public Question()
        {

        }
        public int CorrectAnswer { get; set; }
        public List<string> Alternatives { get; set; } = new List<string>{"", "", "", ""};
        public string Alt1 { get; set; }
        public string Alt2 { get; set; }
        public string Alt3 { get; set; }
        public string Alt4 { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }

        public Question(int correctanswer, List<string> alternative, int numberofpoints, string questiontitle)
        {
            CorrectAnswer = correctanswer;
            Alternatives = alternative;
            NumberOfPoints = numberofpoints;
            QuestionTitle = questiontitle;
        }

  
    }
}
