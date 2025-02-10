using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Exercise
{
    public class EditExerciseViewModel
    {
        public int? Id { get; set; }
        public int? TrainingPlanId { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(100, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1500, ErrorMessage = "Описанието трябва да е максимум {1} символа.")]
        public string Description { get; set; }

        public string? ExistingImageUrl { get; set; }

        public IFormFile? NewImage { get; set; }

        [Required(ErrorMessage = "Видео линкът е задължителен.")]
        [Url(ErrorMessage = "Моля, въведете валиден URL адрес.")]
        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "Мускулната група е задължителна.")]
        public string MuscleGroup { get; set; }

        [Range(1, 10, ErrorMessage = "Сериите трябва да бъдат между {1} и {2}.")]
        public int Series { get; set; }

        [Range(1, 50, ErrorMessage = "Повторенията трябва да бъдат между {1} и {2}.")]
        public int Repetitions { get; set; }

        [Required(ErrorMessage = "Изберете ниво на трудност.")]
        public string DifficultyLevel { get; set; }
    }
}
