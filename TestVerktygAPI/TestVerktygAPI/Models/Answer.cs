using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerTitle { get; set; }
        public bool CorrectAnswer { get; set; }
    }
}
