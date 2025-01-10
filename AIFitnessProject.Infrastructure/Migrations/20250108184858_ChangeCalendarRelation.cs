using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCalendarRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DietitianId",
                table: "Calendars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Calendars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DietitianId",
                table: "Calendars",
                column: "DietitianId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TrainerId",
                table: "Calendars",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars",
                column: "DietitianId",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_DietitianId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_TrainerId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "DietitianId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Calendars");
        }
    }
}
