using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models.GetAPI
{
    public class GetTeacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
    }
}
