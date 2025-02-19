using AIFitnessProject.Core.DTOs.MealFeedback;

namespace AIFitnessProject.Core.Contracts
{
    public interface IMealFeedbackService
    {
        Task AddMealFeedbackAsync(SubmitCommentRequestDTO request);
        Task EditMealFeedbackAsync(SubmitCommentRequestDTO request);
        Task DeleteMealFeedbackAsync(DeleteCommentModelDTO model);
    }
}
