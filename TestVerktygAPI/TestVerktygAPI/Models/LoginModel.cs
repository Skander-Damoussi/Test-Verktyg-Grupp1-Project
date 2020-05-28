using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestVerktygAPI.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
    }
}
