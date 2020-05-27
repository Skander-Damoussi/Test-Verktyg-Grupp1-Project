﻿using System;
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
    public sealed partial class StudentProfile : Page
    {
        public StudentProfileViewModel Vm { get; set; }
        public APIService Api { get; set; }
        public TakeExam Te { get; set; }
        public StudentProfile()
        {
            this.InitializeComponent();
            this.Vm = new StudentProfileViewModel();
            this.Api = new APIService();
            this.Te = new TakeExam();
            apiGet();
        }

        private void startExamButton_Click(object sender, RoutedEventArgs e)
        {            
            this.Frame.Navigate(typeof(TakeExam), (Exam)StudentsExam.SelectedItem);
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
                Vm._apiStudents.Add(student);
            }

            var exams = await Api.GetAllExamsAsync();

            foreach (Exam exam in exams)
            {
                Vm._apiExams.Add(exam);
            }
        }
    }
}
