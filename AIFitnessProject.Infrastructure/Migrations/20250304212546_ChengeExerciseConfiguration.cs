using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChengeExerciseConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBBUGzic2sLvFmNhIRxPeoDJtRJfc7TS9BEB9OU5i012GPxw1MEfZWduIUp+FSwQ+Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "185de985-6676-423a-9c5a-872f506c26ea", "AQAAAAIAAYagAAAAEL6muBYCqgLr2OocjvGQxENhgEm00UIqeh4EdVPoUudT5fz26JmVGp5Ev+JWKPtilQ==", "1faf5c48-ba1b-43c1-bbe4-fc65fd8a1958" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d1cbe0-3b89-4574-a0c0-c131ebaf1923", "AQAAAAIAAYagAAAAEBHklPDZ0zhqTJKU57FW2E3R2+EYyAq2Fx1PSg3DUo31WSGCZonLOwci3QYe5o0V3A==", "2dc17d6c-b0fc-45f1-b78b-48b42cc34f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEidhiqCcNYz2/eUY+RWpOWHOkMbbuV9tlA2m2EWXc6WE3sSMjZ2GzflKOvgOz8mOQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899cbf9c-2850-4905-854e-34cadcf6dbab", "AQAAAAIAAYagAAAAEFj1gdcl4kWjgg1mx2h6iBpPgsen0vZwObiOF70xjZl4EyU3+UZkX7MZlbzUXP1Vzw==", "7dde9c98-3c3e-4fac-98bf-8dde15201bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJOHFukm7sOscMLeIFtqCIcu+JdmkxL5fMPH6PLxbocECEqrkXDVP3xQSAE1TQxRGg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA3UOHJ+S+6KUzIPsrbtxEB3pX9tszfmUyIZCJFbwqSc1lDD7fikGg3EfsDZ9oCFRw==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Флайс");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMp+thEIjy7jOYmn9VQKUwGSy7BmUPHcmMZEl7pNT5oDRv/r5KTYG1/l1VeiA5/06w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a76f7998-f479-40ac-a86a-06885e2084e4", "AQAAAAIAAYagAAAAEIo5Ie8+Y8cRf4nG7rV0jxf+8yxxaeh+M4SWL0bF/SNwSbgXGMu3m6zQW5gQhq+RxA==", "a54d203f-b947-46eb-9c9f-70add57b8a56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8d70685-5e6f-4973-a5c5-32f98ecaddab", "AQAAAAIAAYagAAAAENAUTeSmd8AnHjOBx5VsLLR6KFL1gD5oUgqbavb08yNMZPB4TDw/6rvuN7CblCpN8Q==", "31b558e8-190d-4588-a790-b1d3e924e714" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPJoRC7X3rV0smB8FgQ6/j2CJb4k2vHAH6ZiCHj0OrV/5UIoivfSCahleBXhx5iePQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef423e3c-a26e-40b5-a76b-6949b027de30", "AQAAAAIAAYagAAAAENe1WT6IRJSXggO5gh/MWrHG+Q473+2NSCbzy/J9a+/RJ6uPSp05P+ZUQoXQa7TiUw==", "e8142af4-5b50-44f2-8931-74484ee37176" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHGVKdM+1sCAdAIToNy65k7CgOD9U3lpBHGMSZqkUY4zDOXb7iw/CokjXM6x0jWtIA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBzOTDJ1dTt2VYebwxRyQEq6QX4pniBo7BrHFNjKVn8xXinv6CJQioA6tVflC6Lp4g==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Кофички");
        }
    }
}
