using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "ExperienceLevel", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "0a2830ef-8be3-4ef6-910b-33b680d659d3", 0, "c37f9e70-f9ff-4e55-8c95-83ce9708cef7", "ApplicationUser", "stanislav@abv.bg", false, "Начинаещ,почти не съм влизал в зала да спортувам.Изглеждам ужасно и искам да отслабна!", "Stanislav", 1.95, "Ivanov", false, null, "STANISLAV@ABV.BG", "STANISLAV@ABV.BG", "AQAAAAIAAYagAAAAEMwHHtPwROIkC4jlFChW5YLzCu7UUuTAB1GUFrGEZiOGf9K8YhRWf7RGZXefpotoXg==", null, false, "9e406138-c088-4d10-810a-8cb287aa339b", false, "stanislav@abv.bg", 131.5 },
                    { "0e136956-3e82-4e00-8f60-b274cdf40833", 0, "e105f213-ede3-4a80-842f-3c9dc11968f3", "ApplicationUser", "petq@abv.bg", false, "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост", "Petq", 1.7, "Ivanova", false, null, "PETQ@ABV.BG", "PETQ@ABV.BG", "AQAAAAIAAYagAAAAEPPK5Nz4UO9rcz2wnEyOS9gb/NT1xGrsWhpj6YCYb1ezYWyQnzQxkhWsnPOA+bPAFQ==", null, false, "ddfff353-d2cc-4d0c-a9cd-c40f2914296b", false, "petq@abv.bg", 55.0 },
                    { "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", 0, "ec2261ab-a653-4698-bbf8-03187c3e1877", "ApplicationUser", "teodor@abv.bg", false, "Активно спортуващ,занимавала съм се с фитнес от 3 години,но не мога да натрупам мускулна маса", "Teodor", 2.0299999999999998, "Ivanov", false, null, "TEODOR@ABV.BG", "TEODOR@ABV.BG", "AQAAAAIAAYagAAAAEGZIDayJi5Qh7foXPCurqMKNhR/1/RjNSa+VoTX3oMkZ29C0Hb/mtNqWIFeTt56TCQ==", null, false, "d258ec24-1129-4a44-84b4-4597aecc18e9", false, "teodor@abv.bg", 82.0 },
                    { "cd87d0e2-4047-473e-924a-3e10406c5583", 0, "ddd19b43-78e7-4f76-ada7-a863c26dda43", "ApplicationUser", "pesho@abv.bg", false, "", "Pesho", 0.0, "Ivanov", false, null, "PESHO@ABV.BG", "PESHO@ABV.BG", "AQAAAAIAAYagAAAAEGTG+YCiF0+J5Uo57CAYo5AYhV4/rZPNu1KWiUlI8NtF4hiFjVZkwkQTXBUPj6L00Q==", null, false, "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f", false, "pesho@abv.bg", 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583");
        }
    }
}
