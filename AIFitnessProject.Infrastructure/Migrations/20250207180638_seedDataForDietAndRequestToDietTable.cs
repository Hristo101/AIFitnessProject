using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDataForDietAndRequestToDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIVibYLKQzWHj7S4uEKEjemvUq+zORHxO9iNbyvBXOkn7nhbo3B32zx7oP2rpuzcgg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3deb52-c177-4506-bb92-dff2f9c27547", "AQAAAAIAAYagAAAAEHZLjEAonGWN7frD+ThtBGS8+SY+DcbI1UK5iKAwW9Gv9cknyib+Lp5nVnIXRUUMhg==", "98a847f5-00c8-4fae-8623-6fba94d05e65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e4406fc-0cf0-4693-b7b6-0b501bdcf96a", "AQAAAAIAAYagAAAAEBsWIMz38qTvMXEN1Dvy58Lbb6MzuZ/H7tyB9RZw7TAqIndJaTwKbbaLkFzO4rrmqA==", "4e20cd1d-3960-4c03-aad9-f87dc8b6c990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGOHYPMdMDzN/suiIVu/ZiWcSCMDhA7W1xVkoKYVzxvxyTn2+FCJvCBEWqxZWZOLug==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9aaf97-ccf0-4003-88bc-282cdb0011e4", "AQAAAAIAAYagAAAAEI7sl2SC9ZiTEB4PmQnOy4U5fQg8fzoAYdIZ4GECWAAjzDv/q7Cxx5MCYxZIYE76lA==", "aaa84e4a-5173-454c-a690-6f368f21b984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECWUXWbA/VYgklqVrd0L1tfsuKmCCc1V8dm0TtskvfgQfoproHb0oBzJkhgtM5uFXw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMP412Im/yfrBjzmLZzN2P1RQKFsLjRNz4790S1/bZC0yz+pWi7wUD5nzso7hDb76Q==");

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "CreatedById", "Description", "ImageUrl", "IsActive", "Name", "UserId" },
                values: new object[] { 1, 2, "Този режим е създаден за ефективно топене на мазнини, без загуба на енергия и мускулна маса. Включва балансирани макронутриенти, богати на протеин храни и здравословни мазнини, които подпомагат метаболизма и засищат. Подходящ е за всеки, който иска видими резултати още в първите седмици!", "https://www.fitterfly.com/blog/wp-content/uploads/2024/05/Get-Results-with-This-Step-by-Step-Diet-Plan-for-Weight-Loss-1200x675.webp", false, "Хранителен режим за отслабване и изгаряне на мазнини", "cd87d0e2-4047-473e-924a-3e10406c5583" });

            migrationBuilder.InsertData(
                table: "RequestToDietitians",
                columns: new[] { "Id", "DietBackground", "DietitianId", "DislikedFoods", "FavouriteFoods", "FoodAllergies", "HealthIssues", "IsAnswered", "MealPreparationPreference", "PreferredMealsPerDay", "SupplementsUsed", "Target", "UserId", "UserPictures" },
                values: new object[] { 1, "Не съм използвал досега хранителен режим", 2, "Броколи и спанак", "Плодове и салати", "Нямам хранитерни алегрии", "Нямам здравословни проблеми", false, "Готов съм да си готвя сам", "3 хранения", "Протеин и креатин", "Отслабване", "cd87d0e2-4047-473e-924a-3e10406c5583", "[\"https://as2.ftcdn.net/jpg/00/64/08/05/1000_F_64080572_uCdi7MGnCbiO8f5RhcHT1fOgPk7eCY1w.jpg\",\"https://img.cdn-pictorem.com/uploads/collection/B/BT6OIF2QLP/900_artfulartwithles-com_fat_man_profile.jpg\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestToDietitians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBE1N5Nh7YseY6u/zDwnBGmEfrOO5pJr+4Xy4rLugJp4u1/aIVE7aa5Oa6n/uS67Rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02e3a6a4-ba4d-478c-866e-be720ef50274", "AQAAAAIAAYagAAAAEKZDJekImafXpvHHoauR2VQt8y6P/TWjQFUszYU1ff4P/llRi+SArdL4cQ8unB2Ubg==", "cb764a9a-ce66-42d0-affb-c8da13a258d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838cc9b9-0517-48d8-ac0e-3576f3dcdc28", "AQAAAAIAAYagAAAAEMXxQVamrPSpWthwdPQeTrheZ/joEmpjqOOukmfFhekQrH0uTIcMxZWzHaUtI98QtA==", "11956b47-e50e-4b04-a738-d1eb75835c8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPkt99gy/mPVNChyt64gBAVBk65aKX/Q3xYjCHcgPBgbs4CJ1qM+q5DtSEujJ8GQzA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507dcf1a-2b22-4eb7-a0b7-c0b37d7bfe1e", "AQAAAAIAAYagAAAAEFHEZeddETx3XHMU3sYEPoAYRe10YGuA8uMwfkK+Tzu3pXF7gha/ZGvQsQo2aKssHA==", "3d10e5a6-413c-49c0-aa9d-d2c3da9537f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKFXhuR/H5fCfvCkzucIfQqYLQCL3JNnjxZQmX3ulrw5mXWVoqzjEcKOGNQTeuxpGw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM181BeDirLzz4aoDI7DByq+3fWQcBFUaWDngdDvizLc4id3Jjstr6ovI9V1Tn6ZSA==");
        }
    }
}
