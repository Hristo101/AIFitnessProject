using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class RequestsToCoach
    {
        [Key]
        public int Id { get; set; }
        public string Target { get; set; }
        public List<string> PicturesOfPersons { get; set; } = new List<string>();
        public string TrainingBackground { get; set; }
        public string HealthStatus { get; set; }
        public string TrainingPreferences { get; set; }
        public string TrainingCommitment { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public int TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }
    }
}
