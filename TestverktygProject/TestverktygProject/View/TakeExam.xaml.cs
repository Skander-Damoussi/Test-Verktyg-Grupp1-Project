using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestverktygProject.Model;
using TestverktygProject.Services;
using TestverktygProject.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
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
        public TakeExamViewModel Tvm { get; set; }

        public TakeExam()
        {
            this.InitializeComponent();
            this.Tvm = new TakeExamViewModel();      
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Adds the selected item from previous page to a variable in this page.
            Tvm.navigateSelectedItem = (TakeExamPage)e?.Parameter;
            //Sets exam subject title text to current exam subjet.
            SubjectTitle.Text = Tvm.navigateSelectedItem.Exam.ExamName;            
            //Adds the question from exam to an observablecollection which previous page sent.
            foreach(Question question in Tvm.navigateSelectedItem.Exam.Questions)
            {
                Tvm.selectedExam.Add(question);
            }
            SetQuestionText();
            Tvm.UpdateListOfAlternatives();
        }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
                CheckIfAlternativeIsCorrect();
                Tvm.prevQuestion();
                SetQuestionText();
                Tvm.RemovePointOnPreviousQuestion();
        }
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
                CheckIfAlternativeIsCorrect();
                Tvm.nextQuestion();
                SetQuestionText();                                              
        }
        public void SetQuestionText()
        {
            //Set the textblock to display the current question.
            if(Tvm.index < Tvm.selectedExam.Count)
            {
                QuestionTitle.Text = Tvm.selectedExam[Tvm.index].QuestionTitle.ToString();
                QuestionNumberTitle.Text = Tvm.startindex.ToString();
                SubjectTitle.Text = Tvm.navigateSelectedItem.Exam.Subject;
                QuestionNumber.Text = $"Question {Tvm.startindex.ToString()} out of {Tvm.selectedExam.Count.ToString()}";
            }         
        }

        public void CheckIfAlternativeIsCorrect()
        {
            Tvm.numberofSelectedAlt.Clear();
            //Go through the the selected alternative then adds it to a list which we will check later if the answer is correct, CAN CHECK MULTIPLE ANSWERS.
            for (int i = 0; i < AnswerList.SelectedItems.Count; i++)
            {
                if (Tvm.selectedExam[Tvm.index].Alt1 == AnswerList.SelectedItems[i].ToString())
                {
                    Tvm.numberofSelectedAlt.Add(1);
                }
                if (Tvm.selectedExam[Tvm.index].Alt2 == AnswerList.SelectedItems[i].ToString())
                {
                    Tvm.numberofSelectedAlt.Add(2);
                }
                if (Tvm.selectedExam[Tvm.index].Alt3 == AnswerList.SelectedItems[i].ToString())
                {
                    Tvm.numberofSelectedAlt.Add(3);
                }
                if (Tvm.selectedExam[Tvm.index].Alt4 == AnswerList.SelectedItems[i].ToString())
                {
                    Tvm.numberofSelectedAlt.Add(4);
                }
            }
            Tvm.SumPointsToVariable();
        }
        private async void TurnInExamButton_Click(object sender, RoutedEventArgs e)
        {
            Tvm.TurnInExam();
            //Content dialog to make sure the user wants to turn in the test if yes navigate back to previous page.
            MessageDialog confirmDialog = new MessageDialog("Do you want to turn in the the test and complete it?", "cancel confirmation");
            confirmDialog.Commands.Add(new UICommand("Yes"));
            confirmDialog.Commands.Add(new UICommand("No"));
            var confirmResult = await confirmDialog.ShowAsync();
            // "No" button pressed: Keep the app open.
            if (confirmResult != null && confirmResult.Label == "No") { return; }
            // "Back" or "Yes" button pressed: Close the app.
            if (confirmResult == null || confirmResult.Label == "Yes") { this.Frame.GoBack(); }
        }
    }
}
