namespace AIFitnessProject.Core.DTOs.MealFeedback
{
    public class SwapMealRequest
    {
        public int DietId { get; set; }
        public int DailyDietPlanId { get; set; }
        public int MealId { get; set; }
        public int NewMealId { get; set; }
    }
}
