using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Question
    {
        public List<int> CorrectAnswer { get; set; }
        public List<string> Alternatives { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
    }
}
