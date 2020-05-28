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
        public async Task<string> LogInAsync(LoginModel login)
        {
            string IsTeacher = null;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(login));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var message =  await httpClient.PostAsync(WebServiceUrl + "LoginModels", httpContent);
            IsTeacher = await message.Content.ReadAsStringAsync();
            Debug.WriteLine(IsTeacher);
            return IsTeacher;
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
        public async Task<ObservableCollection<Exam>> GetAllExamsAsync()
        {
            var jsonExams = await httpClient.GetStringAsync(WebServiceUrl + "Exams");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var exams = JsonConvert.DeserializeObject<ObservableCollection<Exam>>(jsonExams, settings);

            return exams;
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
