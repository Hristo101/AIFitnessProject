namespace AIFitnessProject.Core.Models.RequestToDietitian
{
    public class DetailsSurveyModel
    {
        public string ProfilePicture { get; set; }

        public string Target { get; set; }

        public List<string> UserPictures { get; set; }

        public string DietBackground { get; set; }

        public string HealthIssues { get; set; }

        public string MealPreparationPreference { get; set; }

        public string PreferredMealsPerDay { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FoodAllergies { get; set; }

        public string FavouriteFoods { get; set; }

        public string DislikedFoods { get; set; }

        public string SupplementsUsed { get; set; }

        public string ExperienceLevel { get; set; }
    }
}
