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
        public ObservableCollection<Course> Course { get; set; }
        public int TeacherID { get; set; }
        public void CreateExam() // TODO implement code for teacher to create an exam
        {

        }

        public override void LogIn()
        {
            throw new NotImplementedException();
        }

        public void SeeResults() // TODO implement code for teacher to see results on an exam
        {

        }
    }
}
