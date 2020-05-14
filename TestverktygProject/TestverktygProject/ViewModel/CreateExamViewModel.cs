using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public void CreateExam()
        {
        }
    }
}
