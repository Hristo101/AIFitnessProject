using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIFitnessProject.Infrastructure.Data.Models;

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

            user = new ApplicationUser()
            {
                Id = "0a2830ef-8be3-4ef6-910b-33b680d659d3",
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
                UserName = "petq@abv.bg",
                NormalizedUserName = "PETQ@ABV.BG",
                Email = "petq@abv.bg",
                NormalizedEmail = "PETQ@ABV.BG",
                FirstName = "Petq",
                LastName = "Ivanova",
                Height = 1.70,
                Weight = 55,
                ExperienceLevel = "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост",
                SecurityStamp = "ddfff353-d2cc-4d0c-a9cd-c40f2914296b",
                ConcurrencyStamp = "e105f213-ede3-4a80-842f-3c9dc11968f3",
                PasswordHash = hasher.HashPassword(null, "petq123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
                PasswordHash = hasher.HashPassword(null, "pesho123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "teodor@abv.bg",
                NormalizedUserName = "TEODOR@ABV.BG",
                Email = "teodor@abv.bg",
                NormalizedEmail = "TEODOR@ABV.BG",
                FirstName = "Teodor",
                LastName = "Ivanov",
                Height = 2.03,
                Weight = 82,
                ExperienceLevel = "Активно спортуващ,занимавала съм се с фитнес от 3 години,но не мога да натрупам мускулна маса",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
                PasswordHash = hasher.HashPassword(null, "teodor123"),
            };
            users.Add(user);

            return users;
        }
    }
}
