using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using TestverktygProject.Model;
using TestverktygProject.View;

namespace TestverktygProject.ViewModel
{
    public class CreateExamViewModel
    {
        public ObservableCollection<Exam> ExamList { get; set; }
        public ObservableCollection<Question> QuestionsToBeFilled { get; set; }
        public ObservableCollection<Question> CreatedQuestions { get; set; }

        private HttpClient httpClient;
        private string url = "";
        
        public CreateExamViewModel()
        {
            ExamList = new ObservableCollection<Exam>();
            QuestionsToBeFilled = new ObservableCollection<Question>();
            CreatedQuestions = new ObservableCollection<Question>();
            httpClient = new HttpClient();
        }

        /*public async Task<ObservableCollection<Exam>> GetAllExams()
        {
            var jsonExams = await httpClient.GetStringAsync(url);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var exams = JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(jsonPizzas, settings);

            return exams;
        }*/

        /*public async Task AddExamAsync(Exam exam)
        {
            var exams = JsonConvert.SerializeObject(exam);

            HttpContent httpContent = new StringContent(exams);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await httpClient.PostAsync(url, httpContent);
        }*/


    }
}
