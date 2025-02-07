using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDailyDietPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealsDietDietails");

            migrationBuilder.DropTable(
                name: "DietDetails");

            migrationBuilder.AddColumn<string>(
                name: "DificultyLevel",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Meal Dificulty Level");

            migrationBuilder.CreateTable(
                name: "DailyDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Title"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Image Url"),
                    MealTime = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan MealTime"),
                    DayOfWeel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Day Of Week"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Creator Identifier"),
                    DietId = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Diet Identifier"),
                    DificultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Dificulty Level")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDietPlans_Dietitians_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietPlans_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "DailyDietPlan Table");

            migrationBuilder.CreateTable(
                name: "MealsDailyDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Meals Dily Diet Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyDietPlansId = table.Column<int>(type: "int", nullable: false, comment: "Dily Diet Plan Identifier"),
                    MealId = table.Column<int>(type: "int", nullable: false, comment: "Meal Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsDailyDietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealsDailyDietPlans_DailyDietPlans_DailyDietPlansId",
                        column: x => x.DailyDietPlansId,
                        principalTable: "DailyDietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealsDailyDietPlans_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Meals Dily Diet Plan Table");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB1nVjxTD47TURya47uMrLENDEPf7uEQWG9UNusg0yzihGvAP1MbKasWPePDv1wZHA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aee1d58d-18b3-4d8d-945b-9ca32a38ffd6", "AQAAAAIAAYagAAAAECC43Q2N7q2fJ1dKlhe8+V5febPzD6pW4Cy9VDrwb2PwuudKoa+1vkiP6y8Lh4BRdg==", "c5ad3a4a-c5a6-4aa2-bf76-166984c3f39d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c714ffe6-2b28-439a-bb29-123513cbcf08", "AQAAAAIAAYagAAAAEFbRawXhiz3nXvJEF6mXFH5t9VH7fl5AthS/KkrwDlHXGW5b/nrQHmYIzaD2O2HX4g==", "a2efca8b-2a2e-4b34-890f-aae673fc4dae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEGw2hKV8EC4G5rs+vMuvOmT/WZabGTFmjLlkgF1c46NFa/rggEzWUnV2vJNreoFjw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d5bdd46-f30f-426e-8dac-7d67735001ff", "AQAAAAIAAYagAAAAEB53xe22/RY8vRaXmW/dc7ZF0jnKCtbn+rAZb1JfAsOcTmjXpEbJjMRmyNzzW2bWfg==", "e08aa5d6-627d-4bb4-adaf-503ef6316b82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHviwjVzP0HzeGfz09S7x/mCEnTIAuDGp56d1AuXhsSGx0oX2xj0iyzKp4UE1woBgw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHPO40y5vpZoa/WKWbwJYtKdvSjOiSRRJGZ1g0ndtB+NnbYFDej506FJRWO22fQVNQ==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://spisanie.muscleandfitness.bg/wp-content/uploads/2016/02/%D0%91%D0%B5%D0%B4%D1%80%D0%B5%D0%BD%D0%BE-%D1%81%D0%B3%D1%8A%D0%B2%D0%B0%D0%BD%D0%B5.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietPlans_CreatorId",
                table: "DailyDietPlans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietPlans_DietId",
                table: "DailyDietPlans",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDailyDietPlans_DailyDietPlansId",
                table: "MealsDailyDietPlans",
                column: "DailyDietPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDailyDietPlans_MealId",
                table: "MealsDailyDietPlans",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealsDailyDietPlans");

            migrationBuilder.DropTable(
                name: "DailyDietPlans");

            migrationBuilder.DropColumn(
                name: "DificultyLevel",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "DietDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "DietDetail Table")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "DietDetail MealTime"),
                    DietId = table.Column<int>(type: "int", nullable: true),
                    MealTime = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "DietDetail MealTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietDetails_Dietitians_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietDetails_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id");
                },
                comment: "DietDetail Table");

            migrationBuilder.CreateTable(
                name: "MealsDietDietails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietDetailsId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsDietDietails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealsDietDietails_DietDetails_DietDetailsId",
                        column: x => x.DietDetailsId,
                        principalTable: "DietDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealsDietDietails_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAVI0Po5ciGeeTM43GFPrJrRaPbrLo7N1X1WwIzH12hSRAwCsayPvsnX4ilGR6FnFg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2ebaf6-bb1b-42f9-8d65-126b6f28fdc5", "AQAAAAIAAYagAAAAEEpXl7YCaBLXzp76Mj2eJNrNVR4tRJxL520I8b8b/R+GKh20lvSzKANrj8+dy60z7Q==", "8afd5f13-17a8-41eb-8465-25afcad46e77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51056973-ecda-4506-ad83-ade323d55ad2", "AQAAAAIAAYagAAAAENZ+bHXcqukGADSciHb0CBSExI9P46YPcZ03TvA0LDF7Aq0tqszmDbKBFKFQpE8pjg==", "59dd3f57-8360-4b9e-8553-ce4bed4f496a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECyZrPDRvDm4hd3pFHmr1uZhFXVyPL0JGQYA8nZe1cPu6aL/0DtwE5Fuvfw8twU50A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e871db4b-8edd-48d1-b99e-484030e33fa5", "AQAAAAIAAYagAAAAEEsAWJmXA4SABgd8cotdJJ2dzzeKCBOrp5ZHaXlztKbZtAs/dIQKE0YJQlXYsBSlYw==", "c16d7ee8-b6ac-4a92-bcea-9717c6426c79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBLjDXS101WYWyCbvWeJPlTV0tY7cPlVrBA5US/MCdnOlO34o6khGSavePy49jECZQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELvwmRkU2n59m3SzVJWapAXf5edFEHtG9mRfMRqx+olZYKtAW1Jlt8IImFJ5qqNBoQ==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://pulsefit.bg/uploads/cache/O/public/uploads/media-manager/app-modules-blog-models-blog/header/71/797/back_1800x675.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_CreatorId",
                table: "DietDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_DietDetailsId",
                table: "MealsDietDietails",
                column: "DietDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_MealId",
                table: "MealsDietDietails",
                column: "MealId");
        }
    }
}
