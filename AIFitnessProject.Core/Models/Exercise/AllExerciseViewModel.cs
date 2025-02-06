using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Exercise
{
    public class AllExerciseViewModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string MuscleGroup { get; set; }
        public string DifficultyLevel { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set;}
    }
}
