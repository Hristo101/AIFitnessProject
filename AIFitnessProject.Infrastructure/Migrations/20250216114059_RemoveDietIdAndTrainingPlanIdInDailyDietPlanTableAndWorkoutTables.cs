using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDietIdAndTrainingPlanIdInDailyDietPlanTableAndWorkoutTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TrainingPlanId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_DailyDietPlans_DietId",
                table: "DailyDietPlans");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "DailyDietPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDxHTU7x15bjo3M951FynyIDw/vyPZK9qJdR+2yp2qIwKGX16v+VPX3hu+1rt351Iw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58bd40a6-d170-46ed-89a8-d2457f406bc9", "AQAAAAIAAYagAAAAEGKtkWm+43yjVR8M94Gvkyg69hAm3CE9nEExX4jEiPc5uovMVlJ2rOv72mCBL0I9pw==", "ad4a6688-98f8-4658-ba07-4c264909b946" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efad85da-7566-42e9-88cd-f0daf6d208bf", "AQAAAAIAAYagAAAAEJo93FFhy4tD1v38cei/7973E++DcPJy7SaNsou/BJiZEi6rtSIRToZ9mwPPC50H9A==", "3c2e0434-f7aa-4589-b664-e1b79d3d62b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOuj/jhqGiiwoBiFoLJEKXXiTEm8fDE28BL/4haQzfVVUUYIiDumCJVHLfuRbdkKBw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "241ba8e0-b613-4a95-b19b-87a62c0fc8cf", "AQAAAAIAAYagAAAAEAoPQQEitJH/ogvXrUynGIDSaHDzFrN7YB3+7HCPzrjZIOG7+5E1bif9XJcSR7cLXg==", "90fc2c8a-7061-49c0-9aea-998fb4dac915" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECdgROPENewLziesjK/lNhYKl/aZWuFakEVAzmqYH/u+D0Gk5xLe3zqjLMlZn4fBiA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIxXd749gNpEgs0/5G4X14XdjqiT7w4Rvx1/cKhvutnhDy0C2EcXhpF4Ga4vd7ohdw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "DailyDietPlans",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMKsPti/SxCYC/jzI2dHViKLJSl8Yw2RKxGjf14V3hevuv8qPCXUTJ6vEADujdVjIg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6beaf7d-aa45-40ab-9021-dd411ce8824b", "AQAAAAIAAYagAAAAEFI0LH++rNbK/InOKBaLwThItBndOLKPAPTb0IV5+9aY9NQQ4PUUgtLItjjdsGK/RQ==", "4417671e-a5a2-495a-a4f3-74688f5559cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7ffa602-ab87-41c0-b29c-e06458d3b116", "AQAAAAIAAYagAAAAEFXmRCAzN3AeUd/t5G9wO5QLXCjlS59icppelNWhm/daU7h9D/SMwTO4yHKgcclUIg==", "bac084fd-d518-4f71-a371-b7566bb290a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENA1noo2QM/FKzek436thPY0wvGMWLghZSOp4f2zkxJE1+ruhB65F+v7RkuXUKfLdA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a894858-065d-4012-9722-f93c707edd9f", "AQAAAAIAAYagAAAAEK/IjkHx/NXZWtpTXgMGY/j6iFEyCE5q3KeTRdUe8fDXgJ/j6F1it2UTVU+3wilyZA==", "936295e5-5281-46df-a9f3-866e6b50475b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBRjhwGcYVaLtSSgH4A2ff4O4BJYcNQQddFavzDab31oAATSjUQNQMb40lAvsSaq+A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPhXvIvJtf/pJwsgIcN94agu8TsRCrrq/wnYrcrkZ8dwttL1p0JmThrnpB61XGHRzw==");

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "DietId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "DietId",
                value: null);

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

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrainingPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrainingPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 5,
                column: "TrainingPlanId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietPlans_DietId",
                table: "DailyDietPlans",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id");
        }
    }
}
