using AIFitnessProject.Core.Models.UserComments;

namespace AIFitnessProject.Core.Models.Dietitian
{
    public class DetailsDietitianViewModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string SertificationImage { get; set; } 

        public string Specialization { get; set; } = string.Empty;

        public string DietitianImage { get; set; }

        public List<UserCommentViewModel> Comments { get; set; } = new List<UserCommentViewModel>();

        public string SertificationDetails { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
