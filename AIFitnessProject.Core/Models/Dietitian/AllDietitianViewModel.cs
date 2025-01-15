namespace AIFitnessProject.Core.Models.Dietitian
{
    public class AllDietitianViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Specialization { get; set; } =string.Empty;

        public int Experience { get; set; }
    }
}
