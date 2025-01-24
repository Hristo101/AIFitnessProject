﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Trainer;
using AIFitnessProject.Core.Models.UserComments;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<UserComment>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<DetailsTrainerViewModel> GetViewModelForDetails(int trainerId)
        {
            var trainer = await repository.All<Trainer>()
                                          .Where(t => t.Id == trainerId)
                                          .Include(t => t.User) 
                                          .FirstOrDefaultAsync();
            if (trainer == null)
            {
                return null;
            }

            var comments = await repository.All<UserComment>()
                                           .Where(c => c.ReceiverId == trainer.UserId)
                                           .ToListAsync();

            var users =await repository.AllAsReadOnly<ApplicationUser>().ToListAsync();

            var viewModel = new DetailsTrainerViewModel
            {
                FirstName = trainer.User.FirstName,
                LastName = trainer.User.LastName,
                Bio = trainer.Bio,
                SertificationImage = trainer.SertificationImage,
                //TrainerImage = trainer.ImageUrl,
                SertificationDetails = trainer.SertificationDetails,
                PhoneNumber = trainer.PhoneNumber,
                Specialization = trainer.Specialization,
                Email = trainer.User.Email,
                Comments = comments.Select(c => new UserCommentViewModel
                {
                    Rating = c.Rating,
                    Content = c.Content,
                    SenderName = users.FirstOrDefault(x =>x.Id == c.SenderId).FirstName + " " + users.FirstOrDefault(x => x.Id == c.SenderId).LastName
                }).ToList()  
            };

            return viewModel;
        }

        public async Task<IEnumerable<AllTrainerViewModel>> ShowAllTrainersAsync()
        {
            var models = await repository.AllAsReadOnly<Trainer>()
                 .Select(x => new AllTrainerViewModel
                 {
                     //ImageUrl = x.ImageUrl,
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
