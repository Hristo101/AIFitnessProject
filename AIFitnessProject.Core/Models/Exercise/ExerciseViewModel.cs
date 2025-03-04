namespace AIFitnessProject.Core.Models.Exercise
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public int? TrainingPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string MuscleGroup { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
