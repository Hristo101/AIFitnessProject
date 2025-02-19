using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
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
    public class MealFeedbackService : IMealFeedbackService
    {
        private readonly IRepository repository;

        public MealFeedbackService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddMealFeedbackAsync(SubmitCommentRequestDTO request)
        {

            MealFeedback mealFeedback = new MealFeedback()
            {
                CreatedAt = DateTime.Now,
                MealId = request.MealId,
                DietId = request.DietId,
                Feedback = request.Content,
            };

            await repository.AddAsync(mealFeedback);
            await repository.SaveChangesAsync();
        }
    }
}
