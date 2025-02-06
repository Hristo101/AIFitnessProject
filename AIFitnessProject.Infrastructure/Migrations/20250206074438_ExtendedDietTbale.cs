using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedDietTbale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Diets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Diet User Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEcpA5icvbY9w0T5lp5u+kCsd7hxpZr6bggVho/t7F4g6HLpZotDYpA3qmHz3cv+IQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "054a63dd-fdd3-4fd1-95bf-f4848b04ce49", "AQAAAAIAAYagAAAAEFkNferNnnFJZ/lxLZRubHqJC0Dc31OTeuYchjC0SSkihpKLXPpZki3Lo4uWX9tD4A==", "41a150f7-bc84-4e1c-890d-6608e2a1cb37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c546f22c-0ddc-48f9-83d7-8b97ab49456a", "AQAAAAIAAYagAAAAEM4IpfL8EQDpAU0dAmbXGz6wVe5BLy7gHrPzCWvk0p96QbTfpCqF3jUPseTLdq/ZIg==", "2f63ef50-e91b-47ce-87e1-bc381b89bfe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOv1+pwKehtmbDiKzhMvsD7BBktPXUP8Qb+RdxS8JGZla3zTomXuzbt095h20NNuIw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c988e7ff-662e-45cd-b240-5c8b8d56be3a", "AQAAAAIAAYagAAAAEAVSAilzATF7EQVkuQvERHcb8TOmYzV88fejop+dpTv2YgvsEOeM97fJWtcHN4sZlg==", "ef9bf7b3-031d-48df-a355-6d248897d3a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGjuHOVqHSwGs/z9nD1I2PrWBDLVOM21OlokK1tuSW8VlJbvxN0F5nV7SGOzzNbgdA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI8/iht7VoUHApoGaMMHIaHkkJ9kj3FGbVexv1z2wLJ9ngHqcJK2/Tgeg3IKIvevXQ==");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_UserId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Diets");

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
