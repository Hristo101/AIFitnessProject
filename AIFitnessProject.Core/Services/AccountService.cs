using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                if (model.ProfilePicture != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ProfilePicture.CopyToAsync(memoryStream);
                        user.ProfilePicture = Convert.ToBase64String(memoryStream.ToArray()); // Запазваме като string
                    }
                }

                await repository.SaveChangesAsync();
            }
        }


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
                        string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                        user.ProfilePicture = base64Image;
                    }
                }

                await repository.SaveChangesAsync();
            }

            return user;
        }

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

        public async Task<ICollection<AllUsersViewModel>> GetAllDietitianClients(string userId)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            var usersViewModel = await repository.AllAsReadOnly<Diet>()
                .Include(x => x.User)
                .Where(x => x.CreatedById == dietitian.Id)
                .Select(x => new AllUsersViewModel()
                {
                    IsInCalendar = x.IsInCalendar,
                    UserId = x.UserId,
                    Aim = x.User.Aim,
                    Email = x.User.Email,
                    ExperienceLevel = x.User.ExperienceLevel,
                    FirsName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ProfilePicture = x.User.ProfilePicture
                })
                .ToListAsync();

            return usersViewModel;
        }

        public async Task<ICollection<AllUsersViewModel>> GetAllUsers(string userId)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                 .Where(x => x.UserId == userId)
                 .FirstOrDefaultAsync();

            var usersViewModel = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(x =>x.User)
                .Where(x =>x.CreatedById == trainer.Id)
                .Select(x => new AllUsersViewModel()
                {
                    UserId = x.UserId,
                    IsInCalendar = x.IsInCalendar,
                    Aim = x.User.Aim,
                    Email = x.User.Email,
                    ExperienceLevel = x.User.ExperienceLevel,
                    FirsName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ProfilePicture = x.User.ProfilePicture
                })
                .ToListAsync();

            return usersViewModel;
                
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

        public async Task<MyDietitianViewModel> GetViewModelForMyDietitian(string userId)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.Id == diet.CreatedById)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            MyDietitianViewModel model = new MyDietitianViewModel()
            {
                DietitianId = dietitian.Id,
                Email = dietitian.User.Email,
                FirstName = dietitian.User.FirstName,
                LastName = dietitian.User.LastName,
                Expirience = dietitian.Experience,
                ProfilePicture = dietitian.User.ProfilePicture,
                Specialization = dietitian.Specialization,
            };

            return model;
        }

        public async Task<MyTrainerViewModel> GetViewModelForMyTrainer(string userId)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                 .Where(x => x.UserId == userId)
                 .FirstOrDefaultAsync();

            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x =>x.Id == trainingPlan.CreatedById)
                .Include(x =>x.User)
                .FirstOrDefaultAsync();

            MyTrainerViewModel model = new MyTrainerViewModel()
            {
                TrainerId = trainer.Id,
                Email = trainer.User.Email,
                FirstName = trainer.User.FirstName,
                LastName = trainer.User.LastName,
                Expirience = trainer.Experience,
                ProfilePicture = trainer.User.ProfilePicture,
                Specialization = trainer.Specialization,
            };

            return model;
        }
    }
}
