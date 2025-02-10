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

            public const int MaxMealTimeLength = 200;
            public const int MinMealTimeLength = 3;

            public const int MaxDificultyLevelLength = 100;
            public const int MinDificultyLevelLength = 3;

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

            public const int MaxPositionLength = 100;
            public const int MinPositionLength = 3;

            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;

            public const int MaxSpecializationLength = 1500;
            public const int MinSpecializationLength = 3;

            public const int MaxExperience = 100;
            public const int MinExperience = 3;

            public const int MaxSertificationDetailsLength = 2500;
            public const int MinSertificationDetailsLength = 3;

            public const int MaxBioLength = 4500;
            public const int MinBioLength = 3;

            public const int MaxSertificationImageLength = 2048;
            public const int MinSertificationImageLength = 10;

            public const int MaxPhoneNumberLength = 10;
            public const int MinPhoneNumberLength = 10;

        }

        public static class ApplicationUser
        {

            public const int MaxFirstNameLength = 1900;
            public const int MinFirstNameLength = 3;

            public const int MaxLastNameLength = 1900;
            public const int MinLastNameLength = 3;

            public const double MaxHeight = 280;
            public const double MinHeight = 120;

            public const int MaxWeight = 450;
            public const int MinWeight = 3;

            public const int MaxExperienceLevelLength = 2100;
            public const int MinExperienceLevelLength = 3;

            public const int MaxAimLength = 5000;
            public const int MinAimLength = 3;
        }

        public static class Calendar
        {

        }

        public static class Notification
        {
            public const int MaxMessageLength = 5000;
            public const int MinMessageLength = 3;
        }

        public static class PlanAssignment
        {

        }

        public static class Trainer
        {
            public const int MaxPositionLength = 100;
            public const int MinPositionLength = 3;

            public const int MaxExperience = 100;
            public const int MinExperience = 3;

            public const int MaxSpecializationLength = 1500;
            public const int MinSpecializationLength = 3;

            public const int MaxSertificationDetailsLength = 2500;
            public const int MinSertificationDetailsLength = 3;

            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;

            public const int MinBioLength = 3;
            public const int MaxBioLength = 4500;
        }

        public static class TrainingPlan
        {
            public const int MaxNameLength = 500;
            public const int MinNameLength = 3;

            public const int MaxDescriptionLength = 2500;
            public const int MinDescriptionLength = 3;
        }

        public static class UserComment
        {
            public const int MaxContentLength = 3000;
            public const int MinContentLength = 3;
        }

        public static class Workout
        {
            public const int MaxDayOfWeekLength = 100;
            public const int MinDayOfWeekLength = 3;
        }

        public static class Documents
        {
            public const int MaxPositionLength = 100;
            public const int MinPositionLength = 3;

            public const int MaxExperience = 100;
            public const int MinExperience = 3;

            public const int MaxSpecializationLength = 1500;
            public const int MinSpecializationLength = 3;

            public const int MaxSertificationDetailsLength = 2500;
            public const int MinSertificationDetailsLength = 3;

            public const int MinBioLength = 3;
            public const int MaxBioLength = 4500;
        }
       
    }
}
