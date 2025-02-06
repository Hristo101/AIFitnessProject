using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
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
    public class ExerciseService : IExerciseService
    {
        private readonly IRepository repository;

        public ExerciseService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<AllExerciseViewModel> GetModelForDetails(int id)
        {
            var exercise = await repository.AllAsReadOnly<Exercise>()
                .Where(x =>x.Id == id)
                .Select(x => new AllExerciseViewModel()
                {
                    Description = x.Description,
                    DifficultyLevel = x.DifficultyLevel,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    MuscleGroup = x.MuscleGroup,
                    Name = x.Name,
                    Repetitions = x.Repetitions,
                    Series = x.Series,
                }).FirstAsync();

            return exercise;
        }
    }
}
