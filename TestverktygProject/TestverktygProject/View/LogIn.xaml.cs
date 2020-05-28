using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.Services;
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
    public sealed partial class LogIn : Page
    {
        public StudentProfileViewModel Vm { get; set; }
        public LogInViewModel Lvm { get; set; }
        public APIService Api { get; set; }
        public LogIn()
        {          
            this.InitializeComponent();
            this.Vm = new StudentProfileViewModel();
            this.Api = new APIService();
            this.Lvm = new LogInViewModel();
        }

        private void GoToTakeExam_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TakeExam));
        }

        private void CreateExamButtonFromLoginPage_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateExam));
        }

        private void TeacherProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeacherProfile));
        }

        private void StudentProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudentProfile));
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
         switch(await Lvm.LogIn(usernamebox.Text.ToLower(), passwordbox.Password.ToLower()))
            {
                case 1:
                    Debug.WriteLine("Teacher");
                    break;
                case 2:
                    Debug.WriteLine("Student");
                    break;
                case 3:
                    Debug.WriteLine("Wrong password/username");
                    break;

            }
        }
       
    }
}
