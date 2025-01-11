using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Trainer;
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
    public class TrainerService : ITrainerService
    {
        private readonly IRepository repository;

        public TrainerService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<IEnumerable<AllTrainerViewModel>> ShowAllTrainersAsync()
        {
            var models = await repository.AllAsReadOnly<Trainer>()
                 .Select(x => new AllTrainerViewModel
                 {
                     ImageUrl = x.ImageUrl,
                     Experience = x.Experience,
                     FirstName = x.User.FirstName,
                     LastName = x.User.LastName,
                     Id = x.Id,
                     Specialization = x.Specialization,
                 })
                 .ToListAsync();

            return models;
        }
    }
}
