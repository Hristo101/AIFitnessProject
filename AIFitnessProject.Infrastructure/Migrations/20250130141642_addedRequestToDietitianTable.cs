using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedRequestToDietitianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestToDietitians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request To Dietitian Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Target"),
                    UserPictures = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Pictures"),
                    DietBackground = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Diet Background"),
                    HealthIssues = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Health Issues"),
                    FoodAllergies = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Foods Allergies"),
                    FavouriteFoods = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Favourite Food"),
                    MealPreparationPreference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Meal Preparation Preference"),
                    PreferredMealsPerDay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Preffered Meals Per Day"),
                    DislikedFoods = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Disliked Foods"),
                    SupplementsUsed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Used Supplements"),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false, comment: "Has the request been answered?"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    DietitianId = table.Column<int>(type: "int", nullable: false, comment: "Dietitian Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToDietitians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestToDietitians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestToDietitians_Dietitians_DietitianId",
                        column: x => x.DietitianId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Request To Dietitian Table");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECXUkySsbOGpdM/wtUEgtrJMlwiELSXnYYPdgeVubKOgE1u8ieomWLLXy5eIWr2Gmw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb0a68b5-1d40-4464-9773-7c1504c995fe", "AQAAAAIAAYagAAAAEEdoTY8cwmqpCvsBZMIVJ2N2KZ5Gjr7lXyMU1SFHRe4iz/a5ygE5DOxduc036YPfdg==", "a16cadc8-ba2b-4bb1-89ea-d2deae6fa7c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3b9624e-acc7-4fac-946d-93cf27281d5e", "AQAAAAIAAYagAAAAEAd9TK4duDNZ8aTN6CEJI10kIUJIluigQ1yk6kqpWbPwhZkjBmicHQOHkCf91XhO+w==", "01eb230b-7533-4137-8c7a-8fa4e078a838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKvgasPKVVgUXPyrYr/1iRzMxeHiRKdEoUmUn3eiooyiAodHuV38wzkI1h6sZ0YwkA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3906521-0535-41b4-8c8a-0e483ce12bf7", "AQAAAAIAAYagAAAAEE2zitJX3jSo+Tzwr8m1CvwvZ50uL/3eOevSOYGhPj+YKR+UGQNOEfAtZQICYNCRAg==", "72d51d9f-5183-447d-a88b-bf3b64b8257e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIB4MMGMSkUEoVOIQp1NHce1f2mfgjCMfKcHgkn058tWJIxYgsuAyXH0QNN/tYNTGA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDRtAvHCJn5oYrRFj2S4qYdGGi3QdAJgTVR0tLjrROVd8YFshdeia72dln52t2qdSQ==");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToDietitians_DietitianId",
                table: "RequestToDietitians",
                column: "DietitianId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToDietitians_UserId",
                table: "RequestToDietitians",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestToDietitians");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFFOoqzUtxL+JJGnPKRbFYa9RNfpK8ilmXvXQSK6OTcFc2/GSybrO3MtZollo5nYdw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "879c93b1-a863-4cb2-be65-99b3f08a1bfb", "AQAAAAIAAYagAAAAECc5LWOCojufcZk+8oqygJI/hXlDCUP5Zv9N/LvATFlpAQqWna5QWopJ8gDFlm2sQA==", "a50cc266-9f03-4135-9364-e04b62f9fa0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3371047-9b98-40e0-a17a-27a0dfc87247", "AQAAAAIAAYagAAAAELZ+yikOJe8GTGQPQp6+AZUCbc+4liAmNH++/kNYONtAUG7gSCf9DaAygDHZQThL2g==", "782a6bc6-d19f-47b4-8d94-4389de03c6e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEESSmPTjpfwZ8UaGD4jxnemqXKPIwclyEvpkrI3nja8xfjSoMkE8/eLr4ktTT/oJpQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4948919-603f-4024-859f-ad9635704d8a", "AQAAAAIAAYagAAAAELHN5cO5aDAqWXmK96XKEKoa1NhYM4rmIVPpHIuGmVEERVA7rWmcYg7lyDCjDhIq2w==", "776b04a8-ebda-465b-82c1-f262df794be8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBxippISxQrrt7c2f+z823cpr5Wbf6vB7gZ1uXJLhMMjGMPsUSI7NMEvDhcgRuxp/Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENMsq5G7P9ZREEZX9jDUWS47Ky/ooWxGVK6BTwlNp2SI0wnVHpFCZgDgSu7QbQ7DMA==");
        }
    }
}
