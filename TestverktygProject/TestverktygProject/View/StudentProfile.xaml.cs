using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class StudentProfile : Page
    {
        public Student student1;
        public ObservableCollection<Student> studentList;
        public StudentProfileViewModel Sp { get; set; }
        public TakeExamPage tePage { get;set; }
        public APIService Api { get; set; }
        public Exam test;
        public StudentProfile()
        {
            this.InitializeComponent();
            this.Sp = new StudentProfileViewModel();
            this.Api = new APIService();
            test = new Exam();
            //student1 = new Student();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            student1 = (Student)e?.Parameter;
            Sp.tempstudent = student1;
            FirstNameText.Text = student1.FirstName;
            LastNameText.Text = student1.LastName;
            FirstNameText1.Text = student1.FirstName;
            LastNameText1.Text = student1.LastName;
            apiGet();
            Sp.cloneList();
        }
        private async void startExamButton_Click(object sender, RoutedEventArgs e)
        {
            tePage = new TakeExamPage(student1, (Exam)StudentsExam.SelectedItem);
            this.Frame.Navigate(typeof(TakeExam), tePage);

            var exam = (Exam)StudentsExam.SelectedItem;            
            exam.IsActive = false;
            //skicka in ID == exam.ID och objektet (exam) !!!! PUT !!!! PUT SOM I PUTIN

            var test = await Api.UpdateExamsAvailabilityAsync(exam.ExamID, exam);
        }

        private async void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog confirmDialog = new MessageDialog("Do you want to sign out?", "Sign out confirmation");
            confirmDialog.Commands.Add(new UICommand("Yes"));
            confirmDialog.Commands.Add(new UICommand("No"));
            var confirmResult = await confirmDialog.ShowAsync();
            // "No" button pressed: Keep the app open.
            if (confirmResult != null && confirmResult.Label == "No") { return; }
            // "Back" or "Yes" button pressed: Close the app.
            if (confirmResult == null || confirmResult.Label == "Yes") { Frame.Navigate(typeof(LogIn)); }
        }
        public async void apiGet()
        {
            var students = await Api.GetAllStudentsAsync();
            foreach (Student student in students)
            {
                Sp._apiStudents.Add(student);
            }

            var exams = await Api.GetAllExamsAsync();

            foreach (Exam exam in exams)
            {
                Sp._apiExams.Add(exam);
            }

        }
        private async void signOutButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog confirmDialog = new MessageDialog("Do you want to sign out?", "Sign out confirmation");
            confirmDialog.Commands.Add(new UICommand("Yes"));
            confirmDialog.Commands.Add(new UICommand("No"));
            var confirmResult = await confirmDialog.ShowAsync();
            // "No" button pressed: Keep the app open.
            if (confirmResult != null && confirmResult.Label == "No") { return; }
            // "Back" or "Yes" button pressed: Close the app.
            if (confirmResult == null || confirmResult.Label == "Yes") { Frame.Navigate(typeof(LogIn)); }
        }

        private void StudentsExam_ItemClick(object sender, ItemClickEventArgs e)
        {
            startExamButton.IsEnabled = true;
        }
    }
}
