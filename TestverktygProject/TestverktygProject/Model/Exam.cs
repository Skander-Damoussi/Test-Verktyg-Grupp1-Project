﻿using System;
using System.Collections.Generic;

namespace TestverktygProject.Model
{
    public class Exam
    {
        public string Subject { get; set; }
        public List<Question> Questions { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int Results { get; set; }

        public Exam(string subject, List<Question> questions, string examName, DateTime examDate, int results)
        {
            Subject = subject;
            Questions = questions;
            ExamName = examName;
            ExamDate = examDate;
            Results = results;
        }
        public Exam()
        {
        }
    }
}
