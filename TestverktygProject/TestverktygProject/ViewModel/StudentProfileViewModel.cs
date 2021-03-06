﻿using GalaSoft.MvvmLight.Command;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestverktygProject.Model;
using TestverktygProject.Services;
using TestverktygProject.View;

namespace TestverktygProject.ViewModel
{
    public class StudentProfileViewModel
    {
        APIService api { get; set; }
        public ObservableCollection<Exam> updatedListOfExam;
        public Student tempstudent { get; set; }
        public ObservableCollection<Exam> listOfStudentsExams { get; set; }
        public ObservableCollection<Exam> _ExamHistory { get; set; }
        public ObservableCollection<StudentExam> apiStudentExams { get; set; }
        public ICommand _command { get; set; }
        public ObservableCollection<Exam> apiExams { get; set; }
        public ObservableCollection<Student> apiStudents { get; set; }
        public ObservableCollection<Exam> _listOfStudentsExams
        {
            get { return examstudentbind(tempstudent); }
            set { listOfStudentsExams = value; }
        }
        public ObservableCollection<Exam> ExamHistory
        {
            get { return examstudenhistory(tempstudent); }
            set { listOfStudentsExams = value; }
        }
        public ObservableCollection<StudentExam> _apiStudentExams
        {
            get { return Task.Run(async () => await api.GetAllStudentExamsAsync(tempstudent)).GetAwaiter().GetResult(); }
            set { apiStudentExams = value; }

        }
        public ObservableCollection<Exam> _apiExams
        {
            get { return Task.Run(async () => await api.GetAllExamsAsync()).GetAwaiter().GetResult(); }
            set { apiExams = value; }
        }
        public ObservableCollection<Student> _apiStudents
        {
            get { return apiStudents; }
            set { apiStudents = value; }
        }
        public StudentProfileViewModel()
        {
            api = new APIService();
            _apiExams = new ObservableCollection<Exam>();
            _apiStudents = new ObservableCollection<Student>();
            updatedListOfExam = new ObservableCollection<Exam>();
        }
        public ObservableCollection<Exam> examstudentbind(Student student)
        {
            student.ListExam = new ObservableCollection<Exam>();

            foreach (StudentExam item in _apiStudentExams)
            {
                foreach (var exam in _apiExams)
                {
                    if (item.ExamID == exam.ExamID && exam.ExamDate == System.DateTime.Today && exam.IsActive == true)
                    {
                        student.ListExam.Add(exam);
                    }
                }
            }           
            return student.ListExam;
        }
        public ObservableCollection<Exam> examstudenhistory(Student student)
        {
            student.ListExam = new ObservableCollection<Exam>();

            foreach (StudentExam item in _apiStudentExams)
            {
                foreach (var exam in _apiExams)
                {
                    if (item.ExamID == exam.ExamID)
                    {
                        student.ListExam.Add(exam);
                    }
                }
            }
            return student.ListExam;
        }
        public void cloneList()
        {
            foreach(Exam exam in _listOfStudentsExams)
            {
                updatedListOfExam.Add(exam);
            }
        }
    }
}
