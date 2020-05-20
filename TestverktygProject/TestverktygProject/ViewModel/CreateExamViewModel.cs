using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestverktygProject.Model;
using TestverktygProject.View;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> QuestionsToBeFilled { get; set; }
        public ObservableCollection<Question> CreatedQuestions { get; set; }
        public Question Question { get; set; }
        public Exam Exam { get; set; }
        public string TB { get; set; }

        public ICommand SearchBusCommand { get; }

        public string SearchText { get; set; }


        //Perhaps need to move below properties to viewmodel constructor.
        public List<string> Alternatives { get; set; }
        public CreateExamViewModel()
        {
            ExamList = new ObservableCollection<Exam>();
            QuestionsToBeFilled = new ObservableCollection<Question>();
            CreatedQuestions = new ObservableCollection<Question>();
            Alternatives = new List<string>();
        }
    }
}
