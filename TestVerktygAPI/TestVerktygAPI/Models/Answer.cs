using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public string AnswerTitle { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int CorrectAnswer { get; set; }
    }
}
