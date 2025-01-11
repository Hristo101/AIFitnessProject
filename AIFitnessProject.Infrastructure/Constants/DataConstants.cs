using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Meal
        {
            public const int MaxNameLength = 500;
            public const int MinNameLength = 3;

            public const int MaxRecipeLength = 2000;
            public const int MinRecipeLength = 3;

            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;

            public const int MaxVideoUrlLength = 2048;
            public const int MinVideoUrlLength = 10;

            public const int MaxCaloriesLength = 3000;
            public const int MinCaloriesLength = 3;

        }
        public static class Diet
        {
            public const int MaxNameLength = 500;
            public const int MinNameLength = 3;

            public const int MaxDescriptionLength = 2500;
            public const int MinDescriptionLength = 3;
        }
        
        public static class Exercise
        {
            public const int MaxNameLength = 500;
            public const int MinNameLength = 3;

            public const int MaxDescriptionLength = 2500;
            public const int MinDescriptionLength = 3;

            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;

            public const int MaxVideoUrlLength = 2048;
            public const int MinVideoUrlLength = 10;

            public const int MaxMuscleGroupLength = 450;
            public const int MinMuscleGroupLength = 3;

            public const int MaxDifficultyLevelLength = 550;
            public const int MinDifficultyLevelLength = 3;
        }

        public static class Dietitian
        {
            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;

            public const int MaxSpecializationLength = 1500;
            public const int MinSpecializationLength = 3;

            public const int MaxExperience = 100;
            public const int MinExperience = 2;

            public const int MaxSertificationDetailsLength = 2500;
            public const int MinSertificationDetailsLength = 2500;
         
        }

        public static class ApplicationUser
        {

            public const int MaxFirstNameLength = 1900;
            public const int MinFirstNameLength = 3;

            public const int MaxLastNameLength = 1900;
            public const int MinLastNameLength = 3;

            public const double MaxHeight = 2.8;
            public const double MinHeight = 1.20;

            public const int MaxWeight = 450;
            public const int MinWeight = 3;

            public const int MaxExperienceLevelLength = 1500;
            public const int MinExperienceLevelLength = 3;
        }

        public static class Calendar
        {

        }

        public static class Notification
        {

        }

        public static class PlanAssignment
        {

        }

        public static class Trainer
        {

        }

        public static class TrainingPlan
        {

        }

        public static class UserComment
        {

        }

        public static class Workout
        {

        }
       
    }
}
