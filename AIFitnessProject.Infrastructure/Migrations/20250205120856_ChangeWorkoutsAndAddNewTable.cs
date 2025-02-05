using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkoutsAndAddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Exercises_ExerciseId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ExerciseId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Workout Image");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Workout Title");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(2100)",
                maxLength: 2100,
                nullable: false,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.CreateTable(
                name: "WorkoutsExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcersiceId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutsExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercise_Exercises_ExcersiceId",
                        column: x => x.ExcersiceId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercise_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Workouts_CreatorId",
                table: "Workouts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercise_ExcersiceId",
                table: "WorkoutsExercise",
                column: "ExcersiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercise_WorkoutId",
                table: "WorkoutsExercise",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Trainers_CreatorId",
                table: "Workouts",
                column: "CreatorId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Trainers_CreatorId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "WorkoutsExercise");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CreatorId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Workout Exercise Id");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(2100)",
                oldMaxLength: 2100,
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPIgdhMF2auuGAbuLX12wPF0MeA2oHnkC3eUaCVV0u5tCjLKtfy0WezvjeYfFskpxw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe799749-f898-4c45-86ec-8a5fd5014cb7", "AQAAAAIAAYagAAAAECtO2CqZIazijIlaTsgAfX8hkUXnBDle/Z9X1vXedDJ+KGvnjNp+0jmcrltPoFWwUw==", "bba93f4b-fab4-4724-b1b7-c5da1d250fd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0c8dec0-766d-4fa4-8810-b86bc6d67d77", "AQAAAAIAAYagAAAAENHQnImzBlGI0pyRhpGZq1YU6zYbAE1+TSJHmJc0wz9Yj2Emtb5OwCASkZ/Px+feZA==", "5a505559-e3ab-4a59-89ac-8c1c5911eb1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELuWl4bU0jhKFo3G8ySSQLxaCpRdE9X8q0d0tC1t3yEAo6iSto4afTuJ6u9jj++OfQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "709ffada-158d-43b5-b070-710bf8818282", "AQAAAAIAAYagAAAAEL1qpT5LDgfTEQEB8+sFUbW5U+VpkC68nu/WP9z+4CPh/dGjYdkDkbkNDS/Kosos9Q==", "601c2329-a8f5-4e94-b9f6-281a50c39eaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKl7GlCeEczvTaF8mP6JJl1iqrZRLbCA6ufYiOZRbu9fGSE3KddpeXlypQBEYuK2Wg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA1qba/RjHxnvEkEnq80caPvpksAQjgR0T5tsvS1Xp4xX+nDN15bSjLmMvxZHv8cYA==");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ExerciseId",
                table: "Workouts",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Exercises_ExerciseId",
                table: "Workouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
