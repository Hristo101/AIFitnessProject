namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class SendTrainingPlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrlTrainingPlan { get; set; }
        public string DescriptionTrainingPlan { get; set; }
        public int WorkoutsCount { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; } 
        public string UserEmail { get; set; }
        public string UserProfilePicture { get; set; }
    }
}
