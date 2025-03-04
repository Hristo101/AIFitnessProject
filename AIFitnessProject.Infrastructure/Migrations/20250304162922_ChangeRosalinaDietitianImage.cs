using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRosalinaDietitianImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIODMc+rVYt62ZGgs2Ve1RU/ARgz7uRVUgcozHFSLTUJff/FOmxMrFRJcm05A5HsSA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "061c149c-0d20-4eda-9558-28fc7f8f46b5", "AQAAAAIAAYagAAAAEMnVYZtv/UCgvQnlFE5dd6kCNNYWNjml4MYM8sOulHqTionjS1FpDowjCNwwSaAWtg==", "a28a3ea0-24aa-42fa-809a-cd3a20fe479a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "98e7c93f-5145-49f6-93d9-e4876e7a408b", "AQAAAAIAAYagAAAAEKqIxGl0+SPNue/tixoxBetE9VASMka/4LldtEaFA/XVvLh8CXebjFWFKdRfY7bHLw==", "https://stomed.ru/storage/news/4/344/neozidannye-situacii-v-kotoryx-pomozet-dietolog-8986.jpg", "1fff5368-1b72-4f2c-bcc8-36442b229fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHCr+YCcc64/6ZJTjq/h1fEVZ9Yg6IPyKS0tq5tXkO2+ux5QxxX9xquW5ZN78adz/A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4ac93a4-eb76-4e35-9046-49fe725a3158", "AQAAAAIAAYagAAAAEGgFZE2dBGxn6CICeqXqQkHu1i8NCoL9CamZOpzBk3fGAOddJ8qqGOm5v/0ZuTL7CA==", "76cc6333-21e6-4351-8839-6a18b69b2524" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL6Kjrw23N6uPmmmt/W3hAySgLtYEBSe7uReT5+SuCJhc6p49UP5SdDS0UeH5F2oxQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIA8YXTRqNKaHEfENcOOrdBFJe18zsFc3lpKXSyTZQ2eA8Yw0vFz9bfJrIWwVEzr8g==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDFslS6qtO/XWsm7/F7x2Hg45ymIhc5EdWYP5xELKXiWxYiuzmCTktBp/IsM+wU3ag==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5b97ccc-ff96-4e42-8de3-5599111bf53d", "AQAAAAIAAYagAAAAEEOcuO8CDua1b0lsOGsq6SId+q29LhVh1cnNAokAS9MDHKfmJwfUlVIvbnwi0AZaMg==", "daf82d02-e4cc-4de9-b897-57c79ea83783" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "0ce2eb61-9e8a-4dcb-87b5-99f201de0be9", "AQAAAAIAAYagAAAAEAyRWCr7fBQCfyhH5R5vQ+9LcEYkDY0N1lWSUOK2H7yl1HnOn6mL2TpiFOha4vf8pQ==", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMGQYuIs2aw9Bf3mTRB6T9YQatfGh76rtBUQ&s", "41080a48-32f4-4423-99b0-20a5b7b56d77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHboKaGZPsxDqqFwhYzOEF3I3U7hEqXrz1PJi2ZRmc+UMr+6o6NlfYCM6eKGSD66vA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b70b3729-b7f3-4b19-9504-7f12922354cb", "AQAAAAIAAYagAAAAEF1sRgQP+McuEXQKO9+HCzA1/mKK0ZqWThAgCKUwNsWxVBHzgMCcKgwnJyotFwyVAQ==", "dd60a471-f730-48a3-acef-89f312f79752" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM24hPub0cpjDXtxfiCjpZr2cMsVs1eJP94WiGlZznI2t7ze6C3eK1VnbV3g7NNQyQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHOG0oO63F6R6Y5TY1HTos64t83FCp29zYiluOnVZz03JRAn1NB35OC7UrpSXzF0Uw==");
        }
    }
}
