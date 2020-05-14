using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestverktygProject.Model
{
    public class Student : User
    {
        public int Result { get; set; }
        public ObservableCollection<Course> Course { get; set; }
        public int StudentID { get; set; }
        public void TakeExam() //TODO implement code so student can take an exam
        {
        }

        public void TakeDiagnostictest() //TODO implement code so student can take a diagnosticstest
        {
        }

        public override void LogIn()
        {
            throw new NotImplementedException();
        }
    }    
}
