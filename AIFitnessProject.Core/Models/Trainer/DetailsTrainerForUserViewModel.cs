using AIFitnessProject.Core.Models.UserComments;

namespace AIFitnessProject.Core.Models.Trainer
{
    public class DetailsTrainerForUserViewModel
    {
        public int TrainerId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string SertificationImage { get; set; }
        public string Specialization { get; set; }
        public string TrainerImage { get; set; }
        public List<UserCommentForTrainerViewModel> Comments { get; set; } = new List<UserCommentForTrainerViewModel>();
        public string SertificationDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
