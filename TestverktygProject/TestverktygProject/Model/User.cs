using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public abstract class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public bool IsTeacher { get; set; }
        public string Password { get; set; }
        public abstract void LogIn();
    }
}
