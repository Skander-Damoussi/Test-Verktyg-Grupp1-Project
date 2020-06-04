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
        public TakeExamViewModel TakeExamViewModel { get; set; }

        public TakeExam()
        {
            this.InitializeComponent();
            this.TakeExamViewModel = new TakeExamViewModel();      
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Adds the selected item from previous page to a variable in this page.
            TakeExamViewModel.navigateSelectedItem = (TakeExamPage)e?.Parameter;
            //Sets exam subject title text to current exam subjet.
            SubjectTitle.Text = TakeExamViewModel.navigateSelectedItem.Exam.ExamName;            
            //Adds the question from exam to an observablecollection which previous page sent.
            foreach(Question question in TakeExamViewModel.navigateSelectedItem.Exam.Questions)
            {
                TakeExamViewModel.selectedExam.Add(question);
            }
            SetQuestionText();
            TakeExamViewModel.UpdateListOfAlternatives();
        }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TakeExamViewModel.index > 0)
            {
                CheckIfAlternativeIsCorrect();
                TakeExamViewModel.prevQuestion();
                SetQuestionText();
                TakeExamViewModel.RemovePointOnPreviousQuestion();
            }
            else
            {
                PrevQuestionBtn.IsEnabled = false;
            } 
             
        }
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
                CheckIfAlternativeIsCorrect();
                TakeExamViewModel.nextQuestion();
                SetQuestionText();
                NextQuestionBtn.IsEnabled = false;
                PrevQuestionBtn.IsEnabled = true;
        }
        public void SetQuestionText()
        {
            //Set the textblock to display the current question.
            if(TakeExamViewModel.index < TakeExamViewModel.selectedExam.Count)
            {
                QuestionTitle.Text = TakeExamViewModel.selectedExam[TakeExamViewModel.index].QuestionTitle.ToString();
                QuestionNumberTitle.Text = TakeExamViewModel.startindex.ToString();
                SubjectTitle.Text = TakeExamViewModel.navigateSelectedItem.Exam.Subject;
                QuestionNumber.Text = $"Question {TakeExamViewModel.startindex.ToString()} out of {TakeExamViewModel.selectedExam.Count.ToString()}";
            }         
        }

        public void CheckIfAlternativeIsCorrect()
        {
            TakeExamViewModel.numberofSelectedAlt.Clear();
            //Go through the the selected alternative then adds it to a list which we will check later if the answer is correct, CAN CHECK MULTIPLE ANSWERS.
            for (int i = 0; i < AnswerList.SelectedItems.Count; i++)
            {
                if (TakeExamViewModel.selectedExam[TakeExamViewModel.index].Alt1 == AnswerList.SelectedItems[i].ToString())
                {
                    TakeExamViewModel.numberofSelectedAlt.Add(1);
                }
                if (TakeExamViewModel.selectedExam[TakeExamViewModel.index].Alt2 == AnswerList.SelectedItems[i].ToString())
                {
                    TakeExamViewModel.numberofSelectedAlt.Add(2);
                }
                if (TakeExamViewModel.selectedExam[TakeExamViewModel.index].Alt3 == AnswerList.SelectedItems[i].ToString())
                {
                    TakeExamViewModel.numberofSelectedAlt.Add(3);
                }
                if (TakeExamViewModel.selectedExam[TakeExamViewModel.index].Alt4 == AnswerList.SelectedItems[i].ToString())
                {
                    TakeExamViewModel.numberofSelectedAlt.Add(4);
                }
            }
            TakeExamViewModel.SumPointsToVariable();
        }
        private async void TurnInExamButton_Click(object sender, RoutedEventArgs e)
        {
            TakeExamViewModel.TurnInExam();
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

        private void AnswerList_ItemClick(object sender, ItemClickEventArgs e)
        {
            NextQuestionBtn.IsEnabled = true;
        }
    }
}
