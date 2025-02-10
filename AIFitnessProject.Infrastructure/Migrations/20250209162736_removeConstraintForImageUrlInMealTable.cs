using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeConstraintForImageUrlInMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Meal VideoUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Meal VideoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Meal ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Meal ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBVIAhklvjlDZs20DvuNJh/2uRmuYhWBGVnSbRbAlGFV7/aYR4atAquP7W7XVfls9A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aed255d0-58c1-4d12-b4b5-048a09ec4a4b", "AQAAAAIAAYagAAAAEHTdHaGYBdrA56Kxxg2CzSCA8ZLGEtWz2f8BA3OqhtCphFD7SFdBWm0vukPZljwb3w==", "256eff4e-1fdc-4ed6-bcae-0916de87b700" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87fc71a6-4546-4f79-a9fe-a593954ca853", "AQAAAAIAAYagAAAAEEaD8k/Lzv/hpSlp3FdGi4px2BLZpDqSNp6vmqxqFjRaafjFDmQDv9ztxCVWscxiRQ==", "a46ea4bb-3274-4bac-95b3-c66cbccbe13c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECx8PFcgltGvhLNG3IvAquHEvbIOQh6szIVoIBoL4pxcCtSNUThYugYA96Q5jzC7ow==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0151e659-bc41-4678-9819-761264e8dc1e", "AQAAAAIAAYagAAAAEJvLN6oSGcr0iNe4aj/9MHqmOGhCXgkUhTm1+0zAIiphAQMTPhWfpBHe1m75rSPKOg==", "3127e566-7f79-4c86-9c97-be691d1f0caa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF5kmbrvgdCNMBqhdY82GrE5Seg/dB/QxgXMSA6tBeANeoTtUmjAfJ+Wy+MyNAB8FQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECGgsXYVSdiKoFMYf4uO/oNkHurdMSuOFjKrjOHwyndz4UPCctNF0nj3fM618MinoA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Meals",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Meal VideoUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Meal VideoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Meal ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Meal ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBWEpSH0Du/ImBm6LsOMwF0RZ5gC3F0ps3wNnSsdAF7r7JeN7QRpuQiFGfYBZ8970g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "821b2ce8-07e3-4c0b-9832-05d824057a07", "AQAAAAIAAYagAAAAEKOCsaX14/B3g+onaq3lZp8bh9Crkmz0vE8N7BMspg7srKIL8aFghdtEjzDiLkwYWw==", "90e2c8d1-a034-4688-b682-b7bc7277c790" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0690bac3-772c-4571-8525-aac5cfe6e66a", "AQAAAAIAAYagAAAAEOpBfGKKz5yNGGE1PXLL6ip6bFwIUMmCVbgohxUOgCL0bPO38yCQhMZ2VtVdqt4JUw==", "a2126402-530d-4d59-840d-a5c9bc3d6cbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENaOHGiFe7owOPyE1pX14elqHQ8sloo2OIw6zh1Z6LEOm7yYcNSKyn0rVt3QJ3aDFw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bea482c9-82a9-49bf-8731-e76c53763494", "AQAAAAIAAYagAAAAEHsYmB4I6IYtAz9qI0rTBvjqMwnkj04opyDrwDXYdrUb9xvuGEicpOZlyVmX3w8msw==", "9757434e-154c-4406-ba68-41a6005a4956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOwuKhCEeHkSymcutG+RBq9aoQtwjzekE2JEy4zGjB4pEu05xS6zFq+RVyqTPkU2cw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJxczVse2aX+bE3OZNlkt+RhKDC4bISAurVp2yRvJt+vVWHzqfV4f2KFa2M4jz3hyw==");
        }
    }
}
