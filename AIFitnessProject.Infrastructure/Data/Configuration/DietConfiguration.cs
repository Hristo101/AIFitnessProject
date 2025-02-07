using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class DietConfiguration : IEntityTypeConfiguration<Diet>
    {
        public void Configure(EntityTypeBuilder<Diet> builder)
        {
            builder.HasData(SeedDiets());
        }

        private List<Diet> SeedDiets()
        {
            return new List<Diet>
            {
                new Diet
                {
                    Id = 1,
                    CreatedById = 2,
                    UserId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                    ImageUrl = "https://www.fitterfly.com/blog/wp-content/uploads/2024/05/Get-Results-with-This-Step-by-Step-Diet-Plan-for-Weight-Loss-1200x675.webp",
                    Name = "Хранителен режим за отслабване и изгаряне на мазнини",
                    Description = "Този режим е създаден за ефективно топене на мазнини, без загуба на енергия и мускулна маса. Включва балансирани макронутриенти, богати на протеин храни и здравословни мазнини, които подпомагат метаболизма и засищат. Подходящ е за всеки, който иска видими резултати още в първите седмици!",
                    IsActive = false,

                }
            };
        }
    }
}
