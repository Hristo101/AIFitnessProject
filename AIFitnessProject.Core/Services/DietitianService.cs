using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Trainer;
using AIFitnessProject.Core.Models.UserComments;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;




namespace AIFitnessProject.Core.Services
{
    public class DietitianService : IDietitianService
    {
        private readonly IRepository repository;

        public DietitianService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AllDietitianViewModel>> AllDietitianAsync()
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Include(x =>x.User)
                .Select(x => new AllDietitianViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.User.ProfilePicture,
                    Experience = x.Experience,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Specialization = x.Specialization,
                })
                .ToListAsync();

            return dietitian;


        }

        public async Task<DetailsDietitianViewModel> DetailsDietitianAsync(int id)
        {
            
            var dietitian = await repository.All<Dietitian>()
                                          .Where(d => d.Id == id)
                                          .Include(d => d.User)
                                          .FirstAsync();

            var comments = await repository.All<UserComment>()
                                         .Where(c => c.ReceiverId == dietitian.UserId)
                                         .ToListAsync();

            var users = await repository.AllAsReadOnly<ApplicationUser>().ToListAsync();

            var model = new DetailsDietitianViewModel()
            {
                FirstName = dietitian.User.FirstName,
                LastName = dietitian.User.LastName,
                Bio = dietitian.Bio,
                SertificationImage = dietitian.SertificationImage,
                DietitianImage = dietitian.User.ProfilePicture,
                SertificationDetails = dietitian.SertificationDetails,
                PhoneNumber = dietitian.PhoneNumber,
                Specialization = dietitian.Specialization,
                Email = dietitian.User.Email,
                Comments = comments.Select(c => new UserCommentViewModel
                {
                    Rating = c.Rating,
                    Content = c.Content,
                    SenderName = users.FirstOrDefault(x => x.Id == c.SenderId).FirstName + " " + users.FirstOrDefault(x => x.Id == c.SenderId).LastName
                }).ToList()

            };


            return model;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Dietitian>()
                .AnyAsync(x=>x.Id == id);
        }
    }
}
