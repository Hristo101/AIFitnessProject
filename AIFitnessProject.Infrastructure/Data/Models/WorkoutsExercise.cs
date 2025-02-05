using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class WorkoutsExercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ExcersiceId { get; set; }
        [ForeignKey(nameof(ExcersiceId))]
        public Exercise Exercise { get; set; }


        [Required]
        public int WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

    }
}
