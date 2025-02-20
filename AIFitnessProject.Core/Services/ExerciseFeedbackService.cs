using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Azure.Core;
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

        public async Task DeleteExerciseFeedbackAsync(DeleteCommentModel model)
        {
           var exerciseFeedback = await repository.AllAsReadOnly<ExerciseFeedback>()
            .Where(x => x.TrainingPlanId == model.TrainingPlanId && x.ExerciseId == model.ExerciseId)
            .FirstAsync();

            if (exerciseFeedback == null)
            {
                throw new ArgumentException("Въведени са невалинни данни!");
            }

             repository.Delete(exerciseFeedback);
            await repository.SaveChangesAsync();
        }

        public async Task EditExerciseFeedbackAsync(SubmitCommentRequest request)
         {
            var exerciseFeedback = await repository.All<ExerciseFeedback>()
                .Where(x => x.TrainingPlanId == request.TrainingPlanId && x.ExerciseId == request.ExerciseId)
                .FirstAsync();
            if (exerciseFeedback == null)
            {
                throw new ArgumentException("Въведени са невалинни данни!");
            }
            exerciseFeedback.Feedback = request.Content;
            await repository.SaveChangesAsync();
        }
    }
}
