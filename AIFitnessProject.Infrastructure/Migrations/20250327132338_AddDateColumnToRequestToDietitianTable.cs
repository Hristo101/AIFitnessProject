using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateColumnToRequestToDietitianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RequestToDietitians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                table: "RequestToDietitians",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "RequestToDietitians");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKV2dJDxv9FCsM4dIQIKXlLIkWZw4/iOPM5MKj63BeTfehd6SB8/C5LurBGf3QTpHA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca236a9-88df-4eb2-9c45-5bfd1ae8024c", "AQAAAAIAAYagAAAAEKAG8nBYoyzOq8pRc+zfBCmPwH1FPNstXOvSj2YKpewWcFJfpXxSBroS3ip4X4tVaA==", "992bb9e8-9860-4ed1-92b3-db3d2a6dba1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbac9fc-2017-4477-b26b-5455603581a8", "AQAAAAIAAYagAAAAEJnl/z5Nm99qflgTlpou02Ilkr/3068+oSzQlYftmGyqhgRGuWIGUSuCqtc76vyL7w==", "7094451d-4379-4758-aceb-52674b1b2769" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDEPbfDJIGHx95BPbJvit8TrDsSn327TQuPjfasJmUEB0/AOeV3C1Ne2AzR+96kO6g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452b061e-b8e8-4f10-a8a6-da9e8246fd6c", "AQAAAAIAAYagAAAAENttLhF0xdVeA1mj+VxO2zJAkGe55u34iiHSG9b55eJAtDmwCzzR1kaHl3y8CvPADA==", "6662c18c-c33a-4444-b45f-9a504aa04a0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAgxYcv+yG4hDltbKjph3Y6BFwOD593CO5Y92/ICNWK8cQlNBOvTlsCi8g1YiQGrgw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN4fXaUvxcvRJJv23WGjqIcN9t+BtnOlD/uY1YDW292N2EGmOpWL7JsCYxcU17M7wg==");
        }
    }
}
