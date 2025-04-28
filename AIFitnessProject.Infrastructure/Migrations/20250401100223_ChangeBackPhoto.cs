using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBackPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPB4uhx5uUZkW1hXEGJG4qzT514hoHRH0LWOon/MTSL2raE9u4a7cCHwmelgJ8DCvA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e2152db-55bb-4c55-9956-919801b93ea9", "AQAAAAIAAYagAAAAELPyO2MYNp1rnSYaK8QfxyORMMqoDcwAoddufblHEI5X/JI0wBshEpfFYsZmslq50w==", "bcfcc00f-72e1-4b5e-b897-d2f95b667174" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c92ad6c6-b781-4da9-8701-358dc94d8ebe", "AQAAAAIAAYagAAAAEJ60kH4Nhfiuamgr5u9SGdBxA9EwjnqIMHfH603/kvFBQYABqnbXGhZNM/KJaafZfw==", "79a4002e-043a-40a8-92a9-7d63f0409787" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO2vCBaDoho9CGtqi8+Lq2LZG7CpZsAeMUHEDqcF0zGJcxzoub3WZG83l8JSCdiOcw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70e1e36b-adf2-4edc-bfc2-4096e7830d11", "AQAAAAIAAYagAAAAEI6qE7JWuWgqQKEHmgXkR5fc4QPKcXu2VpX338aemabnKDrUyBSln0K0asTs5gu35g==", "988dc7ef-79ba-4f4d-b455-33224afb79a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBFn8adtM17UePLy+Phu7wOEgu2JOIvM0r/oSqNboRb7hn6M2nUbw1IQ/dFtXk7TVw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHRIXbvDRPkVNU644H2Wj4njzGy2zTSuhgI1sCELUCJMRkkCFlHJCBkHjuZpv7z3eQ==");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://gymbeam.cz/blog/wp-content/uploads/2022/04/iStock-610576810-1124x749.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA+RGq6lPT44ADPMoIYwmb11hrroWOghge5T4tJ8/exKAUiXfIO1PA0ZPJ08L6UE0w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85fae034-f98c-4dce-9c18-a1fd113a5744", "AQAAAAIAAYagAAAAEEzSAu7cvJD/CBnhSFXOosGG3AuE+7GyrGAkDtrqR7RVl6uPDo3cEglQK6wGAVf7aw==", "2aa78d5e-72b7-494e-9054-30a3dedcccb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b46501c7-a39a-4ae9-832d-c2f86799afc7", "AQAAAAIAAYagAAAAECAOZLIBV3LAzzBcAxIHhs0qq5Jv+j9uvtc6QcRW/Bzj0fCYSb9RP1u6exOrJoaifw==", "ff879c63-f0ba-414a-94d0-3d78073e82b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAfceta1GfhEj0niDjLnwWFwjrm3UcqFyBasRJ0Z+x4uJaRvfId5WKcVJrrcTQ1iRA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af90b018-dc18-43a0-b78d-3c6d245ecabc", "AQAAAAIAAYagAAAAEAfdrA2leaSBlO8wFjXXxiE6wOXg3mFDg+lviXNRjBis1UiooI54lZAHWAaHFe52ZQ==", "0c52dbcc-430e-49ad-b89e-ab6f6f577c70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENE+9KDUride08LqithvMlY991mHXCabL1b44J5IFD8D40mV/hCodGapePkXu1DZcg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENQN3EYPjF6DS/UTTJy6gbJ0TGuRaUHogncmMWxAQqDoytcnZFxFJFRBfkl5d3Gf9g==");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://pulsefit.bg/uploads/cache/O/public/uploads/media-manager/app-modules-blog-models-blog/header/71/797/back_1800x675.jpg");
        }
    }
}
