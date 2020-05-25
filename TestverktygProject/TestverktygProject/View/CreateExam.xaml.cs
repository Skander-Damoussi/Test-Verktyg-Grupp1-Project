using System;
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
            var exams = CreateExamViewModel.ExamList;
            var exam = new Exam
            { 
                ExamDate = DatePicker.Date.DateTime,
                ExamName = TitleOfExamField.Text,
                Questions = GetQuestions(),
                Subject = SubjectField.Text,
                Results = 0
            };

            exams.Add(exam);
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
    }
}
