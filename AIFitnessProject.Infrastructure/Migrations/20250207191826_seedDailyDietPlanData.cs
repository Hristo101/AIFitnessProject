using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDailyDietPlanData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBAsTvhkkedrr8aF28oQTQr80HEhdPTF+hu5+kEf10H8/kAIl/lFdQNONceP0qiYOg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aada79db-e2f5-4e9d-aef9-873ebb98b388", "AQAAAAIAAYagAAAAEMOJH6rLjHQnKv3MHYKAXx8XCkVaXLKV9lYONJwO+JrnbB9T6ZAUf7mj1aMeeXgvXA==", "e152a6d0-1bc3-4a71-b87e-140499576ce7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "247994d4-86d1-4484-b33a-94a89348fb97", "AQAAAAIAAYagAAAAEHq44x9eFV/7dChXYyzSiBbRsShieQtzKqgppXmrr42UHNZAMGNL/MT7cQRWDu+qVA==", "d92d6a21-d7e5-4962-8201-3be3f9ecb654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEzH3LLyzawLVjfamDrT2Xk2umx11ra07PmEAIuFrPmtIWeZLFc2NwC/PUCM80r1cQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "133fdc1d-0cec-410f-bb3b-aa21a72e2233", "AQAAAAIAAYagAAAAEMlX880i77chHIieAAPZ2d02S/EhiVYYksBpA/9IFY6dGp0faYTooIIuKx/NMPupNA==", "8ebcac42-4f29-467d-a0a1-d81180835be0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOuknV/M+4k0ryvmWI6+uF3StO3KVI+/UqkBvn5pHc0V1RSGbd1xO/S1gxCjQEzNpQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEC/mClinqMxueiO56XV8O9oSifsUBPqMIWzgaPnirb+l6T/AMQS0cpsw7Ws4BUK3Rg==");

            migrationBuilder.InsertData(
                table: "DailyDietPlans",
                columns: new[] { "Id", "CreatorId", "DayOfWeel", "DietId", "DificultyLevel", "ImageUrl", "Title" },
                values: new object[] { 1, 2, "Понеделник", 1, "лесно", "/img/DailyDietPlan/DailyDietPlanImage.jpeg", "Основни хранения - Ден 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFRMvOx0GtDg8chbwDN4eZuif0GrBKS3J0lMEbfS5Q2DFajzt2hltpD+OrZEgrj8/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84c29739-2496-49d5-96a1-85615225352e", "AQAAAAIAAYagAAAAEOtGhJ0mv7oXO2bbp9nDmPUiYN86MkYbg+5h68v4ULjwGub9oyTWHGwAkKDDm4lLBg==", "0300b2ad-a87d-4353-9b2c-433613070083" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "488bd4e1-95b6-4ac7-938f-67c605524919", "AQAAAAIAAYagAAAAEOypSmdWJE0pjgawvfOHht2C52V/eqW8E6NJaDCL3YrOn9TCdgZCIbKH4l4WSs/Cmg==", "e3386b9e-e750-4443-8d63-b1f220ed0a41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFGRthJGJooMr92X/H0RKkn2cj7uqqPwW7LplPZo/gcWSuRbbMXPyp4W67C4ADBxxg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0d9a0b5-d71a-4880-bd27-81b6aba71941", "AQAAAAIAAYagAAAAEIBfcfbnXJoPOOYVrUrxSEe0D9pNZLgJgUdjZq+wIvGZq1lNBlWhMotPluQkWMnc9w==", "183950f2-646d-4a76-8aa9-6f70e221b107" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEvR2BMWNTuZ7swh6XAojyuXzb0USHuGRZUV9NDuV7jOd3XI0j6H//jfnWW/xIPaew==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFDvVPLzLdeywgfwI6ga4/aQQjhIh2kLLyiTT3casS/UDsk5ECTD35Vc+eqwjoo4Fg==");
        }
    }
}
