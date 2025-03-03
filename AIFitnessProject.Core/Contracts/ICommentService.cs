using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
