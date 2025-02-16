using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.DTOs
{
    public class DeleteCommentModel
    {
        public int? ExerciseId { get; set; }
        public int TrainingPlanId { get; set; }
    }
}
