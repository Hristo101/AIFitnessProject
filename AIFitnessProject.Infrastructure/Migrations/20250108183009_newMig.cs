using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_ApplicationUserId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_ApplicationUserId",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_ApplicationUserId",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_Diets_ApplicationUserId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Diets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TrainingPlan",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_ApplicationUserId",
                table: "TrainingPlan",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_ApplicationUserId",
                table: "Diets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_ApplicationUserId",
                table: "Diets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_ApplicationUserId",
                table: "TrainingPlan",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
