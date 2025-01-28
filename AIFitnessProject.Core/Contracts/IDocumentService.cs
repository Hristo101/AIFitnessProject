using AIFitnessProject.Core.Models.Document;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDocumentService
    {
        Task SendDocumentsAsync(string id, SendDocumentsViewModel model);
        Task<IEnumerable<AllDocumentsViewModel>> AllDocumentsInAdmin();
        Task<DetailsDocumentsViewModel> DetailsDocumentsInAdmin(int id);
    }
}
