using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Meal
{
    public class MealViewModel
    {
        public int Id { get; set; }

        public int DietId { get; set; }

        public string Name { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public int Calories { get; set; }

        public string MealTime { get; set; }

        public string DificultyLevel { get; set; }
    }
}
