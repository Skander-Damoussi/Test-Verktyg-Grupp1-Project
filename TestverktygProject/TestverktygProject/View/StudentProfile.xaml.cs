﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestverktygProject.Model;
using TestverktygProject.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestverktygProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentProfile : Page
    {
        public StudentProfileViewModel Vm { get; set; }
        public ObservableCollection<Exam> _examList { get; private set; }
        Student tempstudent;


        public StudentProfile()
        {

            this.InitializeComponent();
            Student student1 = new Student(1, _examList, "Peter", "Petersson", "PeterPetersson", "Petersson123", false);
            //student1 ska bli getmetod
            tempstudent = student1;
            this.Vm = new StudentProfileViewModel();
            FirstNameText.Text = tempstudent.FirstName;
            LastNameText.Text = tempstudent.LastName;
        }
    }
}
