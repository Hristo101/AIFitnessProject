using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Document;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository repository;

        public DocumentService(IRepository _repository)
        {
            this.repository = _repository;
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
                        document.SertificateImage = memoryStream.ToArray();
                    }
                }

                await repository.AddAsync(document);
                await repository.SaveChangesAsync();

            };

                
            
        }
    }
}
