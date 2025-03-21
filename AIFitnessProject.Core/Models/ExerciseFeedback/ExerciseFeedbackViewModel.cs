﻿namespace AIFitnessProject.Core.Models.ExerciseFeedback
{
    public class ExerciseFeedbackViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public string Feedback { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}
