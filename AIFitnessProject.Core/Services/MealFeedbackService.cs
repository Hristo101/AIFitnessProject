using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteMealFeedbackAsync(DeleteCommentModelDTO model)
        {
            var mealFeedback = await repository.All<MealFeedback>()
           .Where(x => x.DietId == model.DietId && x.MealId == model.MealId)
           .FirstAsync();

            if (mealFeedback == null)
            {
                throw new ArgumentException("Въведени са невалинни данни!");
            }

            repository.Delete(mealFeedback);
            await repository.SaveChangesAsync();
        }

        public async Task EditMealFeedbackAsync(SubmitCommentRequestDTO request)
        {
            var mealFeedback = await repository.All<MealFeedback>()
               .Where(x => x.DietId == request.DietId && x.MealId == request.MealId)
               .FirstAsync();

            if (mealFeedback == null)
            {
                throw new ArgumentException("Въведени са невалинни данни!");
            }
            mealFeedback.Feedback = request.Content;
            await repository.SaveChangesAsync();
        }
    }
}
