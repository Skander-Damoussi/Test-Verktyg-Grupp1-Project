using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string Subject { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
    }
}
