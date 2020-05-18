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
        public int index;
        public TakeExam()
        {
            this.InitializeComponent();

            this.Tvm = new TakeExamViewModel();

            Question temp;
            temp = Tvm.questions[index];
            QuestionTitle.Text = temp.QuestionTitle.ToString();
            index++;
            QuestionNumberTitle.Text = index.ToString();

            QuestionNumber.Text = $"Question {index.ToString()} out of {Tvm.questions.Count.ToString()}";
        }
        public TakeExamViewModel Tvm { get; set; }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index <= Tvm.questions.Count || index >= 1)
            {
                Question temp;
                temp = Tvm.questions[index];
                QuestionTitle.Text = temp.QuestionTitle.ToString();
                QuestionNumberTitle.Text = index.ToString();
                index--;
            }
            else
            {

            }
        }

        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index <= Tvm.questions.Count)
            {
                Question temp;
                temp = Tvm.questions[index];
                QuestionTitle.Text = temp.QuestionTitle.ToString();
                QuestionNumberTitle.Text = index.ToString();
                index++;
            }
            else
            {

            }
        }
    }
}
