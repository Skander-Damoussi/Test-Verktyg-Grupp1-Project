using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.Services;
using Windows.UI.Notifications;

namespace TestverktygProject.ViewModel
{
    public class LogInViewModel
    {
        public ObservableCollection<User> UserList { get; set; }
        public APIService Api { get; set; }
        public async Task<int> LogIn(string username,string password)
        {
            this.Api = new APIService();
            LoginModel login = new LoginModel();
            login.Username = username;
            login.Password = password;
         switch(await Api.LogInAsync(login)){
                case "true":
                    return 1;
                case "false":
                    return 2;
                default:
                    return 3;

            }


           
        }

    }
}
