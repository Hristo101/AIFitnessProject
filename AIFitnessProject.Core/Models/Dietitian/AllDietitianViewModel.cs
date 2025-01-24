namespace AIFitnessProject.Core.Models.Dietitian
{
    public class AllDietitianViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public byte[]? ImageUrl { get; set; }

        public string Specialization { get; set; } =string.Empty;

        public int Experience { get; set; }
    }
}
