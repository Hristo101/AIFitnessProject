using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFirstMealImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://sire-media-foxbg.fichub.com/24k_bg/custompage-main/302854.1024x576.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPfcS6qR655t7k0pYEQD+n873eYjz2pb2ZrpDeim7NOhyNaBm2n/pgJjpgWTrNABtQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d08d80-6547-4343-bb4e-c536662dcdcd", "AQAAAAIAAYagAAAAEGj5CNRMIKTkU7rXZo0mVYRxNLk7uRnvIt3aQf8eUG5I6Su2K0SsR/Ks/w4j2bFWiw==", "e0458d80-0cc6-4bc5-88c0-b5070eda60f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c540985-4993-4a07-8c96-f7b027153f3d", "AQAAAAIAAYagAAAAEMOWvGOlLJ5CMyN2t8AdK4B9Vtr7UUTxFXt3V/CVh0CvmTqNKxvZKB6UlSHnJfIIIw==", "1e3fad96-5e0d-402d-95fe-df0dc4ee1f3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOfRHefajUplryPLsRfxnCiFsAJgpYPhpKil8To9x2QqEogYT3bGhDpGDeD3a4etvw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4e27b2-149e-463d-94db-ed8c413f80aa", "AQAAAAIAAYagAAAAEOZ5IEE9vqYO3Uw70iNAuKCTap4/GbUUvOEXq32uf6JmnQGlhqAnC8fJPgQ8Pgedrg==", "e445bc99-bc77-496c-9888-bae36bb48c02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL+Koko4/WIy4FGotWCNzfR92aY1Sh0RHs9omk+HriJdQ0C+YrwLZOvsqobMoFPa3A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN0LtbSLYAkRk+57VjmOCZGWz+RAoH4tJR8w0sTUS1puJLXX/FsLEZz6CU+QRT9oFA==");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://inthebeniskitchen.com/wp-content/uploads/2020/08/img_20200806_130537.jpg");
        }
    }
}
