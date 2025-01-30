using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Document;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Formats.Asn1.AsnWriter;

namespace AIFitnessProject.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public DocumentService(IRepository _repository,UserManager<ApplicationUser> _userManager)
        {
            this.repository = _repository;
            this.userManager = _userManager;
        }

        public async Task SendDocumentsAsync(string id, SendDocumentsViewModel model)
        {
            var user = await repository.All<ApplicationUser>()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            if (user != null)
            {
                Document document = new Document()
                {
                    UserId = user.Id,
                    Position = model.Position,
                    IsAccept = false,
                    Bio = model.Bio,
                    ExperienceYears = model.ExperienceYears,
                    SertificationDetails = model.CertificationDetails,
                    Specialization = model.Specialization,
                
                };

                if (model.CertificateImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.CertificateImage.CopyToAsync(memoryStream);
                        string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                        document.SertificateImage = base64Image;
                    }
                }

                await repository.AddAsync(document);
                await repository.SaveChangesAsync();

            };

                
            
        }
        public async Task<IEnumerable<AllDocumentsViewModel>> AllDocumentsInAdmin()
        {
            var models = await repository.AllAsReadOnly<Document>().Include(x => x.User)
                .Where(x =>x.IsAccept == false)
                 .Select(x => new AllDocumentsViewModel() 
                 { 
                     Id = x.Id,
                   FirstName = x.User.FirstName,
                   LastName = x.User.LastName,
                   Position = x.Position,
                   Specialization = x.Specialization,
                   ProfilePictureUrl = x.User.ProfilePicture,
                 })
                 .ToListAsync();

            return models;
        }

        public async Task<DetailsDocumentsViewModel> DetailsDocumentsInAdmin(int id)
        {
          var model = await repository.AllAsReadOnly<Document>()
                .Where(x => x.Id == id)
                .Include(x => x.User)
                .Select(x => new DetailsDocumentsViewModel()
                {
                    Id = x.Id,
                    Specialization = x.Specialization,
                    Bio = x.Bio,
                    CertificationDetails = x.SertificationDetails,
                    CertificateImage = x.SertificateImage,
                    ExperienceYears = x.ExperienceYears,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Position= x.Position,
                    ProfilePicture = x.User.ProfilePicture,
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<AllDocumentsViewModel> ConfirmModel(int id)
        {
            var model = await repository.AllAsReadOnly<Document>()
                     .Where(x =>x.Id == id)
                    .Include(x => x.User)
                     .Select(x => new AllDocumentsViewModel()
                     {
                         Id = x.Id,
                         FirstName = x.User.FirstName,
                         LastName = x.User.LastName,
                         Position = x.Position,
                         Specialization = x.Specialization,
                         ProfilePictureUrl = x.User.ProfilePicture,
                     })
                     .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await repository.All<Document>()
           .Where(x => x.Id == id)
          .FirstAsync();

            if (model == null)
            {
                return false;
            }

            repository.Delete(model);
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Accept(int id)
        { 

            var model = await repository.All<Document>()
           .Where(x => x.Id == id)
           .Include(x => x.User)
           .FirstAsync();

            model.IsAccept = true;

            if (model == null)
            {
                return false;
            }
            var user = await userManager.FindByIdAsync(model.UserId);

            if (model.Position == "Trainer")
            {
                Trainer trainer = new Trainer()
                {
                    SertificationDetails = model.SertificationDetails,
                    Bio = model.Bio,
                    Experience = model.ExperienceYears,
                    SertificateImage = model.SertificateImage,
                    Specialization = model.Specialization,
                    UserId = model.UserId,
                    User = model.User,

                };
               
                await repository.AddAsync(trainer);
                await userManager.AddToRoleAsync(user, "Trainer");
                await repository.SaveChangesAsync();
            }
            else
            {
                Dietitian dietitian = new Dietitian()
                {
                    SertificationDetails = model.SertificationDetails,
                    Bio = model.Bio,
                    Experience = model.ExperienceYears,
                    SertificateImage = model.SertificateImage,
                    Specialization = model.Specialization,
                    UserId = model.UserId,
                    User = model.User,
                };

                await repository.AddAsync(dietitian);
                await userManager.AddToRoleAsync(user, "Dietitian");
                await repository.SaveChangesAsync();
            }

           

           
            return true;
        }
    }
}
