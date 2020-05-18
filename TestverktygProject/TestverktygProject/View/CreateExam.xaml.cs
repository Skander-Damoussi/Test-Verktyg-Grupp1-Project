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
        public CreateExamViewModel CreateExamViewModel { get; set; }
        public CreateExam()
        {
            this.InitializeComponent();
            CreateExamViewModel = new CreateExamViewModel();
            this.DataContext = CreateExamViewModel.Questions;
            //QuestionTitleFieldCreated.Text = TitleOfQuestion.Text;
        }

        private void BeforeCreationOfExamInfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int NumberOfQuestionsToGenerate = Int32.Parse(NumberOfQuestionsToGenerateField.Text);

            for (int i = 0; i < NumberOfQuestionsToGenerate; i++)
            {
                listOfQuestions.Add(new Question());
                //TODO create number of questions here in xaml
            }
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
            List<string> alternatives = new List<string>();
            List<int> RightAnswer = new List<int>();

            /*alternatives.Add(Alt1.Text);
            alternatives.Add(Alt2.Text);
            alternatives.Add(Alt3.Text);
            alternatives.Add(Alt4.Text);

            RightAnswer.Add(Int32.Parse(CorrectAnswerField.Text));*/

            Question question = new Question
            {
                Alternatives = alternatives,
                CorrectAnswer = RightAnswer,
                NumberOfPoints = 1,
                QuestionTitle = "Some Question"
                //TODO edit number of points so that the teacher decides the point per question
            };
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
