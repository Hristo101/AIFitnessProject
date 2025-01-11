using System;
using System.Collections.Generic;
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

        }

        public static class Dietitian
        {

        }

        public static class ApplicationUser
        {

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
            public const int MaxSpecializationLength = 1500;
            public const int MinSpecializationLength = 3;

            public const int MaxSertificationDetailsLength = 2500;
            public const int MinSertificationDetailsLength = 3;

            public const int MaxImageUrlLength = 2048;
            public const int MinImageUrlLength = 10;
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

    }
}
