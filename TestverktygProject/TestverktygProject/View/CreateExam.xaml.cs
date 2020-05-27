using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        private async void CreateExamButton_OnClick(object sender, RoutedEventArgs e)
        {
            var exams = CreateExamViewModel.ExamList;
            var questions = CreateExamViewModel.CreatedQuestions.ToList();
            var exam = new Exam
            { 
                ExamDate = DateTime.Today, //todo check how to insert DatePicker values here
                ExamName = TitleOfExamField.Text,
                Questions = questions,
                Subject = SubjectField.Text,
                Results = 0
            };

            exams.Add(exam);

          await CreateExamViewModel.AddExamAsync(exam);
        }

        private void SubmitQuestionButton_OnClick(object sender, RoutedEventArgs e)
        {
            var questions = CreateExamViewModel.QuestionsToBeFilled;
            var examPreview = CreateExamViewModel.CreatedQuestions;
            var points = CreateExamViewModel.QuestionsToBeFilled[0].NumberOfPoints;
            examPreview.Clear();
            
            foreach (Question q in questions)
            {
                CheckRightAnswer();
                q.NumberOfPoints = points;
                CreateExamViewModel.CreatedQuestions.Add(q);
            }

        }

        public List<Question> GetQuestions()
        {
            var questions = CreateExamViewModel.CreatedQuestions;
            List<Question> listOfQuestions = new List<Question>();

            foreach (Question q in questions)
            {
                listOfQuestions.Add(q);
            }

            return listOfQuestions;
        }

        public async void GetAllExams()
        {
            var exams = await CreateExamViewModel.GetAllExamsAsync();

            foreach (Exam exam in exams)
            {
                CreateExamViewModel.ExamList.Add(exam);
            }
        }

        public void CheckRightAnswer()
        {
            var rightAnswer = CreateExamViewModel.QuestionsToBeFilled[0].Alternatives[0].CorrectAnswer.ToString();
            var answers = CreateExamViewModel.QuestionsToBeFilled[0].Alternatives;

            switch (rightAnswer)
            {
                case "1":
                    answers[0].IsCorrectAnswer = true;
                    answers[1].IsCorrectAnswer = false;
                    answers[2].IsCorrectAnswer = false;
                    answers[3].IsCorrectAnswer = false;
                    break;
                case "2":
                    answers[0].IsCorrectAnswer = false;
                    answers[1].IsCorrectAnswer = true;
                    answers[2].IsCorrectAnswer = false;
                    answers[3].IsCorrectAnswer = false;
                    break;
                case "3":
                    answers[0].IsCorrectAnswer = false;
                    answers[1].IsCorrectAnswer = false;
                    answers[2].IsCorrectAnswer = true;
                    answers[3].IsCorrectAnswer = false;
                    break;
                case "4":
                    answers[0].IsCorrectAnswer = false;
                    answers[1].IsCorrectAnswer = false;
                    answers[2].IsCorrectAnswer = false;
                    answers[3].IsCorrectAnswer = true;
                    break;

            }
        }
    }
}
