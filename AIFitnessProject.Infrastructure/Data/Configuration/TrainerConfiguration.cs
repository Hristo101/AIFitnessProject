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
                Specialization = "Издръжливост и функционален фитнес",
                Experience = 5,
                SertificationImage = "https://dani-sport.eu/wp-content/uploads/2021/06/UDOSTOVERENIE_TRENER_R-688x500.jpg", // Сертификат за фитнес треньор
                Bio = "Даниела Манева е фитнес треньор, който активно се занимава със спорт и фитнес от 3 години. Нейната специализация е в тренировките за издръжливост и функционален фитнес. Със силно желание да помогне на своите клиенти да постигнат максимална физическа издръжливост и да повишат спортната си подготовка, тя съчетава индивидуален подход с доказани методи за тренировки.\r\nДаниела вярва, че с упоритост и правилни тренировки, всеки може да постигне отлични резултати в здравето и физическата форма.",
                PhoneNumber = "0895124157",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по издръжливост и функционален фитнес. Специализирам в създаването на тренировъчни програми, които ще повишат вашата издръжливост и функционална сила.",
                UserId = "0e136956-3e82-4e00-8f60-b274cdf40833" 
            };
            trainers.Add(trainer);

            trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificationImage = "https://fitnesstime.eu/wp-content/uploads/2018/11/fitness-licenz-nsa-min.png",
                Bio = "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация. В началото на своето фитнес пътуване той не е имал перфектно тяло, а напротив – борел се е с наднормено тегло и липса на мотивация. Със силна воля и постоянство, той успява да постигне значителни резултати и сега е не само преобразен физически, но и психически.\r\n\r\nДнес Светослав е сертифициран треньор с опит и страст за това, което прави. Неговата цел е да помага на хората да постигнат не само физическите си цели, но и да изградят здравословни навици, които да продължат през целия живот. Той вярва, че промяната е възможна за всеки, стига да има правилния подход и подкрепа.\r\n\r\n\r\n\r\n\r\n",
                PhoneNumber = "0895124157",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" 
            };
            trainers.Add(trainer);

            return trainers;
        }

    }
}
