using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDietDitailsAndAddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDetails_Diets_DietId",
                table: "DietDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DietDetails_Meals_MealId",
                table: "DietDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutsExercise_Exercises_ExcersiceId",
                table: "WorkoutsExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutsExercise_Workouts_WorkoutId",
                table: "WorkoutsExercise");

            migrationBuilder.DropIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutsExercise",
                table: "WorkoutsExercise");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "DietDetails");

            migrationBuilder.RenameTable(
                name: "WorkoutsExercise",
                newName: "WorkoutsExercises");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "DietDetails",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_DietDetails_MealId",
                table: "DietDetails",
                newName: "IX_DietDetails_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutsExercise_WorkoutId",
                table: "WorkoutsExercises",
                newName: "IX_WorkoutsExercises_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutsExercise_ExcersiceId",
                table: "WorkoutsExercises",
                newName: "IX_WorkoutsExercises_ExcersiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutsExercises",
                table: "WorkoutsExercises",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MealsDietDietails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    DietDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsDietDietails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealsDietDietails_DietDetails_DietDetailId",
                        column: x => x.DietDetailId,
                        principalTable: "DietDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealsDietDietails_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
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
                value: "AQAAAAIAAYagAAAAEFhmeEpvxySs2Gecrk40tZZO0M8jnJOJBFhtk4FhpFUGbeCoR3FlECTTzVlKDkIXNw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9c0955-be62-4be6-9aa0-789f44e79f3b", "AQAAAAIAAYagAAAAEJN5jw1gWyYikYZ3oAj5n7kycse4sUO1BHrLfWUPe+eWUWVO+E551FdzcF7XGWDwCQ==", "4057b055-6dea-490c-84dc-979f76cf03fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ae06204-2ed4-439e-bd46-ea75278ad287", "AQAAAAIAAYagAAAAEE1PsUYlW3P5sECoaiQZHI22y5vYLkwHrbuDDVqocdMmZQ+7ewi2DyYKVY2gsTeRmw==", "d848312c-ab13-4358-96a3-b3abde397ee4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEINskEm3sRA6UG2IZPSzczu+i5xLGwE0pQJa0C3rDeVprA72yxBOrjLWz6otrphWFg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ba3ff19-bec0-4a77-b7e0-2f8fa31baeda", "AQAAAAIAAYagAAAAEI8UlyTVUz9n304cUwENl5NZ8Hxqu7yfgDmsFibh3lqd+7MWp296YS9LPND0/j6UvQ==", "9b6d5227-5406-4040-ad06-6e0f2d3d5d03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPztnxeedttACIdlBMxm3/prkK8RbWLcQBGvJxG10EvhlemKTv/EDtYhSwuW4Z4b0g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOTrZFdE4dSmv47ir32C6NBDkVLfo5FjGl6fIMl9b2qkfGOqx6JOlN642EhmE6MMQg==");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_DietDetailId",
                table: "MealsDietDietails",
                column: "DietDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_DietId",
                table: "MealsDietDietails",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_MealId",
                table: "MealsDietDietails",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietDetails_Dietitians_CreatorId",
                table: "DietDetails",
                column: "CreatorId",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutsExercises_Exercises_ExcersiceId",
                table: "WorkoutsExercises",
                column: "ExcersiceId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutsExercises_Workouts_WorkoutId",
                table: "WorkoutsExercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDetails_Dietitians_CreatorId",
                table: "DietDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutsExercises_Exercises_ExcersiceId",
                table: "WorkoutsExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutsExercises_Workouts_WorkoutId",
                table: "WorkoutsExercises");

            migrationBuilder.DropTable(
                name: "MealsDietDietails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutsExercises",
                table: "WorkoutsExercises");

            migrationBuilder.RenameTable(
                name: "WorkoutsExercises",
                newName: "WorkoutsExercise");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "DietDetails",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_DietDetails_CreatorId",
                table: "DietDetails",
                newName: "IX_DietDetails_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutsExercises_WorkoutId",
                table: "WorkoutsExercise",
                newName: "IX_WorkoutsExercise_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutsExercises_ExcersiceId",
                table: "WorkoutsExercise",
                newName: "IX_WorkoutsExercise_ExcersiceId");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "DietDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutsExercise",
                table: "WorkoutsExercise",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGRRcBj6deat0hf0qvV1znsF4aZ3utnWOcgcNbAR2zlpoVsGS623+Llo6RDscpQnhg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2be13501-7b6e-44b9-a3c7-b2b088a4b675", "AQAAAAIAAYagAAAAEMN8p2pM/KcU6Yjw6+dVqkwPFHJfmPEyw+5hKfsBD4EGwCbzeG1jkbtUtsTK3HIlvA==", "2ee0302d-8fa8-41c2-8bb5-47766b5d028f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5be12d24-dc12-46b1-951d-9ad764d1cbde", "AQAAAAIAAYagAAAAEJ9Hx5yyoUcDRvD6Mhhd42OuRheFGd5kjvc+T6NkepQ6REmX9EcmGaaeTJN7GYCpZA==", "7a7b576c-add7-479d-9868-eba98a1b17f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELN9tV+Fm9SolYkpAk681Y4n5ZqQNnT9vYnlzzfH0Ec6zpLSFA0Ny2fOY3TQ734bIg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5353c1a6-2d05-4cb3-b4f7-60d8b5335963", "AQAAAAIAAYagAAAAEH5lctO/R9/9qNvAbXLQs9qE8w/KRjFd8zAJw90h98eOwKgUkv0InNU/KiepCXjalQ==", "b68cd8a6-9232-4882-9f16-24dd2b11ad7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBambva3Dj1fNkSkfNGueKsXXveKssvvSBHo2QDm+Mce+XbAl9C/3V7QltSKrDbqPg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHSTI7W0DA5Tv2G8T9tQMt+Dao4zmTl80YhT+VsOMV+YLh7PMC/NnDoIqo0dGTbhlg==");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietDetails_Diets_DietId",
                table: "DietDetails",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DietDetails_Meals_MealId",
                table: "DietDetails",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutsExercise_Exercises_ExcersiceId",
                table: "WorkoutsExercise",
                column: "ExcersiceId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutsExercise_Workouts_WorkoutId",
                table: "WorkoutsExercise",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
