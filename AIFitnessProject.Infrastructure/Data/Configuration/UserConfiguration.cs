using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<ApplicationUser> SeedUsers()
        {
            ApplicationUser user;
            List<ApplicationUser> users = new List<ApplicationUser>();

            var hasher = new PasswordHasher<ApplicationUser>();

            string defaultImage = GetDefaultProfilePictureBase64();

            user = new ApplicationUser()
            {
                Id = "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                ProfilePicture = defaultImage,
                UserName = "stanislav@abv.bg",
                NormalizedUserName = "STANISLAV@ABV.BG",
                Email = "stanislav@abv.bg",
                NormalizedEmail = "STANISLAV@ABV.BG",
                FirstName = "Stanislav",
                LastName = "Ivanov",
                Height = 1.95,
                Weight = 131.5,
                ExperienceLevel = "Начинаещ,почти не съм влизал в зала да спортувам.Изглеждам ужасно и искам да отслабна!",
                SecurityStamp = "9e406138-c088-4d10-810a-8cb287aa339b",
                ConcurrencyStamp = "c37f9e70-f9ff-4e55-8c95-83ce9708cef7",
                PasswordHash = hasher.HashPassword(null, "stanislav123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0e136956-3e82-4e00-8f60-b274cdf40833",
                ProfilePicture = defaultImage,
                UserName = "daniela_5",
                NormalizedUserName = "DANIELA_5",
                Email = "daniela@abv.bg",
                NormalizedEmail = "DANIELA@ABV.BG",
                FirstName = "Даниела",
                LastName = "Манева",
                Height = 1.70,
                Weight = 55,
                ExperienceLevel = "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост",
                SecurityStamp = "ddfff353-d2cc-4d0c-a9cd-c40f2914296b",
                ConcurrencyStamp = "e105f213-ede3-4a80-842f-3c9dc11968f3",
                PasswordHash = hasher.HashPassword(null, "daniela123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = defaultImage,
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 2.03,
                Weight = 92,
                ExperienceLevel = "Имам някакъв малък опит с фитнес залите целта ми е да стана 100 кила,но килограмите,които кача да бъдат мускулна маса",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
                PasswordHash = hasher.HashPassword(null, "pesho123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = defaultImage,
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
                Height = 2.03,
                Weight = 82,
                ExperienceLevel = "Активно спортуващ,занимавал съм се с фитнес от 10 години,целта ми е да направя всички трениращи в това приложение да харесват своята визия",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
                PasswordHash = hasher.HashPassword(null, "svetoslav123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                ProfilePicture = defaultImage,
                UserName = "rosalina102",
                NormalizedUserName = "ROSALINA102",
                Email = "rosalina@abv.bg",
                NormalizedEmail = "ROSALINA@ABV.BG",
                FirstName = "Росалина",
                LastName = "Узунова",
                Height = 1.70,
                Weight = 57,
                ExperienceLevel = "Росалина Узунова е диетолог с дългогодишен опит, чиято цел е да помогне на хората да постигнат здравословен начин на живот и да обикнат своята визия. Тя създава персонализирани диетични планове, които водят до дълготрайни резултати и увереност в тялото.",
                PasswordHash = hasher.HashPassword(null, "rosalina123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                ProfilePicture = defaultImage,
                UserName = "zhenya123",
                NormalizedUserName = "ZHENYA123",
                Email = "zhenya@abv.bg",
                NormalizedEmail = "ZHENYA@ABV.BG",
                FirstName = "Женя",
                LastName = "Желязкова",
                Height = 1.68,
                Weight = 60,
                ExperienceLevel = "Женя Желязкова е диетолог с дългогодишен опит, която се стреми да помогне на хората да водят здравословен начин на живот и да се чувстват уверени в своята визия. Тя създава индивидуални диетични програми, които водят до трайни резултати и по-добро самочувствие.",
                PasswordHash = hasher.HashPassword(null, "zhenya123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "5df58ef6-da85-4d1d-a429-001e0856de72",
                ProfilePicture = defaultImage,
                UserName = "Terry26",
                NormalizedUserName = "TERRY_26",
                Email = "hserev789@gmail.com",
                NormalizedEmail = "HSEREV789@GMAIL.COM",
                FirstName = "Христо",
                LastName = "Щерев",
                Height = 1.87,
                Weight = 80,
                ExperienceLevel = "Напреднал",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "Chelsea2012"),
            };
            users.Add(user);
            return users;
        }
        private string GetDefaultProfilePictureBase64()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Default Image", "default-profile.png");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes); 
        }
    }
}
