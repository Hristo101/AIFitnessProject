using Microsoft.AspNetCore.Http;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class CreateTraingPlanViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public int SurveyId { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string TrainingPlanName { get; set; }
        public string TrainingPlanDescription { get; set; }
    }
}
