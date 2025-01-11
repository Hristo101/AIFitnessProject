using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedForTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEORfgK+ZAa6B1/iInloF7eGl+TD1dKB/FeCjK9oXByqLZYn/BURl35M5u2KrZ55z1g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMDu5b/LS95WQ2DlP3QfWckJrwehOBnYagLmkhTs1y1XKwNEZHhJm5yPUPeS214tPA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEABPsq1WnQrPEYza4TeXjJy5R18T9iQybMfukWp2aUhppIybXbMLnGe3eyd7yWSB/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA8v016wfKoIj6ps+UF2+E8G1fGxiZUd0GgJrDlZgCTkZK0JM8eKwy5RJky4gYnsuQ==");

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Experience", "ImageUrl", "SertificationDetails", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, 5, "https://momichetata.com/media/1/2024/01/18/117000/original.jpg", "Здравейте, аз съм сертифициран персонален треньор (CPT) с богат опит в изграждането на индивидуални тренировъчни програми. Моето призвание е да ви помогна да постигнете своите цели чрез ефективни и добре обмислени тренировки.", "Тренировки за издръжливост", "0e136956-3e82-4e00-8f60-b274cdf40833" },
                    { 2, 4, "https://pulsefit.bg/uploads/cache/N/public/uploads/media-manager/app-modules-trainers-models-trainer/305/6874/novo.png", "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!", "Изграждане на мускулна маса", "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIAMbP0a/xG+G2wMuWalOuHCRAcHm33YX4jBJXflbIZubcihdUNv1bY1ERrwtgp3Hw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPG6hj9Dvk4rPhkQQc27k+Qah19iopn2tJCrkLqlydHJy97jlzto2jBdXbK8j5JEfA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA/wK2uigVXuGvJDRYGCzceTVKssJSfzk37vqTzC2L6RdSBmUw8qzdbsIkcmqCxg7Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIAw1+R/0Xb5QYvIQeW6vKOBbD6CXGvt3EgITws2C0TsMQUVqn3hPaqRQ8TH0vzQog==");
        }
    }
}
