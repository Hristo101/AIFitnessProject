﻿using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class DietitianConfiguration : IEntityTypeConfiguration<Dietitian>
    {
        public void Configure(EntityTypeBuilder<Dietitian> builder)
        {
            builder.HasData(SeedDietition());
        }
        private List<Dietitian> SeedDietition()
        {
            Dietitian dietitian;
            List<Dietitian> dietitians = new List<Dietitian>();

            string firstDietitianSertificationImage = GetFirstDietitianSertificationImage();
            string secondDietitianSertificationImage = GetSecondDietitianSertificationImage();
            dietitian = new Dietitian()
            {
                Id = 1,
                Specialization = "Покачване на мускулна маса",
                Experience = 8,
                SertificateImage = firstDietitianSertificationImage,
                Bio = "Росалина Узунова е опитен диетолог, специализирала в покачването на мускулна маса и оптимизация на физическата форма. Завършила е специалност \"Хранене и диетология\" и е работила с различни клиенти – от аматьори до професионални атлети. Тя вярва, че правилната диета е не по-малко важна от тренировките за постигането на желаните резултати и предлага персонализирани хранителни планове, които са насочени към оптимално усвояване на хранителни вещества и растеж на мускулите.",
                PhoneNumber = "0886352233",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по покачване на мускулна маса. Специализирам в създаването на хранителни режими, които ще повишат вашата сила и мускулна маса. С правилното хранене и постоянство в тренировките, всяка капка усилие ще се превърне в здрава мускулна маса и нови постижения!",
                UserId = "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708"
            };
            dietitians.Add(dietitian);

            dietitian = new Dietitian()
            {
                Id = 2,
                Specialization = "Отслабване и изгаряне на мазнини",
                Experience = 4,
                SertificateImage = secondDietitianSertificationImage,
                Bio = "Женя Желязкова е сертифициран диетолог със специализация в отслабването и изгарянето на мазнини, с над 4 години опит в трансформирането на тела и навици. Вярва, че всяко тяло е уникално и предлага персонализирани хранителни режими, съчетани с научно обосновани методи за дълготрайни резултати. Работи активно със спортисти и фитнес ентусиасти, помагайки им да постигнат оптимална форма и здраве. Постоянно се усъвършенства, следвайки последните тенденции в спортното хранене и метаболитната оптимизация. За нея здравословното хранене не е диета, а начин на живот.",
                PhoneNumber = "0874856290",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по отслабване и изгаряне на мазнини. Специализирам в създаването на хранителни режими, които помагат за отслабване и изгаряне на мазнини. Заедно ще постигнем вашата мечтана визия и ще постигнем всички цели!",
                UserId = "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8"
            };
            dietitians.Add(dietitian);

            return dietitians;
        }

        private string GetFirstDietitianSertificationImage()
        {         
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Dietitian Sertificate Image", "SertificateImageRosalina.jpg");
            byte[] fileBytes = File.ReadAllBytes(filePath);

            return Convert.ToBase64String(fileBytes);
        }

        private string GetSecondDietitianSertificationImage()
        {
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Dietitian Sertificate Image", "sertificateImageZhenya.png");
            byte[] fileBytes = File.ReadAllBytes(filePath);

            return Convert.ToBase64String(fileBytes);
        }
    }
}
