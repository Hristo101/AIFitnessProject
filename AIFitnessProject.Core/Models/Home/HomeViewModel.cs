using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Trainer;

namespace AIFitnessProject.Core.Models.Home
{
    public class HomeViewModel
    {
        public List<IndexDiatitianViewModel> Dietitians { get; set; }
        public List<IndexTrainerViewModel> Trainers { get; set; }
    }
}
