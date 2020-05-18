using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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
        private List<Question> listOfQuestions;
        private List<Exam> listOfExams;

        List<string> alternatives = new List<string>();
        List<int> RightAnswer = new List<int>();
        private Question[] qArrayQuestions = new Question[3];

        public CreateExamViewModel CreateExamViewModel { get; set; }
        public CreateExam()
        {
            this.InitializeComponent();
            CreateExamViewModel = new CreateExamViewModel();
            this.DataContext = CreateExamViewModel.Questions;
            //QuestionTitleFieldCreated.Text = TitleOfQuestion.Text;
            CreatedQuestionsListView.ItemsSource = CreateExamViewModel.Questions;
        }

        private void BeforeCreationOfExamInfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int NumberOfQuestionsToGenerate = Int32.Parse(NumberOfQuestionsToGenerateField.Text);
            
        }

        private void CreateExamButton_OnClick(object sender, RoutedEventArgs e)
        {
            Exam exam = new Exam
            {
                ExamDate = DateTime.Today,
                ExamName = TitleOfExam.Text,
                Questions = GetQuestions(),
                Subject = SubjectField.Text
            };
        }

        private void SubmitQuestionButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            alternatives.Add(Alt1.Text);
            alternatives.Add(Alt2.Text);
            alternatives.Add(Alt3.Text);
            alternatives.Add(Alt4.Text);

            opt1.Content = Alt1.Text;
            opt2.Content = Alt2.Text;
            opt3.Content = Alt3.Text;
            opt4.Content = Alt4.Text;

            RightAnswer.Add(Int32.Parse(CorrectAnswerField.Text));

            Question question = new Question
            {
                Alternatives = alternatives,
                CorrectAnswer = RightAnswer,
                NumberOfPoints = 1,
                QuestionTitle = TitleOfQuestion.Text
                //TODO edit number of points so that the teacher decides the point per question
            };
            List<Question> questionsList = new List<Question>();
            questionsList.Add(question);

            //listOfQuestions.Add(question);

            foreach (Question q in questionsList)
            {
                CreateExamViewModel.Questions.Add(q);
            }
        }

        public List<Question> GetQuestions()
        {
            return listOfQuestions;
        }

        public List<Exam> GetExams()
        {
            return listOfExams;
        }
    }
}
