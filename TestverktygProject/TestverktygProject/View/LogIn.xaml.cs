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

            string username = usernamebox.Text.ToLower();
            string password = passwordbox.Password.ToLower();
            object temp = await Lvm.LogIn(username,password);
            object student = null;
            object teacher = null;
            try
            {
                teacher = (Teacher)temp;
            }
            catch (InvalidCastException)
            {
                student = (Student)temp;
            }
            
                if (student != null)
                {
                    Debug.WriteLine("En student loggande in");
                    Frame.Navigate(typeof(StudentProfile), (Student)student);
                }
                else if (teacher != null)
                {
                    Debug.WriteLine("En teacher loggade in");
                    Frame.Navigate(typeof(TeacherProfile), teacher);
                }
                else
                    Debug.WriteLine("Fel lösenord/användarnamn");
        }
       
    }
}
