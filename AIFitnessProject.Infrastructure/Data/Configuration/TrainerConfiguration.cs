using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(SeedTrainers());
        }
        private List<Trainer> SeedTrainers()
        {
            Trainer trainer;
            List<Trainer> trainers = new List<Trainer>();

            trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тренировки за издръжливост",
                Experience = 5,
                SertificationDetails = "Здравейте, аз съм сертифициран персонален треньор (CPT) с богат опит в изграждането на индивидуални тренировъчни програми. Моето призвание е да ви помогна да постигнете своите цели чрез ефективни и добре обмислени тренировки.",
                ImageUrl = "https://momichetata.com/media/1/2024/01/18/117000/original.jpg",
                UserId = "0e136956-3e82-4e00-8f60-b274cdf40833" 
            };
            trainers.Add(trainer);

            trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!",
                ImageUrl = "https://pulsefit.bg/uploads/cache/N/public/uploads/media-manager/app-modules-trainers-models-trainer/305/6874/novo.png",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" 
            };
            trainers.Add(trainer);

            return trainers;
        }

    }
}
