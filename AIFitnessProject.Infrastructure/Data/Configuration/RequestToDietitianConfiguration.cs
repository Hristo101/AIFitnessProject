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
    public class RequestToDietitianConfiguration : IEntityTypeConfiguration<RequestToDietitian>
    {
        public void Configure(EntityTypeBuilder<RequestToDietitian> builder)
        {
            builder.HasData(SeedRequestToDietitian());
        }

        private List<RequestToDietitian> SeedRequestToDietitian()
        {
             var imagesUrl = new List<string>();
             imagesUrl.Add("https://as2.ftcdn.net/jpg/00/64/08/05/1000_F_64080572_uCdi7MGnCbiO8f5RhcHT1fOgPk7eCY1w.jpg");
             imagesUrl.Add("https://img.cdn-pictorem.com/uploads/collection/B/BT6OIF2QLP/900_artfulartwithles-com_fat_man_profile.jpg");

            return new List<RequestToDietitian>
            {
                new RequestToDietitian
                {
                    Id = 1,
                    UserId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                    Target = "Отслабване",
                    DietitianId = 2,
                    DietBackground = "Не съм използвал досега хранителен режим",
                    HealthIssues = "Нямам здравословни проблеми",
                    FoodAllergies = "Нямам хранитерни алегрии",
                    FavouriteFoods = "Плодове и салати",
                    MealPreparationPreference = "Готов съм да си готвя сам",
                    PreferredMealsPerDay = "3 хранения",
                    DislikedFoods = "Броколи и спанак",
                    SupplementsUsed = "Протеин и креатин",
                    IsAnswered = false,
                    UserPictures = imagesUrl


                }
            };
        }
    }
}
