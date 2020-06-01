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
        //public ObservableCollection<Question> selectedQuestion { get; set; }
        //public StudentExam studentExam;

        public APIService Api { get; set; }
        public TakeExamViewModel Tvm { get; set; }
        public ObservableCollection<string> tempAltList = new ObservableCollection<string>();
        public List<int> numberofSelectedAlt = new List<int>();
        public int finalResult;
        

        public TakeExam()
        {
            this.InitializeComponent();
            this.Tvm = new TakeExamViewModel();
            

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var selectedItem = (Exam)e?.Parameter;
            SubjectTitle.Text = selectedItem.ExamName;
            
            foreach(Question question in selectedItem.Questions)
            {
                Tvm.selectedExam.Add(question);
            }
            setQuestText();
            //Tvm.updateAlternatives();
            updateListOfAlt();

        }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Tvm.prevQuestion();
            updateListOfAlt();
            setQuestText();
            checkAlt();
        }
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            checkAlt();
            Tvm.nextQuestion();
            updateListOfAlt();
            setQuestText();
            
        }
        public void setQuestText()
        {
            QuestionTitle.Text = Tvm.selectedExam[Tvm.index].QuestionTitle.ToString();
            QuestionNumberTitle.Text = Tvm.startindex.ToString();
            //SubjectTitle.Text = Tvm.tempQuestion.
            QuestionNumber.Text = $"Question {Tvm.startindex.ToString()} out of {Tvm.selectedExam.Count.ToString()}";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog confirmDialog = new MessageDialog("Do you want to cancel the test?", "cancel confirmation");
            confirmDialog.Commands.Add(new UICommand("Yes"));
            confirmDialog.Commands.Add(new UICommand("No"));
            var confirmResult = await confirmDialog.ShowAsync();
            // "No" button pressed: Keep the app open.
            if (confirmResult != null && confirmResult.Label == "No") { return; }
            // "Back" or "Yes" button pressed: Close the app.
            if (confirmResult == null || confirmResult.Label == "Yes") { Frame.Navigate(typeof(LogIn)); }
        }
        public void checkAlt()
        {                        
            for (int i = 0; i < AnswerList.SelectedItems.Count; i++)
            {
                if (Tvm.selectedExam[Tvm.index].Alt1 == AnswerList.SelectedItems[i].ToString())
                {
                    numberofSelectedAlt.Add(1);
                }
                if (Tvm.selectedExam[Tvm.index].Alt2 == AnswerList.SelectedItems[i].ToString())
                {
                    numberofSelectedAlt.Add(2);
                }
                if (Tvm.selectedExam[Tvm.index].Alt3 == AnswerList.SelectedItems[i].ToString())
                {
                    numberofSelectedAlt.Add(3);
                }
                if (Tvm.selectedExam[Tvm.index].Alt4 == AnswerList.SelectedItems[i].ToString())
                {
                    numberofSelectedAlt.Add(4);
                }
            }
            testMethod();
        }
        public void updateListOfAlt()
        {
            tempAltList.Clear();
            tempAltList.Add(Tvm.selectedExam[Tvm.index].Alt1);
            tempAltList.Add(Tvm.selectedExam[Tvm.index].Alt2);
            tempAltList.Add(Tvm.selectedExam[Tvm.index].Alt3);
            tempAltList.Add(Tvm.selectedExam[Tvm.index].Alt4);
        }
        public void testMethod()
        {
            for (int i = 0; i < numberofSelectedAlt.Count; i++)
            {
                if(Tvm.selectedExam[Tvm.index].CorrectAnswer == numberofSelectedAlt[i])
                {
                    finalResult += Tvm.selectedExam[Tvm.index].NumberOfPoints;
                }
            }
        }
    }
}
