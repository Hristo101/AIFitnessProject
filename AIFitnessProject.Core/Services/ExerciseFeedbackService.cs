using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class ExerciseFeedbackService : IExerciseFeedbackService
    {
        private readonly IRepository repository;

        public ExerciseFeedbackService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddExerciseFeedbackAsync(SubmitCommentRequest request)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(x =>x.Id == request.TrainingPlanId)
                .Include(x =>x.Trainer)
                .ThenInclude(x => x.User)
                .FirstAsync();

            ExerciseFeedback exerciseFeedback = new ExerciseFeedback()
            {
                CreatedAt = DateTime.Now,
                ExerciseId = request.ExerciseId,
                TrainingPlanId = request.TrainingPlanId,
                Feedback = request.Content,
            };

            await repository.AddAsync(exerciseFeedback);
            await repository.SaveChangesAsync();
        }
    }
}
