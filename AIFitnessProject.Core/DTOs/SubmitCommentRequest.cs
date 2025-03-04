namespace AIFitnessProject.Core.DTOs
{
    public class SubmitCommentRequest
    {
        public int ExerciseId { get; set; }
        public string Content { get; set; }
        public int TrainingPlanId { get; set; }
        public int? CommentId { get; set; }
    }
}
