using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.View;
using Windows.Networking.Sockets;

namespace TestverktygProject.ViewModel
{
    public class TakeExamViewModel
    {
        public int index = 0;
        public int startindex = 1;

        public ObservableCollection<Question> selectedExam;
        public ObservableCollection<Question> tempQuest;
        public List<int> selectedAlt;


        public ObservableCollection<Question> _tempQuest
        {
            get { return tempQuest; }
            set { tempQuest = value; }
        }
        public TakeExamViewModel()
        {
            selectedExam = new ObservableCollection<Question>();
            tempQuest = new ObservableCollection<Question>();
            selectedAlt = new List<int>();
        }
        public void nextQuestion()
        {
            if (index + 1 < selectedExam.Count)
            {
                index++;
                startindex++;

                //updateAlternatives();
            }
            else
            {
            }
        }
        public void prevQuestion()
        {
            if (index > 0)
            {
                index--;
                startindex--;

                //updateAlternatives();
            }
            else
            {
                
            }
        }
        public void updateAlternatives()
        {
            tempQuest.Clear();
            tempQuest.Add(selectedExam[index]);
        }
    }
}
