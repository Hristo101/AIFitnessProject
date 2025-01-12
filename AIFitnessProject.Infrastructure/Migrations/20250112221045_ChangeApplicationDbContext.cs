using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "ApplicationUser LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser LastName");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "ApplicationUser FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFM68RKgimHGjiKRoMSAtUzKefRBYrnao/1gjQLIbivb8Bmf4VBANs4nB7ncPVjvBQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDIpd+aKqv+7xBiIAGaP7pJYguYwZZT78GYsibjmEhQyiD2mGQ0eQ+LyJVbQY2Aoaw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECGFxDf/aNHmeD2cqTAp8/M3TftypGGpMtKKtgg1E/QZgIDo8gEnfUfsxfGcZcwSrg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIFvoI3xVPPF9gxggjgKrVjj8ia+hYGzec6NlCYEjtDYup4HhepiHbOfYedMHaMpaQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser LastName");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "AspNetUsers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "ExperienceLevel", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "0a2830ef-8be3-4ef6-910b-33b680d659d3", 0, "c37f9e70-f9ff-4e55-8c95-83ce9708cef7", "ApplicationUser", "stanislav@abv.bg", false, "Начинаещ,почти не съм влизал в зала да спортувам.Изглеждам ужасно и искам да отслабна!", "Stanislav", 1.95, "Ivanov", false, null, "STANISLAV@ABV.BG", "STANISLAV@ABV.BG", "AQAAAAIAAYagAAAAEORfgK+ZAa6B1/iInloF7eGl+TD1dKB/FeCjK9oXByqLZYn/BURl35M5u2KrZ55z1g==", null, false, "9e406138-c088-4d10-810a-8cb287aa339b", false, "stanislav@abv.bg", 131.5 },
                    { "0e136956-3e82-4e00-8f60-b274cdf40833", 0, "e105f213-ede3-4a80-842f-3c9dc11968f3", "ApplicationUser", "petq@abv.bg", false, "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост", "Petq", 1.7, "Ivanova", false, null, "PETQ@ABV.BG", "PETQ@ABV.BG", "AQAAAAIAAYagAAAAEMDu5b/LS95WQ2DlP3QfWckJrwehOBnYagLmkhTs1y1XKwNEZHhJm5yPUPeS214tPA==", null, false, "ddfff353-d2cc-4d0c-a9cd-c40f2914296b", false, "petq@abv.bg", 55.0 },
                    { "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", 0, "ec2261ab-a653-4698-bbf8-03187c3e1877", "ApplicationUser", "teodor@abv.bg", false, "Активно спортуващ,занимавал съм се с фитнес от 3 години,но не мога да натрупам мускулна маса", "Teodor", 2.0299999999999998, "Ivanov", false, null, "TEODOR@ABV.BG", "TEODOR@ABV.BG", "AQAAAAIAAYagAAAAEABPsq1WnQrPEYza4TeXjJy5R18T9iQybMfukWp2aUhppIybXbMLnGe3eyd7yWSB/w==", null, false, "d258ec24-1129-4a44-84b4-4597aecc18e9", false, "teodor@abv.bg", 82.0 },
                    { "cd87d0e2-4047-473e-924a-3e10406c5583", 0, "ddd19b43-78e7-4f76-ada7-a863c26dda43", "ApplicationUser", "pesho@abv.bg", false, "Имам някакъв малък опит с фитнес залите целта ми е да стана 100 кила,но килограмите,които кача да бъдат мускулна маса", "Pesho", 2.0299999999999998, "Ivanov", false, null, "PESHO@ABV.BG", "PESHO@ABV.BG", "AQAAAAIAAYagAAAAEA8v016wfKoIj6ps+UF2+E8G1fGxiZUd0GgJrDlZgCTkZK0JM8eKwy5RJky4gYnsuQ==", null, false, "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f", false, "pesho@abv.bg", 92.0 }
                });
        }
    }
}
