using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestverktygProject.Model;
using TestverktygProject.Services;
using TestverktygProject.View;
using Windows.Networking.Sockets;
using Windows.UI.Popups;

namespace TestverktygProject.ViewModel
{
    public class TakeExamViewModel
    {
        public int index = 0;
        public int startindex = 1;
        public int finalResult;

        public ObservableCollection<string> tempAlternativeList;
        public ObservableCollection<Question> selectedExam;
        public List<int> selectedAlt;
        public List<int> numberofSelectedAlt;
        public List<int> sumPointsList;

        public TakeExamPage navigateSelectedItem;
        public APIService ApiService { get; set; }

        public TakeExamViewModel()
        {
            selectedExam = new ObservableCollection<Question>();
            tempAlternativeList = new ObservableCollection<string>();
            selectedAlt = new List<int>();
            numberofSelectedAlt = new List<int>();
            sumPointsList = new List<int>();
            navigateSelectedItem = new TakeExamPage();
            this.ApiService = new APIService();           
        }
        public void nextQuestion()
        {
            //Check so the user isnt in the last question and update list of alternative so it matches the question otherwise do nothing
            if (startindex <= selectedExam.Count)
            {
                index++;
                startindex++;
                UpdateListOfAlternatives();
            }
        }
        public void prevQuestion()
        {
            //Check so the user isnt in the first question and update list of alternative so it matches the question otherwise do nothing
            if (index > 0)
            {
                index--;
                startindex--;
                UpdateListOfAlternatives();
            }
        }
        public async void TurnInExam()
        {
            for (int i = 0; i < sumPointsList.Count; i++)
            {
                finalResult += sumPointsList[i];
            }
            // Update table StudentExam with the new result user has turned in.
            await ApiService.UpdateExamAsync(navigateSelectedItem.Student.StudentID, navigateSelectedItem.Exam.ExamID, finalResult);           
        }
        public void SumPointsToVariable()
        {
            //Adds point to a variable wich we will send later as final result to studentexam.
            for (int i = 0; i < numberofSelectedAlt.Count; i++)
            {
                if (selectedExam[index].CorrectAnswer == numberofSelectedAlt[i])
                {
                    if(index >= sumPointsList.Count)
                    {
                        sumPointsList.Add(selectedExam[index].NumberOfPoints);
                    }
                    else
                    {
                        sumPointsList[index] = selectedExam[index].NumberOfPoints;
                    }
                }
                else
                {
                    if (index >= sumPointsList.Count)
                    {
                        sumPointsList.Add(0);
                    }
                    else
                    {
                        sumPointsList[index] = selectedExam[index].NumberOfPoints;
                    }                        
                }
            }
        }
        public void RemovePointOnPreviousQuestion()
        {
            //When user goes to previous question reset the point to 0 for that question
            sumPointsList[index] = 0;
        }
        public void UpdateListOfAlternatives()
        {
            //Update list of alternatives so it matches the question index.
            tempAlternativeList.Clear();
            if (index < selectedExam.Count)
            {
                tempAlternativeList.Add(selectedExam[index].Alt1);
                tempAlternativeList.Add(selectedExam[index].Alt2);
                tempAlternativeList.Add(selectedExam[index].Alt3);
                tempAlternativeList.Add(selectedExam[index].Alt4);
            }                         
        }
    }
}
