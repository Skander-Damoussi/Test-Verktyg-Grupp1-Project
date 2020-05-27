using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Teacher : User
    {
        public Teacher() { }
        public Teacher(string firstname, string lastname, string username, string password, bool isteacher)
        {
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
            IsTeacher = isteacher;
        }
        public int TeacherID { get; set; }
    }
}
