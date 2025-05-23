﻿namespace AIFitnessProject.Core.Models.RequestsToCoach
{
    public class DetailsSurveyModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProfilePicture { get; set; }
        public string Target { get; set; }
        public List<string> PictureOfPersons {  get; set; } = new List<string>();
        public string TrainingBackground { get; set; }
        public string HealthStatus { get; set; }
        public string TrainingPreferences { get; set; }
        public string TrainingCommitment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
