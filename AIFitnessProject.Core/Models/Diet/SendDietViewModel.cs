namespace AIFitnessProject.Core.Models.Diet
{
    public class SendDietViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrlDiet { get; set; }

        public string DescriptionDiet { get; set; }

        public int DailyDietPlanCount { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        public string UserProfilePicture { get; set; }
    }
}
