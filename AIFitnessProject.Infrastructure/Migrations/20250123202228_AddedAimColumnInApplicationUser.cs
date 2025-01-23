using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAimColumnInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                comment: "ApplicationUser Weight",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(1900)",
                maxLength: 1900,
                nullable: false,
                comment: "ApplicationUser LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser LastName");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "ApplicationUser ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser ImageUrl");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                comment: "ApplicationUser Height",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(1900)",
                maxLength: 1900,
                nullable: false,
                comment: "ApplicationUser FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.AddColumn<string>(
                name: "Aim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                comment: "ApplicationUser Aim");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                columns: new[] { "Aim", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAENw7IHlawPNywEqVjPrDkRj3+OiUDlccfmVtgQh1p3zyW80EXvJEoKvc3Il7p9lu5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "Aim", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "d56d0872-d992-4b5d-8115-2e4ad47fd9cc", "AQAAAAIAAYagAAAAEBw/9pCURuf4nqj2+u+98J9XRMX1GQmkbCNTB41Be+SWNBBtAYYLUhXYRq5spZqnWw==", "5a2feb74-1de7-40c8-9184-6ad5870dc281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "Aim", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "566621ba-7703-4f9c-a550-7b8bbeff940c", "AQAAAAIAAYagAAAAENBrbD8GAGW8o+50yk9T+JkeCIIgq2f/rfbiXLvyoSIP3HoGr9ouuJ8tD6sdBaPKxA==", "9fc3b194-0d8d-4645-bbc9-3dbef041f324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                columns: new[] { "Aim", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAEPhU87mAxH+Xqe+UPdXriIwpzk/VLMJGGt3u2OxHCCvCPmax5K9/EnzwbqVF4S10Pw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                columns: new[] { "Aim", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAEG/b1ozZo65Cl4+FGvIZmYDuS7MIjHhkETYMBC5j5rryBrnOIvzaPRFXvZ1Viocytg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                columns: new[] { "Aim", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAECSwkcMXyyouYKyCR0iNdCUC7cm8UlTb6gPBk9dOB+UViOWxhMmrjP4G55jvggdA/g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aim",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "ApplicationUser Weight");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ApplicationUser LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(1900)",
                oldMaxLength: 1900,
                oldComment: "ApplicationUser LastName");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser ImageUrl");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "ApplicationUser Height");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ApplicationUser FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(1900)",
                oldMaxLength: 1900,
                oldComment: "ApplicationUser FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF5wM+hL6dltcZVc0vIHnu6Qg39h4uxHUpTorLVj0KWd0SX5R9A5QFT3ZZJg4ek5aQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad961949-3bf3-4105-ad2b-22c7441bfbc5", "AQAAAAIAAYagAAAAEBZocng9IPqPWcszgrYdpRgwIioB9RuKbSuM9nIjK/5WeN+OR0P6acG0g1bluQLudw==", "5a8240a5-d58a-4124-baf6-6be4440295de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b2ffa80-ab20-4834-a145-586d74b2042f", "AQAAAAIAAYagAAAAEPPgw3JLudNc4hECmArRwHsXfLJuk4SRAhwY0ILE3fI8SyQSUwTmrJvZE3zf2tKaTA==", "fee45331-00b3-430f-bc3b-cc9a1cb41a13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGftY+rowsGpixx1jUbbjCc8Io6XRXby5IiDwpxn9P490IVd+rv+TQfyLFvCJ7fE1Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELXbm/ekJzL7beEJ84a7srHxZDP68ZbCP7gdf9XtYh80lbDlYns1Fa9CdEYzMbDU6A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEND6X+zXEwkH6DCBTdakJNDJWXVl2ExvgDbHup+G/aC4fEkHJXIabCkPI/zVQ6LmWA==");
        }
    }
}
