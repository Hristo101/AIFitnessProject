using AIFitnessProject.Core.Models.Document;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDocumentService
    {
        Task SendDocumentsAsync(string id, SendDocumentsViewModel model);
        Task<IEnumerable<AllDocumentsViewModel>> AllDocumentsInAdmin();
        Task<DetailsDocumentsViewModel> DetailsDocumentsInAdmin(int id);
        Task<AllDocumentsViewModel> ConfirmModel(int id);
        Task<bool> Delete(int id);
        Task<bool> Accept(int id);
    }
}
