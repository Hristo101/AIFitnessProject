using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Home;
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
    public class HomeService : IHomeService
    {
        private readonly IRepository _repository;

        public HomeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<HomeViewModel> GetModelsForHomePageAsync()
        {
            var trainers = await _repository.AllAsReadOnly<Trainer>().Include(t => t.User).Select(x => new IndexTrainerViewModel()
            {
                FirstName = x.User.FirstName,
                ImageUrl = x.ImageUrl,
            }).ToListAsync();

            var dietitians = await _repository.AllAsReadOnly<Dietitian>().Include(t => t.User).Select(x => new IndexDiatitianViewModel()
            {
                FirstName = x.User.FirstName,
                ImageUrl = x.ImageUrl,
            }).ToListAsync();

            var model = new HomeViewModel()
            {
                Dietitians = dietitians,
                Trainers = trainers
            };

            return model;
        }
    }
}
