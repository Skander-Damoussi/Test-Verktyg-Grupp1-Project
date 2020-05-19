using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestverktygProject.Model;
using TestverktygProject.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestverktygProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TakeExam : Page
    {
        public TakeExam()
        {
            this.InitializeComponent();

            this.Tvm = new TakeExamViewModel();

            setQuestText();

            Tvm.updateAlternatives();
            AnswerList.ItemsSource = Tvm._tempquest;
        }
        public TakeExamViewModel Tvm { get; set; }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Tvm.prevQuestion();
            setQuestText();
            AnswerList.ItemsSource = Tvm._tempquest;
        }
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Tvm.nextQuestion();

            setQuestText();
            
            AnswerList.ItemsSource = Tvm._tempquest;
        }
        public void setQuestText()
        {
            Tvm.temp = Tvm.questions[Tvm.index];
            QuestionTitle.Text = Tvm.temp.QuestionTitle.ToString();
            QuestionNumberTitle.Text = Tvm.startindex.ToString();
            QuestionNumber.Text = $"Question {Tvm.startindex.ToString()} out of {Tvm.questions.Count.ToString()}";
        }
    }
}
