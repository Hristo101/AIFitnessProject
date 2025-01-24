using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Home;
using AIFitnessProject.Core.Models.Opinion;
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

        public async Task<IEnumerable<AllDietitianOpinionViewModel>> AllDietitianOpinionAsync()
        {
            var model = await _repository.AllAsReadOnly<Opinion>()
                .Include(x => x.Sender)
                .ThenInclude(x => x.Dietitian)
                .Where(x => x.SenderId == x.Sender.Dietitian.UserId)
                .Select(x => new AllDietitianOpinionViewModel()
                {
                    FirstName = x.Sender.FirstName,
                    LastName = x.Sender.LastName,
                    Rating = x.Rating,
                    Content = x.Content,
                    DietitianImageUrl = x.Sender.Dietitian.User.ProfilePicture
                })
                .ToListAsync();

            return model;


        }

        public async Task<HomeViewModel> GetModelsForHomePageAsync()
        {
            var trainers = await _repository.AllAsReadOnly<Trainer>().Include(t => t.User).Select(x => new IndexTrainerViewModel()
            {
                FirstName = x.User.FirstName,
                ImageUrl = x.User.ProfilePicture,
            }).ToListAsync();

            var dietitians = await _repository.AllAsReadOnly<Dietitian>().Include(t => t.User).Select(x => new IndexDiatitianViewModel()
            {
                FirstName = x.User.FirstName,
                ImageUrl = x.User.ProfilePicture,
            }).ToListAsync();

            var model = new HomeViewModel()
            {
                Dietitians = dietitians,
                Trainers = trainers
            };

            return model;
        }
        public async Task<IEnumerable<AllOpinionViewModel>> GetModelsForHowWeWorkPageAsync()
        {
            var model = await _repository.AllAsReadOnly<Opinion>()
                .Include(t =>t.Sender)
                .ThenInclude(a => a.Trainer)
                .Where(x => x.SenderId == x.Sender.Trainer.UserId)
                .Select(x => new AllOpinionViewModel()
                {
                    Content = x.Content,
                    FirstName = x.Sender.FirstName,
                    LastName = x.Sender.LastName,
                    Rating = x.Rating,
                    TrainerImageUrl = x.Sender.Trainer.User.ProfilePicture,
                })
                .ToListAsync();

            return model;
        }
    }
}
