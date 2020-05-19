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
        private List<Question> listOfQuestions = new List<Question>();
        private List<Exam> listOfExams = new List<Exam>();

        List<string> alternatives = new List<string>();
        List<int> RightAnswer = new List<int>();

        public CreateExamViewModel CreateExamViewModel { get; set; }
        public CreateQuestionUC QuestionUC { get; set; }
        public CreateExam()
        {
            this.InitializeComponent();
            CreateExamViewModel = new CreateExamViewModel();
            this.DataContext = CreateExamViewModel.Questions;
        }

        private void BeforeCreationOfExamInfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int NumberOfQuestionsToGenerate = Int32.Parse(NumberOfQuestionsToGenerateField.Text);

            for (int i = 0; i < NumberOfQuestionsToGenerate; i++)
            {
                QuestionUC = new CreateQuestionUC();
            }

            /*for (int i = 0; i < NumberOfQuestionsToGenerate; i++)
            {
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "Title of question", Name = "TitleOfQuestion" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 1", Name = "Alt1" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 2", Name = "Alt2" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 3", Name = "Alt3" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "alternative 4", Name = "Alt3" });
                CreateQuestionsStackPanel.Children.Add(new TextBlock() { Text = "The right answer is: ", Name = "CorrectAnswer" });
                CreateQuestionsStackPanel.Children.Add(new TextBox() { PlaceholderText = "Answer with one digit", Name = "CorrectAnswerField" });
            }*/

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
            //GetElementFromCreatedQuestions();
            
            Question question = new Question
            {
                Alternatives = alternatives,
                CorrectAnswer = RightAnswer,
                NumberOfPoints = 1,
                QuestionTitle = "Some text"
                //TODO edit number of points so that the teacher decides the point per question
            };

            listOfQuestions.Add(question);
            CreateExamViewModel.Questions.Add(question);
        }

        public List<Question> GetQuestions()
        {
            return listOfQuestions;
        }

        public List<Exam> GetExams()
        {
            return listOfExams;
        }

        /*public void GetElementFromCreatedQuestions()
        {
            foreach (UIElement child in CreateQuestionsStackPanel.Children)
            {
                if (child is StackPanel)
                {
                    foreach (UIElement ctrlChild in (child as StackPanel).Children)
                    {
                        if (ctrlChild is TextBox)
                        {
                            alternatives.Add(ctrlChild.ToString());
                        }
                    }
                }
            }

            foreach (UIElement tb in CreateQuestionsStackPanel.Children)
            {
                if (tb is TextBox)
                {
                    RightAnswer.Add(Int32.Parse(tb.ToString()));
                }
            }
        }

        public UIElement GetQuestionTitle()
        {
            
        }*/
    }
}
