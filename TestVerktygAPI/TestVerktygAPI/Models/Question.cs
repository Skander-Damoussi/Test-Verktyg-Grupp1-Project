using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string Alt1 { get; set; }
        public string Alt2 { get; set; }
        public string Alt3 { get; set; }
        public string Alt4 { get; set; }
        public int NumberOfPoints { get; set; }
        public string QuestionTitle { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
