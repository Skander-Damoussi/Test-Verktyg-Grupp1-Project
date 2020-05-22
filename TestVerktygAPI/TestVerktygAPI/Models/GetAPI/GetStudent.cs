using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models.GetAPI
{
    public class GetStudent
    {
        public int StudentID { get; set; }
        public ObservableCollection<Exam> ListExam { get; set; }
    }
}
