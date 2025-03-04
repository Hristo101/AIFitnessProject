namespace AIFitnessProject.Core.DTOs.MealFeedback
{
    public class SubmitCommentRequestDTO
    {
        public int MealId { get; set; }
        public string Content { get; set; }
        public int DietId { get; set; }
        public int? CommentId { get; set; }
    }
}
