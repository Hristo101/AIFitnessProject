using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDietitianOpinionInOpinionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(3500)",
                maxLength: 3500,
                nullable: false,
                comment: "Trainer Bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4500,
                oldComment: "Trainer Bio");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFxglJHjHpxB2L3BkvEk5nIv7nnyzqiHaMc3068wTkqq0zinjutkV6gQMAJFyZumLA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "966aff5a-c15a-424a-ab00-67e76c8aefe4", "AQAAAAIAAYagAAAAEFnjLE6mClnzKFul7qoaUljyhhiiDrAppZfh0cBP7SngG0reB+r0H6NQpaeJnvHCzg==", "d29a9b01-e56d-4e42-bee0-8c9a7d5736a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfe7b45f-e080-4612-9009-71cd7d59838c", "AQAAAAIAAYagAAAAEBjhqL4YfXUv3ZFTccXWqKZ+vnWdDrXxh2aBfDKxhDY6LO9+G1U9jqlO/WAHnPPDsA==", "c0ae5b1d-9ac3-4df5-991b-f4534caf2505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEC03KXXyEp3r7UruXEF4eM1J7Jb26JyLcb7wqUPquGtuEk8ZITSqVJWq5h/7Lky0fA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENgm7zgWO2VpjtbPxWxmcdEdGnCm/R3EO+uwQ/3KxF2rD8EJj+PexaAv3Wn8xEIl5g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHbqYl3v3s3x92vTdsl9IxcrKzYOLtQw5sl8x/bpX6isnEoCl0JdsqHi3vcoTTOxBw==");

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id", "Content", "Rating", "SenderId" },
                values: new object[,]
                {
                    { 3, "Работя в тази компания от близо година и съм изключително доволна от професионалните условия, които предлага. Заплащането е конкурентно и се актуализира редовно според резултатите и усилията ми. Работната атмосфера е подкрепяща, а екипът винаги е готов да помогне, когато срещна предизвикателства. Най-голямото предимство за мен е достъпът до постоянни обучения, които ми помагат да бъда в крак с новостите в диетологията.", 5, "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8" },
                    { 4, "Условията тук са едни от най-добрите в индустрията – модерна платформа, която улеснява работата ми, и отличен баланс между натоварване и заплащане. Заплащането е не само мотивиращо, но също така включва бонуси за постигане на цели. Допълнително, екипът е невероятно сплотен и винаги готов да сподели опит и съвети.\r\n", 5, "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: false,
                comment: "Trainer Bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(3500)",
                oldMaxLength: 3500,
                oldComment: "Trainer Bio");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP7twYbD73L1tvMYvBNEZtu/Irwgx2BfqaK06ZPUe6NGhDIeyjBiTrCLM1XdqRylBA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d24ac6c6-b750-4280-a556-f8911fc905d9", "AQAAAAIAAYagAAAAECa5kfpC399ybPM9Zg/r+bq+YYSSIF1/ki/Ynnecw1wCdIMsCRtI79CdmY/QBTG7Sg==", "71a67f19-fe3f-4b4c-b6d2-3cb01afd5ec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "158f6189-4683-4b56-a35f-27652f1a82f0", "AQAAAAIAAYagAAAAEJHEu6pnH8nXNjZgueHlq50koP7jHiOSwHMbFHjbCZp4eSZNuDg4MxeDrv8hpn+YnA==", "cd0cd8b6-1c0f-4ec8-80a2-cf080506db53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIpexVp+g5ChxXkCUr86ISikpOgz4e20bdaJ7A+fW53fZ7fzblWYp87wI0Ws3KUCkQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBPNWOeLUtn/B282arHwdNWfjI7EKjGOIceb5MOW3HY5unwF6IaKpdmI3JUinGTvsA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECcA6ozTYEU1yLlVrSBuwB3TO1uicImnG5ypE4J58e2xFQqL+GDtE42RFgyzftzfOQ==");
        }
    }
}
