using AIFitnessProject.Core.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IExerciseService
    {
        Task<AllExerciseViewModel> GetModelForDetails(int id);
    }
}
