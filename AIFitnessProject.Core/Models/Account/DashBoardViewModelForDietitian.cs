using AIFitnessProject.Core.Models.UserComments;

namespace AIFitnessProject.Core.Models.Account
{
    public class DashBoardViewModelForDietitian
    {
        public string DietitianName { get; set; }
        public string DietitianPicture { get; set; }
        public ICollection<UsersToDietitianViewModel> UsersToDietitian { get; set; } = new List<UsersToDietitianViewModel>();
        public ICollection<UserCommentForDietitianViewModel> UserCommentForDietitianViewModels { get; set; } = new List<UserCommentForDietitianViewModel>();
        public int TotalUserForTheDay { get; set; }
        public double DayChangePercent { get; set; }
        public int TotalUserForMonth { get; set; }
        public double MonthChangePercent { get; set; }
        public int TotalUserForYear { get; set; }
        public double YearChangePercent { get; set; }
        public double PercentFatPeople { get; set; }
        public double PercentWeakPeople { get; set; }
    }
}
