﻿using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewGoals : ContentPage
    {
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public GoalVM _goalVM = Application.Current.Properties["_goalVM"] as GoalVM;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        private ObservableCollection<GoalModel> specificGoals;

        public ViewGoals()
        {
            InitializeComponent();
            ObservableCollection<GoalModel> GoalList = _goalVM.GoalList;

            // Uses persisted GoalVM to calculate new GoalList collection for specific user
            string currentId = currentUser.GetUserID();
            specificGoals = _goalVM.SpecificGoals(currentId);

            BindingContext = specificGoals;
        }
    }
}