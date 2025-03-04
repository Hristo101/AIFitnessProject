namespace AIFitnessProject.Core.Models.Document
{
    public class DetailsDocumentsViewModel
    {
        public int Id { get; set; }

        public string Position { get; set; } = string.Empty;

        public string ProfilePicture { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }

        public string CertificateImage { get; set; }

        public string Bio { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string CertificationDetails { get; set; } = string.Empty;
    }
}
