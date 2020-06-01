using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.Services;
using Windows.Media.Core;
using Windows.UI.Notifications;

namespace TestverktygProject.ViewModel
{
    public class LogInViewModel
    {
        public ObservableCollection<User> UserList { get; set; }
        public APIService Api { get; set; }
        public Teacher tempteacher { get; set; }
        public async  Task<object> LogIn(string username,string password)
        {

            object empty = null;

            Debug.WriteLine($"{username}{password}");

          
            this.Api = new APIService();
            LoginModel login = new LoginModel();
            login.Username = username;
            login.Password = password;
            int id = await Api.LogInAsync(login);
            var student = await Api.GetStudentAsync(id, username);
            if (student == null)
            {
                var teacher = await Api.GetTeacherAsync(id, username);
                return teacher;
            }
            else if (student != null)
            {
                return student;
            }
            else
            {
                return empty;
            }

          
          

        }

    }
}
