using Microsoft.AspNetCore.Http;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class EditTrainingPlanViewModel
    {
        public string? ImageUrl { get; set; }
        public IFormFile? NewImageUrl { get; set; }
        public string TrainingPlanName { get; set; }
        public string TrainingPlanDescription { get; set; }
    }
}
