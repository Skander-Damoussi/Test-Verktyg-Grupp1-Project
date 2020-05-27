using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Answer
    {
        public string AnswerTitle { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int CorrectAnswer { get; set; } //Added this so that the field works in createExam.xaml, just a boolean is simply not enough.
    }
}
