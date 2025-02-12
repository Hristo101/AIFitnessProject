using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTableAndNewConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Workout Training Plan Id");

            migrationBuilder.CreateTable(
                name: "TrainingPlanWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlanWorkouts_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDawzMRpZLmEao67+j0c3z6iXTRskU0qhSQzWBDIdGx9+I3cPGwidYtspwUmnoXQGA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "593fef96-1892-49a5-bc8a-83352c162730", "AQAAAAIAAYagAAAAELpz+U2LLisy+uWUOqO5RZhhu7gYkFUZEmcAaltbRp4VbcrEBl/c6gzA6VuDAdovwA==", "42866c6b-6f54-49d2-8e51-dbd0ca304ed1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e92d9c7f-9129-4d42-beb1-c4d789156f14", "AQAAAAIAAYagAAAAEInrPE55D6OFK8NQW7dnJJDiZwhf2+Z5WrkLr4kNvIbEduv6/j/ge6H2yMc+3UX2QQ==", "7459c330-f6c3-4e2e-bea7-efa911644225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPGBYce8G2eSqxjeF3Qql1ogLf8a3RCbfFGLSQm9QaMy+2bXoLs3OX8aEtzZYH/ifw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceb11a71-16e5-4ee7-9b6d-f6174cd73f45", "AQAAAAIAAYagAAAAEFNLIbDwW5bKRbvj89xtEmvLuM35n3dcDbf1EfDvyAd8aQaB1VDlqGuigxXea/F/+A==", "091037bc-9267-4a73-85be-35eb3febf890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECLt1pWiV6e/OSzE+3UCS+TlWk7gSN+BeyAUnpylCu3akV4ORQPgslBaiBguJjXagw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDVMS0PZCn/VD+JC8+Ovq/zDvOBhoosxhb04pnNDmysOmLRzJo3JcgXJf0thDBLhjQ==");

            migrationBuilder.UpdateData(
                table: "TrainingPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg");

            migrationBuilder.InsertData(
                table: "TrainingPlanWorkouts",
                columns: new[] { "Id", "TrainingPlanId", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainingPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainingPlanId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanWorkouts_TrainingPlanId",
                table: "TrainingPlanWorkouts",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanWorkouts_WorkoutId",
                table: "TrainingPlanWorkouts",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: true,
                comment: "Workout Training Plan Id",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIRqEZZ93CoqXKp1ypVi4uBy5Vm4/VY+H2pk7a6T2y3SCJAlh9wkj05iuitEGhyoUA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0207b940-cd76-4bfa-af00-eb358fc7fcb5", "AQAAAAIAAYagAAAAEBe91Jdp+9dSWVq/k9NoOA2QkMMPp4mnYBvYyh6okwNaQHklkXd1YYrVGt4wKWapBw==", "a4d03d60-12d9-4b68-a2d5-ccc4ba134357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "068e5a6c-de17-4431-8c2d-098c19c2634e", "AQAAAAIAAYagAAAAECtsxqlQotdgrbYih1l2Y8uSd+x8bNtK94n45LhW7hlpuZ8rjlCoWBEgJFODS46FFQ==", "0d915e60-9890-466e-9fed-c4f975f76fc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELvQbJP/oTFdu5IyWpoDoDK0VQctcWIOhRNIB/y+o7+OjaceZtl7Eab6zFR6MXh+1A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f692ad1-e375-4ded-a3f7-486772122e31", "AQAAAAIAAYagAAAAELh6tmpI/RVM+cyvTtAZS8qu9UuhorWOskWpAHsmt8oVq+HfM9d3fe1L1+IH+LmIYw==", "89cb8012-b215-4034-a241-7afa69b662ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPjNNJt3CCegUux/oxRDNky2OsJNM5LRKcuhJV1Fn1LL05FB9VXcN5bPqnWNTZKc7w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECvFvG52wvOcPenRHbTEMfim2/0IXTa66whIXNNp7HqOlYbWZEquQneszJSf1tzn+A==");

            migrationBuilder.UpdateData(
                table: "TrainingPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainingPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainingPlanId",
                value: 1);
        }
    }
}
