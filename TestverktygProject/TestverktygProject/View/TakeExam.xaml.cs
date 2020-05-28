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
        public ObservableCollection<Question> selectedExam;
        public ObservableCollection<Question> selectedQuestion { get; set; }
        public TakeExamViewModel Vm { get; set; }
        public APIService Api { get; set; }

        public TakeExam()
        {
            this.InitializeComponent();

            //this.Vm = new TakeExamViewModel();
            this.Api = new APIService();
            selectedExam = new ObservableCollection<Question>();

            //AnswerList.ItemsSource = selectedExam;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var selectedItem = (Exam)e?.Parameter;
            //QuestionTitle.Text = selectedItem.ExamName;
            //AnswerList.ItemsSource = selectedItem.Questions;
            foreach(Question question in selectedItem.Questions)
            {
                selectedExam.Add(question);
            }            
        }
        private void PrevQuestionBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void setQuestText()
        {

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
        
    }
}
