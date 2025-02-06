using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewWorkoutForBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHh7juMMqDw4po08MRFQsYqoL0+D5X2QtyqtquU4cWmAbA7O1FR1meTWBKjYC8T0aA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "277e18ca-f6bd-4aa5-9bf0-b9826deb20ec", "AQAAAAIAAYagAAAAELLPnE67g7Z1JfOa1EQobxPc51fNj5kMFcAHbvHkxWa2Phj+Gu3Sh/5jGPs9/JlWTw==", "83ebe5c3-d706-4474-87e0-bed9bd430502" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5ad3b5f-9e79-4c05-8bbc-fc92288e84b5", "AQAAAAIAAYagAAAAEAnpRCcb6tEslxW35zcubyK8eQwfinRkR7HgsRCXaWFRKmunIHem5ksYb6mE5E01LQ==", "236b33b6-9df8-462e-8f39-01e390fdcf2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFCVXahQMP+0Ha4TZXH1n7cYO3NN1Gb4ZjqoGxUtMLFXlyPpJoL10VQwh4fiwgzPkA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02aad1d0-e757-448d-bdfa-faedc3e5aafd", "AQAAAAIAAYagAAAAEBfiPRR9bqfJRZnSmMZJRglMMZodXP3Zb0JATe4dp8m8gHsbWjo10pByBQW5S/qLsA==", "cf455523-4476-4268-878e-0f48e95b3e56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM13asjMhq+jmm2qClF1oCrG6CTExJWrE/+qgZO6Ytd1xnj9BtHGnKjNxD5xA4bYwQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF410sa9FLRbWqtFz1YjuPbfZadXQtC/aAWuen1sVncTxHdg07nRJ6y8C1lPMiMgKg==");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "DifficultyLevel", "ImageUrl", "MuscleGroup", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 5, "Упражнение за цялата част на гърба.", "Трудно", "https://www.mybodycreator.com/content/files/2023/05/25/65_M.png", "Гръб", "Мъртва тяга", "https://www.youtube.com/watch?v=yPqv3ejnZvc" },
                    { 6, "Упражнение за широкия гръбен мускул.", "Лесно", "https://www.mybodycreator.com/content/files/2023/05/25/392_M.png", "Гръб", "Горен скрипец с широк хват", "https://www.youtube.com/watch?v=_HsCxLNPpoY" },
                    { 7, "Упражнение за средната и долната част на гърба.", "Лесно", "https://www.mybodycreator.com/content/files/2023/05/25/403_M.png", "Гръб", "Горен скрипец с широк хват", "https://www.youtube.com/watch?v=LWBxwyp9zJg" },
                    { 8, "Упражнението основно натоварва средната и долната част на гърба, но също така ангажира и горната част като стабилизиращ фактор.\r\n\r\n1. Средна част на гърба (Mid-Back)\r\nРомбовидни мускули (Rhomboids) – Осигуряват стабилност на лопатките и спомагат за добрата стойка.\r\nСредна част на трапецовидния мускул (Middle Trapezius) – Участва в свиването на лопатките при дърпането.\r\n2. Долна част на гърба (Lower Back)\r\nШирок гръбен мускул (Latissimus Dorsi – Lats) – Основният мускул, отговорен за дебелината и ширината на гърба.\r\nЕректорите на гръбначния стълб (Erector Spinae) – Помагат за стабилизацията на тялото по време на движението.\r\n3. Горна част на гърба (Upper Back) – второстепенно натоварване\r\nГорна част на трапецовидния мускул (Upper Trapezius) – Не е основен мускул в движението, но подпомага стабилността.\r\nЗадно рамо (Posterior Deltoid) – Участва в движението, но с по-малка натовареност.\r\n", "Средно", "https://fitnesdieta.com/images/uprajneniya/darpane-dumbbell.webp", "Гръб", "Дърпане на дъмбел с една ръка", "https://www.youtube.com/watch?v=3ff-qVskb-U" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatorId", "DayOfWeek", "ImageUrl", "OrderInWorkout", "Title", "TrainingPlanId" },
                values: new object[] { 2, 2, "Вторник", "https://pulsefit.bg/uploads/cache/O/public/uploads/media-manager/app-modules-blog-models-blog/header/71/797/back_1800x675.jpg", 2, "Основна тренировка за гръб", 1 });

            migrationBuilder.InsertData(
                table: "WorkoutsExercises",
                columns: new[] { "Id", "ExcersiceId", "WorkoutId" },
                values: new object[,]
                {
                    { 5, 5, 2 },
                    { 6, 6, 2 },
                    { 7, 7, 2 },
                    { 8, 8, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
