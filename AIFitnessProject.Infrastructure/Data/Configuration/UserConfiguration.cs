﻿using AIFitnessProject.Infrastructure.Data.Models;
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
                UserName = "stanislav",
                NormalizedUserName = "STANISLAV",
                Email = "pierceabv245@gmail.com",
                NormalizedEmail = "PIERCEABV245@GMAIL.COM",
                FirstName = "Stanislav",
                LastName = "Ivanov",
                Height = 195,
                Aim = "Целта ми е да отслабна.С това надмормено тегло много се затруднявам и искам да стана поне 110 килограма,защото въобще не харесвам своята визия.",
                Weight = 131.5,
                ExperienceLevel = "Начинаещ",
                SecurityStamp = "9e406138-c088-4d10-810a-8cb287aa339b",
                ConcurrencyStamp = "c37f9e70-f9ff-4e55-8c95-83ce9708cef7",
                PasswordHash = hasher.HashPassword(null, "stanislav123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0e136956-3e82-4e00-8f60-b274cdf40833",
                ProfilePicture = "https://chernomorie-bg.com/uploads/posts/IMG_3366_1.jpg",
                UserName = "daniela",
                NormalizedUserName = "DANIELA",
                Email = "pmgclaude.team06@gmail.com",
                NormalizedEmail = "PMGCLAUDE.TEAM06@GMAIL.COM",
                FirstName = "Даниела",
                LastName = "Манева",
                Height = 170,
                Weight = 55,
                ExperienceLevel = "Напреднал",
                SecurityStamp = "ddfff353-d2cc-4d0c-a9cd-c40f2914296b",
                ConcurrencyStamp = "e105f213-ede3-4a80-842f-3c9dc11968f3",
                PasswordHash = hasher.HashPassword(null, "daniela123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = defaultImage,
                UserName = "pesho",
                NormalizedUserName = "PESHO",
                Email = "jordanmilchev87@gmail.com",
                NormalizedEmail = "JORDANMILCHEV87@GMAIL.COM",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                Aim = "Искам да покача своята мускулна маса.Целта ми е да стана около 95 килограма,но да кача само мускулна маса.",
                ExperienceLevel = "Начинаещ",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
                PasswordHash = hasher.HashPassword(null, "pesho123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav",
                ProfilePicture = "https://nicksfitstyle.com/wp-content/uploads/img12-scaled.jpg",
                NormalizedUserName = "SVETOSLAV",
                Email = "pierceabv980@gmail.com",
                NormalizedEmail = "PIERCEABV980@GMAIL.COM",
                FirstName = "Светослав",
                LastName = "Ковачев",
                Height = 203,
                Weight = 82,
                ExperienceLevel = "Напреднал",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
                PasswordHash = hasher.HashPassword(null, "svetoslav123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                ProfilePicture = "https://stomed.ru/storage/news/4/344/neozidannye-situacii-v-kotoryx-pomozet-dietolog-8986.jpg",
                UserName = "rosalina",
                NormalizedUserName = "ROSALINA",
                Email = "jd6125416@gmail.com",
                NormalizedEmail = "JD6125416@GMAIL.COM",
                FirstName = "Росалина",
                LastName = "Узунова",
                Height = 170,
                Weight = 57,
                ExperienceLevel = "Напреднал",
                PasswordHash = hasher.HashPassword(null, "rosalina123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                ProfilePicture = "https://dietyc.com/wp-content/uploads/2023/03/nutritionist-dietolog.jpeg",
                UserName = "zhenya",
                NormalizedUserName = "ZHENYA",
                Email = "m.smith.online@gmail.com",
                NormalizedEmail = "M.SMITH.ONLINE@GMAIL.COM",
                FirstName = "Женя",
                LastName = "Желязкова",
                Height = 168,
                Weight = 60,
                ExperienceLevel = "Напреднал",
                PasswordHash = hasher.HashPassword(null, "zhenya123"),
            };
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "5df58ef6-da85-4d1d-a429-001e0856de72",
                ProfilePicture = defaultImage,
                UserName = "Terry26",
                NormalizedUserName = "TERRY26",
                Email = "hserev789@gmail.com",
                NormalizedEmail = "HSEREV789@GMAIL.COM",
                FirstName = "Христо",
                LastName = "Щерев",
                Height = 187,
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
