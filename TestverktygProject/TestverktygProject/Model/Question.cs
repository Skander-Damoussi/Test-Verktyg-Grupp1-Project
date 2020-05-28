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
        public List<Answer> Alternatives { get; set; } = new List<Answer>{new Answer(), new Answer(), new Answer(), new Answer()};
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
        public int CorrectAnswer { get; set; } //Added this so that the field works in createExam.xaml, just a boolean is simply not enough.

        public Question( List<Answer> answers, int numberofpoints, string questiontitle)
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