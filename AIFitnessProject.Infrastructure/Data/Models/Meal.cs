using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public int Calories { get; set; }

        public ICollection<DietDetail> DietDetails { get; set; }
    }
}
