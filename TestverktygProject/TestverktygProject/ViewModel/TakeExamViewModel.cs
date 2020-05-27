using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.View;
using Windows.Networking.Sockets;

namespace TestverktygProject.ViewModel
{
    public class TakeExamViewModel
    {
        public int index = 0;
        public int startindex = 1;
        public ObservableCollection<Question> tempQuestList;
        public Exam tempExamList;
        public TakeExam V { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Exam> _apiExams
        {
            get { return apiExams; }
            set { apiExams = value; }
        }
        public TakeExamViewModel()
        {
            this.V = new TakeExam();
        }                
    }
}
