using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
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
        private List<Question> listOfQuestions = new List<Question>();
        private List<Exam> listOfExams = new List<Exam>();

        List<string> alternatives = new List<string>();
        List<int> RightAnswer = new List<int>();

        public CreateExamViewModel CreateExamViewModel { get; set; }
        public CreateQuestionUC QuestionUC { get; set; }
        public Exam ExamProperty { get; set; }
        public Question QProp { get; set; }


        public CreateExam()
        {
            this.InitializeComponent();
            CreateExamViewModel = new CreateExamViewModel();
            this.DataContext = CreateExamViewModel;
            QuestionsToBeFilledListView.ItemsSource = CreateExamViewModel.QuestionsToBeFilled;
            NotYetCreatedExamListView.ItemsSource = CreateExamViewModel.CreatedQuestions;
            SeeCreatedExamListView.ItemsSource = CreateExamViewModel.ExamList;


        }

        private void BeforeCreationOfExamInfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int NumberOfQuestionsToGenerate = Int32.Parse(NumberOfQuestionsToGenerateField.Text);


            for (int i = 0; i < NumberOfQuestionsToGenerate; i++)
            {
                CreateExamViewModel.QuestionsToBeFilled.Add(new Question());
                
                /*CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "Title of question", Name = "TitleOfQuestion" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 1", Name = "Alt1" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 2", Name = "Alt2" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 3", Name = "Alt3" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 4", Name = "Alt3" });
                CreateQuestionsStackPanel.Children.Add(new TextBlock() { Text = "The right answer is: ", Name = "CorrectAnswer" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "Answer with one digit", Name = "CorrectAnswerField" });*/
                
            }

        }

        private void CreateExamButton_OnClick(object sender, RoutedEventArgs e)
        {
            Exam exam = new Exam
            {
                ExamID = ExamProperty.ExamID,
                ExamDate = ExamProperty.ExamDate,
                ExamName = ExamProperty.ExamName,
                Questions = ExamProperty.Questions,
                Subject = ExamProperty.Subject,
                Results = ExamProperty.Results
            };
        }

        private void SubmitQuestionButton_OnClick(object sender, RoutedEventArgs e)
        {
            
                alternatives.Add("One");
                alternatives.Add("two");
                alternatives.Add("three");
                alternatives.Add("four");

           RightAnswer.Add(Int32.Parse("1"));

            Question question = new Question
            {
                Alternatives = alternatives,
                CorrectAnswer = RightAnswer,
                NumberOfPoints = 1,
                QuestionTitle = CreateExamViewModel.QuestionTitle
                //TODO edit number of points so that the teacher decides the point per question
            };

            listOfQuestions.Add(question);
            CreateExamViewModel.CreatedQuestions.Add(question);
            
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
