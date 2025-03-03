using AIFitnessProject.Core.Models.UserComments;

namespace AIFitnessProject.Core.Models.Dietitian
{
    public class DetailsDietitianForUserViewModel
    {
        public int DietitianId { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string SertificationImage { get; set; }

        public string Specialization { get; set; }

        public string DietitianImage { get; set; }

        public List<UserCommentForDietitianViewModel> Comments { get; set; } = new List<UserCommentForDietitianViewModel>();

        public string SertificationDetails { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
