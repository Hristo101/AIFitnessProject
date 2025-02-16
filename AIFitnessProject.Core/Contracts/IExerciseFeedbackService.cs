using AIFitnessProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IExerciseFeedbackService
    {
        Task AddExerciseFeedbackAsync(SubmitCommentRequest request);
        Task EditExerciseFeedbackAsync(SubmitCommentRequest request);
        Task DeleteExerciseFeedbackAsync(DeleteCommentModel model);
    }
}
