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

        public async Task<MyProfileViewModel> GetMoldelForMyProfile(string id)
        {
            var model = await repository.AllAsReadOnly<ApplicationUser>().Where(x =>x.Id == id).Select(x => new MyProfileViewModel()
            {
                Email = x.Email,
                ExperienceLevel = x.ExperienceLevel,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Height = x.Height,
                Weight = x.Weight,
                ImageUrl = x.ImageUrl,
                UserName = x.UserName
            })
                .FirstOrDefaultAsync();

            return model;
        }

    }
}
