namespace AIFitnessProject.Core.Contracts
{
    public interface ICommentService
    {
        Task AddNewComment(string senderId, int trainerId, string content, int rating);
        Task AddNewCommentForDietitian(string senderId, int dietitianId, string content, int rating);
        Task DeleteComment(int commentId);
        Task EditComment(int commentId, string content, int rating);
    }
}
