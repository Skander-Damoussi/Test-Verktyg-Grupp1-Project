using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestverktygProject.Model;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> QuestionsToBeFilled { get; set; }
        public ObservableCollection<Question> CreatedQuestions { get; set; }

        private HttpClient httpClient;
        private string examURL = "https://localhost:44324/api/exams";
        private string questionURL = "https://localhost:44324/api/questions";


        public CreateExamViewModel()
        {
            ExamList = new ObservableCollection<Exam>();
            QuestionsToBeFilled = new ObservableCollection<Question>();
            CreatedQuestions = new ObservableCollection<Question>();
            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Exam>> GetAllExamsAsync()
        {
            var jsonExams = await httpClient.GetStringAsync(examURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var exams = JsonConvert.DeserializeObject<ObservableCollection<Exam>>(jsonExams, settings);

            return exams;
        }

        public async Task<HttpResponseMessage> AddExamAsync(Exam exam)
        {
            exam.IsActive = true;
            var exams = JsonConvert.SerializeObject(exam);


            HttpContent httpContent = new StringContent(exams);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(examURL, httpContent);
            return result;
        }

        public async Task<ObservableCollection<Question>> GetAllQuestionsAsync()
        {
            var jsonQuestions = await httpClient.GetStringAsync(questionURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var questions = JsonConvert.DeserializeObject<ObservableCollection<Question>>(jsonQuestions, settings);

            return questions;
        }

        public async Task AddQuestionAsync(Question question)
        {
            var questions = JsonConvert.SerializeObject(question);
            
            HttpContent httpContent = new StringContent(questions);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await httpClient.PostAsync(questionURL, httpContent);
        }
    }
}
