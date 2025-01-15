using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDietitian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECIj0ecDx0LqtI+T6dO0FhtzhyYKmuliD2w7kOZ504e/knShqHU92mxkuH0ptjPPbg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBkr+Xp5tt31dKoygVzQ2KIZRUb0rtV4i5nUcDfwla0006q3msRiD2d/+t+TftGRVw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECq8B/NcUEsoTFh3cAIOEH+BlF2vMcTD27Lu+FNZeklsIxoMLhofzIJeEGObL8W8UQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEIFXC7XXf7CIGRgWWz6A26qdRyjA3bWoqiKPNTBQjjTQBCbeXc/e6fq3TLYFiHQAA==");

            migrationBuilder.InsertData(
                table: "Dietitians",
                columns: new[] { "Id", "Bio", "Experience", "ImageUrl", "PhoneNumber", "SertificationDetails", "SertificationImage", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, "Росалина Узунова е опитен диетолог, специализирала в покачването на мускулна маса и оптимизация на физическата форма. Завършила е специалност \"Хранене и диетология\" и е работила с различни клиенти – от аматьори до професионални атлети. Тя вярва, че правилната диета е не по-малко важна от тренировките за постигането на желаните резултати и предлага персонализирани хранителни планове, които са насочени към оптимално усвояване на хранителни вещества и растеж на мускулите.", 8, "https://medintu.in/wp-content/uploads/2021/02/kisspng-clinical-nutrition-dietitian-nutritionist-health-parkside-orange-suites-5d090014f1eb93.3607288515608709329909-1.png", "0886352233", "Здравейте, аз съм сертифициран специалист по покачване на мускулна маса. Специализирам в създаването на хранителни режими, които ще повишат вашата сила и мускулна маса. С правилното хранене и постоянство в тренировките, всяка капка усилие ще се превърне в здрава мускулна маса и нови постижения!", "https://cardinalbites.com/wp-content/uploads/2023/04/r1-600x782.jpg", "Покачване на мускулна маса", "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708" },
                    { 2, "Женя Желязкова е сертифициран диетолог със специализация в отслабването и изгарянето на мазнини, с над 4 години опит в трансформирането на тела и навици. Вярва, че всяко тяло е уникално и предлага персонализирани хранителни режими, съчетани с научно обосновани методи за дълготрайни резултати. Работи активно със спортисти и фитнес ентусиасти, помагайки им да постигнат оптимална форма и здраве. Постоянно се усъвършенства, следвайки последните тенденции в спортното хранене и метаболитната оптимизация. За нея здравословното хранене не е диета, а начин на живот.", 4, "https://dietyc.com/wp-content/uploads/2023/03/nutritionist-dietolog.jpeg", "0874856290", "Здравейте, аз съм сертифициран специалист по отслабване и изгаряне на мазнини. Специализирам в създаването на хранителни режими, които помагат за отслабване и изгаряне на мазнини. Заедно ще постигнем вашата мечтана визия и ще постигнем всички цели!", "https://healthy-lifestyle.bg/wp-content/uploads/2023/10/%D0%94%D0%B8%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3.png", "Отслабване и изгаряне на мазнини", "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIAzEZqfxSoiaA/Uw1AAa6Havd69HMItkqcBK+24OI1O1e6HRNH1SYTzvVnJlpfpBw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECv71U7xMQmHJHzmulgfC0854V585juUAFz1frKhogqgAcwNuQttEkXx/0Utxa633w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO9D4PukCuI8MtUnvejRv0blnRyo7KE6dOSjz4PfiMFfOnzByfhJLqHGuLkvln2rdQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFrwW/0tEOlMZq0min7LFAqfIlZQRNf+feQR0UNROQdgb48ljTAhEENUkC1e1xrYcw==");
        }
    }
}
