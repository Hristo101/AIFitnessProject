namespace AIFitnessProject.Core.Models.MealFeedback
{
    public class MealFeedbackViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string MealTime { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
        public int Calories { get; set; }

    }
}
