using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;

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
        public async Task LogInAsync()
        {
            throw new Exception();
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
        public async Task<ObservableCollection<StudentExam>> GetAllStudentExamsAsync()
        {
            var jsonTeachers = await httpClient.GetStringAsync(WebServiceUrl + "studentexams");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var studentexams = JsonConvert.DeserializeObject<ObservableCollection<StudentExam>>(jsonTeachers, settings);

            return studentexams;
        }



        }
    }
