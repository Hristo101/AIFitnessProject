using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                columns: new[] { "ImageUrl", "PasswordHash" },
                values: new object[] { "https://bglobal.bg/pictures/pic_big/gallery/media/k2/items/cache/b7fa828ba6765743b6675d6510c9ee83_XL.jpg", "AQAAAAIAAYagAAAAEF5wM+hL6dltcZVc0vIHnu6Qg39h4uxHUpTorLVj0KWd0SX5R9A5QFT3ZZJg4ek5aQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad961949-3bf3-4105-ad2b-22c7441bfbc5", "", "AQAAAAIAAYagAAAAEBZocng9IPqPWcszgrYdpRgwIioB9RuKbSuM9nIjK/5WeN+OR0P6acG0g1bluQLudw==", "5a8240a5-d58a-4124-baf6-6be4440295de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b2ffa80-ab20-4834-a145-586d74b2042f", "", "AQAAAAIAAYagAAAAEPPgw3JLudNc4hECmArRwHsXfLJuk4SRAhwY0ILE3fI8SyQSUwTmrJvZE3zf2tKaTA==", "fee45331-00b3-430f-bc3b-cc9a1cb41a13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                columns: new[] { "ImageUrl", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAEGftY+rowsGpixx1jUbbjCc8Io6XRXby5IiDwpxn9P490IVd+rv+TQfyLFvCJ7fE1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                columns: new[] { "ImageUrl", "PasswordHash" },
                values: new object[] { "", "AQAAAAIAAYagAAAAELXbm/ekJzL7beEJ84a7srHxZDP68ZbCP7gdf9XtYh80lbDlYns1Fa9CdEYzMbDU6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                columns: new[] { "ImageUrl", "PasswordHash" },
                values: new object[] { "https://p0.piqsels.com/preview/757/82/522/man-showing-poker-face-while-taking-him-a-picture.jpg", "AQAAAAIAAYagAAAAEND6X+zXEwkH6DCBTdakJNDJWXVl2ExvgDbHup+G/aC4fEkHJXIabCkPI/zVQ6LmWA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

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
        }
    }
}
