using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TestverktygProject.Model;
using TestverktygProject.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestverktygProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateExam : Page
    {
        List<int> RightAnswer = new List<int>();

        public CreateExamViewModel CreateExamViewModel { get; set; }


        public CreateExam()
        {
            this.InitializeComponent();
            CreateExamViewModel = new CreateExamViewModel();
            this.DataContext = CreateExamViewModel;
            NotYetCreatedExamListView.ItemsSource = CreateExamViewModel.CreatedQuestions;
            SeeCreatedExamListView.ItemsSource = CreateExamViewModel.ExamList;


        }

        private void BeforeCreationOfExamInfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            var numberOfQuestionsToGenerate = int.Parse(NumberOfQuestionsToGenerateField.Text);
            var questions = CreateExamViewModel.QuestionsToBeFilled;
            var previewExam = CreateExamViewModel.CreatedQuestions;

            questions.Clear();
            previewExam.Clear();

            for (var i = 0; i < numberOfQuestionsToGenerate; i++)
            {
                CreateExamViewModel.QuestionsToBeFilled.Add(new Question());
                
            }

        }

        private void CreateExamButton_OnClick(object sender, RoutedEventArgs e)
        {
            var exam = new Exam
            {
                /*ExamID = ExamProperty.ExamID,
                ExamDate = ExamProperty.ExamDate,
                ExamName = ExamProperty.ExamName,
                Questions = ExamProperty.Questions,
                Subject = ExamProperty.Subject,
                Results = ExamProperty.Results*/
            };
        }

        private void SubmitQuestionButton_OnClick(object sender, RoutedEventArgs e)
        {
            var questions = CreateExamViewModel.QuestionsToBeFilled;
            var examPreview = CreateExamViewModel.CreatedQuestions;

            examPreview.Clear();

            foreach (Question q in questions)
            {
                CreateExamViewModel.CreatedQuestions.Add(q);
            }

        }
    }
}
