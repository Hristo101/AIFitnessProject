using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBtC5aa0pYKp1NG8yMvtpPaJM6HxLNuFk2TlO8rmHuUCkcZZkyXiiAECLg/JbgGYzw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49461c4f-951e-4aa5-857e-b94d64dd9639", "AQAAAAIAAYagAAAAEIdA9cBRoZg0i491r5Dtrw3GYYDOVpwIYEI4paRJ2j2CW6Ym6c5BjVKW+oaimut4mQ==", "8f0bdcde-b4ac-446a-8db0-c748cd5fa6c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c4d73a7-a2b9-4923-96d3-2f309c720e33", "AQAAAAIAAYagAAAAECkzq0lgsqmttZfadIsbwOJLEmVfzqFzKXWulGyJrzVuWhOkRg41ZrME+okrgoF0zA==", "7fbee55e-752c-46f8-9e09-d1f633abeb04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECcM93i2tzwEM+SpgDD9NIsMBcay/btcej9Z7hAu3UZAFRxut4HfuJF8CGCywHZH3A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52622635-aa5e-49e4-b477-7471b54ae0db", "AQAAAAIAAYagAAAAEJ403BBKaNmxezc0h/qAZje+PrGBMN75dMjosgyGuK/Zaf0mj08uNyrfqlL60SdZ2w==", "c5eb4ac9-100d-46c1-baf7-6e288660dd28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP/1DLO43T7jWeq4xg+4gGODsregTIbxZbQnrawy9LDSw+U0Yiz9QgQ5GiB8pqJciw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELXQVLCeV6eXJgBjALV2TWZRXAjYWgZOTHFsjAHUy96VPhh/qvrxLhzapB0yZTPq7Q==");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "DifficultyLevel", "ImageUrl", "MuscleGroup", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Упражнение за гърди, рамене и трицепс.", "Лесно", "https://example.com/images/pushups.jpg", "Гърди", "Лицеви опори", "https://www.youtube.com/watch?v=k11CvzGtRGE" },
                    { 2, "Упражнение за средната част на гърдите.", "Средно", "https://4fitness.bg/blog/Files/Images/exercises/close-grip-bench-press.jpg", "Гърди", "Лежанка", "https://www.youtube.com/watch?v=hWbUlkb5Ms4" },
                    { 3, "Упражнение за долната част на гърдите.", "Средно", "https://4fitness.bg/blog/Files/Images/exercises/dips-exercise.jpg", "Гърди", "Кофички", "https://www.youtube.com/watch?v=m_sGDGxlibI" },
                    { 4, "Упражнение за средната част на гърдите.", "Лесно", "https://www.mybodycreator.com/content/files/2023/05/28/399_M.png", "Гърди", "Кофички", "https://www.youtube.com/watch?v=GhG-UXc2v1Y" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatorId", "DayOfWeek", "ImageUrl", "OrderInWorkout", "Title", "TrainingPlanId" },
                values: new object[] { 1, 2, "Понеделник", "https://cdn5.amcn.in/a/sport-direct.alle.bg/assets/d0001a0431ab-c999999999/e2omdu5nt1ga19ea1zuc.jpg", 1, "Основна тренировка за гърди", 1 });

            migrationBuilder.InsertData(
                table: "WorkoutsExercises",
                columns: new[] { "Id", "ExcersiceId", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMOTvvzlfkfmmOCuhpRw1FltUwnlKKWbwk/xVI4Q7CmVSc2OdWKV0RQU9WgD3dxl7g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a31b8f8-aa02-46f9-9bf3-87e722bddc28", "AQAAAAIAAYagAAAAEEwPrePHLOODbXDgwfFTPue+Q7qCcvL/MKhOq3qIRljAl0B7HsC/jgkxfL2ejsAV3g==", "7a2918af-d13f-4869-8025-41b949876307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d56dd3-51f5-4621-9128-89a26ae9ffd8", "AQAAAAIAAYagAAAAEOfF1jEOmKI8kSlbPKXIlSSRkwSwR9DWMkE+rOSZ42/+HNstqgqxoaC4rVRv6C2EHw==", "efceadad-c536-40c8-a232-f66716f5dab5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA47QmHbITddCTwSzVsxSPtRIfZO6J7ek4QHVCo/ywXdJ4r1N7IIdnYAE2Mzkcvczg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "617dd460-d5af-412c-a207-5a1e0aee823e", "AQAAAAIAAYagAAAAEJjCNgFuNY19JwKyTCzezDNmp1wQdxxHlMXN/BWegtz9BzQsAkQk1v0rh9ehwvg2TQ==", "7b9daa33-bbc7-4f7a-a188-8d34227a3c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMUQ+V/f1zrA/OznLhwZJnIO+7jj2gYxswr7/tQzT9noeQf1uyRo1WtR8c7SAh+bYA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPfwqYZ0BfvppCrGnLCIK9vewII5KrTn9AA1kc+fwy9wCBt0MseJQ39/GJt128qLiQ==");
        }
    }
}
