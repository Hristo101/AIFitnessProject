using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public int TrainingPlanId { get; set; }

        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlans { get; set; }

        public int ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }

        public string DayOfWeek { get; set; }

        public int OrderInWorkout {  get; set; }
    }
}
