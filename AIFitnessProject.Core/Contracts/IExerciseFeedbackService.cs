using AIFitnessProject.Core.DTOs;

namespace AIFitnessProject.Core.Contracts
{
    public interface IExerciseFeedbackService
    {
        Task AddExerciseFeedbackAsync(SubmitCommentRequest request);
        Task EditExerciseFeedbackAsync(SubmitCommentRequest request);
        Task DeleteExerciseFeedbackAsync(DeleteCommentModel model);
    }
}
