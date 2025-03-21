﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Workout;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Workout Table")]
    public class Workout
    {
        [Key]
        [Comment("Workout Identifier")]
        public int Id { get; set; }
        [Comment("Workout Image")]
        public string ImageUrl { get; set; }
        [Comment("Workout Title")]
        public string Title { get; set; }

        [Required]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Trainer Trainer { get; set; }

        [Required]
        [MaxLength(MaxDayOfWeekLength)]
        [Comment("Workout Day Of Week")]
        public string DayOfWeek { get; set; } = string.Empty;

        [Required]
        [Comment("Workout Order In Workout")]
        public int OrderInWorkout {  get; set; }
        [Required]
        public string DificultyLevel { get; set; }
        [Required]
        public string MuscleGroup { get; set; }

        public ICollection<CalendarWorkout> CalendarWorkouts { get; set; }
        public ICollection<WorkoutsExercise> WorkoutsExercises { get; set; } = new List<WorkoutsExercise>();
        public ICollection<TrainingPlanWorkout> TrainingPlanWorkouts { get; set; } = new List<TrainingPlanWorkout>();
    }
}
