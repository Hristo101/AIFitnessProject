namespace AIFitnessProject.Core.Models.Document
{
    public class AllDocumentsViewModel
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;
    }
}
