using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDailyDietPlanWithThreeMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENA7KtKqGMu0R/+Je11VVtVCM5CZB2mpBuzOlZHLxALmh/FraiQpsQfS06izZ9p35A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a77f2c-3774-43cc-b12c-74ebd0741db6", "AQAAAAIAAYagAAAAEGFjCFs7PfpwCkrQf0C3U8CraGZh9fjqSQHwH/+F3i2Zt3CJZ1NmP9yHtWNJQE5P0Q==", "6f806716-2387-49be-b31f-2a85a5c82281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f102aec7-e6a2-4549-9c4e-b6cd9b7a3f81", "AQAAAAIAAYagAAAAEJleWOYxl9FgCLYIGHHon8Oy0jtUzrR8RUxEYgodeQWjcg7gZ68OAzXbAD/j3ARShQ==", "ee0ae8eb-cd06-44f6-8ec6-11d94cb36da4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH2RADxvVsgyUMwmbwsf6pWtlWqgJRVbIv+3un5NPIIRAD+MWZ/vp+ua74xaB++1rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf1a6b30-b187-4b32-af22-f82327f9c389", "AQAAAAIAAYagAAAAEE+rvci97QnSfFMAbhgpcWX25rNUplkQl+6YqEVMZIKnVYOBc4QSE1csYKmmLWUR6g==", "24769007-dfdf-4762-b635-d793b2c28cfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI8+fITeoPTBltauvJYs8ywD6bpQh2LG7ClWzXlPxiUvaVUsUwmwHOxDJTm6kltxEg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB0LOM6kGVyDxcWkPOyJLz9cvRrQSsuHZWwYpOSdizPBcFzfjf4Q1a/nJXeGV5Gk6A==");

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "DificultyLevel",
                value: "Лесно");

            migrationBuilder.InsertData(
                table: "DailyDietPlans",
                columns: new[] { "Id", "CreatorId", "DayOfWeel", "DietId", "DificultyLevel", "ImageUrl", "Title" },
                values: new object[] { 2, 2, "Вторник", 1, "Средно", "/img/DailyDietPlan/dailyDietPlan2.webp", "Основни хранения - Ден 2" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "DificultyLevel", "ImageUrl", "MealTime", "Name", "Recipe", "VideoUrl" },
                values: new object[,]
                {
                    { 4, 420, "Лесно", "https://m.1001recepti.com/images/photos/recipes/size_5/ovesena-kasha-za-zakusak-s-banan-orehi-bademi-i-oveseno-mliako-1-[4632].jpg", "Закуска", "Овесена каша с банан и мед", "Съставки: 50 г овесени ядки, 200 мл прясно или растително мляко, 1 банан, 1 ч.л. мед, канела (по желание). \r\n Инструкции за приготвяне: Загрей млякото в малка тенджера, добави овесените ядки и разбърквай, докато сместа се сгъсти (около 5 минути). Нарежи банана и добави меда и канелата за вкус.", "https://youtube.com/shorts/-1W2MjpJ91Y?si=0-a-oPIwQEEHIvJI" },
                    { 5, 580, "Трудно", "https://static.framar.bg/thumbs/15/recepies/181029152537pileshko-s-kartofi.jpg", "Обяд", "Пилешко със сладки картофи и броколи", "Съставки: 150 г пилешко месо, 100 г сладки картофи, 150 г броколи, 1 ч.л. зехтин, сол, пипер, чесън на прах.\r\n Инструкции за приготвяне: Нарежи пилешкото на тънки филета и го запечи на грил тиган със зехтин. Обели и нарежи сладките картофи, след което ги изпечи за 20 минути на 200°C. Задуши броколите на пара за 5-7 минути. Сервирай всичко заедно.", "https://youtube.com/shorts/hr4G0e1wdAA?si=B5-7rAw3WzYKT6Ok" },
                    { 6, 480, "Лесно", "https://assets-eu-01.kc-usercontent.com/00b9925d-7322-014e-f702-6ef9aa1a28b4/abaa4b40-24e0-4963-b91a-dcf91ce15852/01032019-368.jpg", "Вечеря", "Омлет със спанак и сирене", "Съставки: 3 яйца, 50 г спанак, 30 г сирене, 1 ч.л. зехтин, сол и черен пипер на вкус.\r\n Инструкции за приготвяне: Загрей тиган с малко зехтин. Добави нарязания спанак и задуши за 1-2 минути. Разбий яйцата и ги изсипи върху спанака. Готви на среден огън, докато омлетът стегне. Добави натрошеното сирене преди да сгънеш омлета. Сервирай топъл.", "https://youtu.be/5PVZljZJgTE?si=3dEuIA7VKcteWyCx" }
                });

            migrationBuilder.InsertData(
                table: "MealsDailyDietPlans",
                columns: new[] { "Id", "DailyDietPlansId", "MealId" },
                values: new object[,]
                {
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBVIAhklvjlDZs20DvuNJh/2uRmuYhWBGVnSbRbAlGFV7/aYR4atAquP7W7XVfls9A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aed255d0-58c1-4d12-b4b5-048a09ec4a4b", "AQAAAAIAAYagAAAAEHTdHaGYBdrA56Kxxg2CzSCA8ZLGEtWz2f8BA3OqhtCphFD7SFdBWm0vukPZljwb3w==", "256eff4e-1fdc-4ed6-bcae-0916de87b700" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87fc71a6-4546-4f79-a9fe-a593954ca853", "AQAAAAIAAYagAAAAEEaD8k/Lzv/hpSlp3FdGi4px2BLZpDqSNp6vmqxqFjRaafjFDmQDv9ztxCVWscxiRQ==", "a46ea4bb-3274-4bac-95b3-c66cbccbe13c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECx8PFcgltGvhLNG3IvAquHEvbIOQh6szIVoIBoL4pxcCtSNUThYugYA96Q5jzC7ow==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0151e659-bc41-4678-9819-761264e8dc1e", "AQAAAAIAAYagAAAAEJvLN6oSGcr0iNe4aj/9MHqmOGhCXgkUhTm1+0zAIiphAQMTPhWfpBHe1m75rSPKOg==", "3127e566-7f79-4c86-9c97-be691d1f0caa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF5kmbrvgdCNMBqhdY82GrE5Seg/dB/QxgXMSA6tBeANeoTtUmjAfJ+Wy+MyNAB8FQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECGgsXYVSdiKoFMYf4uO/oNkHurdMSuOFjKrjOHwyndz4UPCctNF0nj3fM618MinoA==");

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "DificultyLevel",
                value: "лесно");
        }
    }
}
