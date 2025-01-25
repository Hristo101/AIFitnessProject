using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;

        public AccountService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddMoreInformationAsync(string id, MoreInformationViewModel model)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(x=>x.Id == id)
                .FirstOrDefaultAsync();

            if(user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.ExperienceLevel = model.ExperienceLevel;
                user.Height = model.Height;
                user.Weight = model.Weight;
                user.Aim = model.Aim;
                if(model.ProfilePicture != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ProfilePicture.CopyToAsync(memoryStream);
                        user.ProfilePicture = memoryStream.ToArray();
                    }
                }

                await repository.SaveChangesAsync();
            }
        }

        //[Post]
        public async Task<ApplicationUser> ChangeInformation(string id, EditProfileViewModel model)
        {

            var user = await repository.All<ApplicationUser>().Where(x =>x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.Weight = model.Weight;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.ExperienceLevel = model.ExperienceLevel;
                user.Height = model.Height;
                user.UserName = model.UserName;

                if (model.NewImageUrl != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.NewImageUrl.CopyToAsync(memoryStream);
                        user.ProfilePicture = memoryStream.ToArray(); 
                    }
                }

                await repository.SaveChangesAsync();
            }

            return user;
        }
        //[Get]
        public async Task<EditProfileViewModel> Edit(string id)
        {
           var model = await repository.AllAsReadOnly<ApplicationUser>().Where(x => x.Id == id).Select(x => new EditProfileViewModel()
           {
               Email = x.Email,
                ExperienceLevel= x.ExperienceLevel,
               FirstName = x.FirstName,
               LastName = x.LastName,
               Height = x.Height,
               Weight = x.Weight,
               ImageUrl = x.ProfilePicture,
               UserName = x.UserName
           })
           .FirstOrDefaultAsync();

            return model;
        }

        public async Task<MyProfileViewModel> GetMoldelForMyProfile(string id,bool isInRole)
        {
            var model = new MyProfileViewModel();
            if (isInRole == false)
            {
                 model = await repository.AllAsReadOnly<ApplicationUser>().Where(x =>x.Id == id).Select(x => new MyProfileViewModel()
            {
                Id = x.Id,
                Email = x.Email,
                ExperienceLevel = x.ExperienceLevel,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Height = x.Height,
                Weight = x.Weight,
                     ImageUrl = x.ProfilePicture,
                     UserName = x.UserName
            })
                .FirstOrDefaultAsync();

            }
            else
            {
                model = await repository.AllAsReadOnly<ApplicationUser>().Include(x =>x.Trainer).Where(x => x.Id == id).Select(x => new MyProfileViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    ExperienceLevel = x.ExperienceLevel,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Height = x.Height,
                    Weight = x.Weight,
                    ImageUrl = x.ProfilePicture,
                    UserName = x.UserName
                }
                ).FirstOrDefaultAsync();
                
            }
            return model;
        }

    }
}
