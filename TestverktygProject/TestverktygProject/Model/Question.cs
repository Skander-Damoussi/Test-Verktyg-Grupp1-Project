using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Question
    {
        public List<int> CorrectAnswer { get; set; }
        public List<string> Alternatives { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionValue { get; set; }
    }
}
