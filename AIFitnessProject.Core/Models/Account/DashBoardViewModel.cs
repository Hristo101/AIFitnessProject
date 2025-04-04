﻿using AIFitnessProject.Core.Models.UserComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Account
{
    public class DashBoardViewModel
    {
        public string TrainerName { get; set; }
        public string TrainerPicture { get; set; }
        public ICollection<UsersToTrainerViewModel> UsersToTrainers { get; set; } = new List<UsersToTrainerViewModel>();
        public ICollection<UserCommentForTrainerViewModel> UserCommentForTrainerViewModels { get; set; } = new List<UserCommentForTrainerViewModel>();
        public int TotalUserForTheDay { get; set; }
        public double DayChangePercent { get; set; }
        public int TotalUserForMonth { get; set; }
        public double MonthChangePercent { get; set; }
        public int TotalUserForYear { get; set; }
        public double YearChangePercent { get; set; }
        public double PercentFatPeople { get; set; }
        public double PercentWeakPeople { get; set; }
    }
}
