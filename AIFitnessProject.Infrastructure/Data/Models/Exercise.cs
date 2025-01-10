using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public string MuscleGroup{ get; set; }

        public string DifficultyLevel { get; set; }

        public ICollection<Workout> Workouts { get; set; }

    }
}
