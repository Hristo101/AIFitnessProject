using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpandDietitianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dietitians",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Dietitian User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Dietitians",
                type: "int",
                nullable: false,
                comment: "Dietitian Experience",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Dietitians",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian Bio");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Dietitians",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian Phone Number");

            migrationBuilder.AddColumn<string>(
                name: "SertificationImage",
                table: "Dietitians",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian Sertification Image");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIAzEZqfxSoiaA/Uw1AAa6Havd69HMItkqcBK+24OI1O1e6HRNH1SYTzvVnJlpfpBw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECv71U7xMQmHJHzmulgfC0854V585juUAFz1frKhogqgAcwNuQttEkXx/0Utxa633w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO9D4PukCuI8MtUnvejRv0blnRyo7KE6dOSjz4PfiMFfOnzByfhJLqHGuLkvln2rdQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFrwW/0tEOlMZq0min7LFAqfIlZQRNf+feQR0UNROQdgb48ljTAhEENUkC1e1xrYcw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Dietitians");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Dietitians");

            migrationBuilder.DropColumn(
                name: "SertificationImage",
                table: "Dietitians");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dietitians",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Dietitian User Id");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Dietitians",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Dietitian Experience");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKMozVsviW+CCc2Tz+fr9N7khWE+hDIgalwfpSJNPWS7MjxQREG5/ttgIHeRq9N+TA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKAunNIJCw49N48zrGwwwatAKCVt/9+ukGtKQSpiB1GpcG+hGjSy81X9NqtRma2vYA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGpGWdQycQ1YyrtSM7TavrwHEVtbEjsMGIfjtfboG/n6wz+1kgizV4bQFEuHFV/4Tg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA+v13AndHYx22Tkv0N4i7EST5hzENr8poObunJAvbe68+BIT85fWDXFB6NeW3+usA==");
        }
    }
}
