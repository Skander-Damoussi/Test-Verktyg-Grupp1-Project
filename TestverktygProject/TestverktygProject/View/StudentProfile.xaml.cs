using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestverktygProject.Model;
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
        public StudentProfileViewModel Vm { get; set; }
        public ObservableCollection<Exam> _examList { get; set; }
        Student tempstudent;

        public StudentProfile()
        {
            this.InitializeComponent();
            Student student1 = new Student(_examList, "Peter", "Petersson", "PeterPetersson", "Petersson123", false);
            //student1 ska bli getmetod
            tempstudent = student1;
            this.Vm = new StudentProfileViewModel();
            //tempstudent = Vm.student1;
            FirstNameText.Text = tempstudent.FirstName;
            LastNameText.Text = tempstudent.LastName;
        }

        private void startExamButton_Click(object sender, RoutedEventArgs e)
        {
            Exam selectedExam = (Exam)StudentsExam.SelectedItem;
            this.Frame.Navigate(typeof(TakeExam),selectedExam);
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
    }
}
