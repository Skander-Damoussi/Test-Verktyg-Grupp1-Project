﻿using System;
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
using Windows.UI.Popups;
using System.Windows;
using TestverktygProject.Model;
using System.ServiceModel.Channels;
using TestverktygProject.ViewModel;
using TestverktygProject.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestverktygProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeacherProfile : Page
    {

        //   TeacherProfileViewModel TeacherProfileView = new TeacherProfileViewModel();
        public APIService api { get; set; }
        public TeacherProfileViewModel vm { get; set; }
     //   public Teacher teacher;
   //     public ObservableCollection<Teacher> teacherlist;
        public TeacherProfile()
        {
            this.InitializeComponent();
            this.api = new APIService();
            this.vm = new TeacherProfileViewModel();
         //   teacher = new Teacher();
            vm.apiGet();
           
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var teacher = (Teacher)e?.Parameter;
            teacherfirstname.Text = teacher.FirstName;
            teacherlastname.Text = teacher.LastName;

        }

        private async void signout_Click(object sender, RoutedEventArgs e)
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

        private void createexam_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateExam));
        }

        private void viewstudentexam_Click(object sender, RoutedEventArgs e)
        {
            examlistview.ItemsSource = vm.examstudentbind((Student)StudentListView.SelectedItem);
        }

        private void viewstudentexam_Copy_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)StudentListView.SelectedItem;
            var exam = (Exam)examlistview.SelectedItem;
            pointslistview.ItemsSource = vm.getexampoints(student, exam);
        }

        private void StudentListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewstudentexam.IsEnabled = true;
        }

        private void examlistview_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewstudentexam_Copy.IsEnabled = true;
        }
    }
}