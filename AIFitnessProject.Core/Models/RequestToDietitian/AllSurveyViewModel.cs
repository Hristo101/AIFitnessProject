namespace AIFitnessProject.Core.Models.RequestToDietitian
{
    public class AllSurveyViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ProfilePicture { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

        public string ExperienceLevel { get; set; } = string.Empty;

        public string DietBackground { get; set; } = string.Empty;
    }
}
