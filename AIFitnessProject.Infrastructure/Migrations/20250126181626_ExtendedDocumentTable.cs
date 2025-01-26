using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Documents",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: false,
                defaultValue: "",
                comment: "Document User Bio");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceYears",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Documents User Experience In Years");

            migrationBuilder.AddColumn<byte[]>(
                name: "SertificateImage",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "Document User Sertification Image");

            migrationBuilder.AddColumn<string>(
                name: "SertificationDetails",
                table: "Documents",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "",
                comment: "Document User Sertification Details");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Documents",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                comment: "Document User Specialization");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKXYv+uyOCIwefwNW7Ow646UsSapB1r+qRJOPDh+kgWw0AliaPwmZWmEnav37aMWhA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08d9a8e9-680a-4c53-8015-a33c7fe61b93", "AQAAAAIAAYagAAAAEIkuN7O41Uk3nSHqFoFXskRzbVi0bh9CrdlIgpfDxDn0Xh0NHi/G+Yvb2TWaNS+K8g==", "d3b403df-890c-44cf-a52b-54a724614efc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0837f2a9-bfeb-4ee8-90b8-facf79cd86fc", "AQAAAAIAAYagAAAAEKOKcGkWEDrhD2D27WxUBTuMWCU60isrFEW/y0cCTOk5UiRqch6FRT9lfHggjixHbg==", "a4bd06f9-97df-441a-8809-5b54db4183ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGjxBBxPXkurlibAMNQd8TBySGXVTMcpuktpD2KTvJ1AGZZ43xAmSS5LMobwy8G9Rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENCoM/WGsWbcoF8iwhc7y2be7Qo2nG/YVoIW5hniv4hY4BMmEC2L1AmaEB759Loiiw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEbfkOEeLaAiqfXWaNsO4uHFAK7xgAyP4IHSsT8mPYsUbQm2s9pm3q/zigjjkyfPMA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SertificateImage",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SertificationDetails",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEME41r6QplCIpadGsS02KABE+sNsS/VPMTvreuwUwOCtKKFUWUPCicIq3KbU8p4fmw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1233c79-e694-434a-8902-260774f93f4d", "AQAAAAIAAYagAAAAEMBvuagO4LWgJWoe8PuKMTdo2vJf63oKXc09FxiR+5DYxjGMKlGFUZD+sZRNLxlgHQ==", "60162c86-54d3-4850-b626-f9f63bf9a420" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84a6d9c9-8a92-4b7b-93d4-85f5deaeb575", "AQAAAAIAAYagAAAAEMQVZtRrEFWZccl2FrZQFNWGUfn9bz6JMnkKU+If3ydpWRrtKUNJ/JA2yRL53gDwsg==", "cdf50194-fca8-46e3-8673-912ec3a7cb8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJ1JBP7JZXebcDlhDVpQtEZXuqSvkmcQPkRjIczACvLCvwBv2rQJgYQdnBCD0SKs9g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJeq64ZfzAch1984Dr/mAUxe1YZ4hRBsItsCwmqWNntwMpG0CR+japcEP8Gx0iX/zQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFabU86UD6pKgw74oSRHohcn3Q105h4SDnvo6M541AEvvQkIZzccGqn530Ta8b/5mA==");
        }
    }
}
