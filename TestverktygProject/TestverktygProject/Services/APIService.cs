using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.View;
using Windows.Foundation;

namespace TestverktygProject.Services
{
    
    public class APIService : IAPIService
    {
        private const string WebServiceUrl = "https://localhost:44324/api/";
        HttpClient httpClient;
        public APIService()
        {
            httpClient = new HttpClient();
        }
        public async Task<int> LogInAsync(LoginModel login)
        {
            string IsTeacher = null;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(login));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var message =  await httpClient.PostAsync(WebServiceUrl + "LoginModels", httpContent);
            IsTeacher = await message.Content.ReadAsStringAsync();
            Debug.WriteLine(IsTeacher);
            
            return int.Parse(IsTeacher);
        }
        public async Task PostExams()
        {
            throw new Exception();
        }
        public async Task<ObservableCollection<Student>> GetAllStudentsAsync()
        {

                var jsonStudents = await httpClient.GetStringAsync(WebServiceUrl + "Students");

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                var students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonStudents, settings);

            return students;
        }
        public async Task<Student> GetStudentAsync(int id,string username)
        {

            var jsonStudent = await httpClient.GetStringAsync(WebServiceUrl + $"Students/ {id}/{username}");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var student = JsonConvert.DeserializeObject<Student>(jsonStudent, settings);

            return student;
        }
        public async Task<Teacher> GetTeacherAsync(int id,string username)
        {
            
            var jsonTeacher = await httpClient.GetStringAsync(WebServiceUrl + $"Teachers/ {id}/{username}");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var teacher = JsonConvert.DeserializeObject<Teacher>(jsonTeacher, settings);

            return teacher;
        }
        public async Task<ObservableCollection<Exam>> GetAllExamsAsync()
        {
            var jsonExams = await httpClient.GetStringAsync(WebServiceUrl + "Exams");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var exams = JsonConvert.DeserializeObject<ObservableCollection<Exam>>(jsonExams, settings);

            return exams;
        }


        public async Task<ObservableCollection<StudentExam>> GetAllStudentExamsAsync(Student student)
        {

            string jsonStudentExams = await httpClient.GetStringAsync(WebServiceUrl + "studentexams/" + student.StudentID);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var studentexams = JsonConvert.DeserializeObject<ObservableCollection<StudentExam>>(jsonStudentExams);
            return studentexams;
        }
        public async Task<ObservableCollection<Teacher>> GetAllTeachersAsync()
        {
            var jsonTeachers = await httpClient.GetStringAsync(WebServiceUrl + "Teachers");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var teachers = JsonConvert.DeserializeObject<ObservableCollection<Teacher>>(jsonTeachers, settings);

            return teachers;
        }
    }
}
