using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using TestverktygProject.Model;
using TestverktygProject.View;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> QuestionsToBeFilled { get; set; }
        public ObservableCollection<Question> CreatedQuestions { get; set; }
        
        public CreateExamViewModel()
        {
            ExamList = new ObservableCollection<Exam>();
            QuestionsToBeFilled = new ObservableCollection<Question>();
            CreatedQuestions = new ObservableCollection<Question>();
        }
    }
}
