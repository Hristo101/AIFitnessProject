using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseFeedbacks_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseFeedbacks_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECES298PCPbW66ev4k31amL8ce9Rqq4m9esB3702YcrHDFaxf74WNNj0k9qbngBE6A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1501a3a9-2827-44ff-9b87-b66db34d5cbd", "AQAAAAIAAYagAAAAEBtfXUE65dagvvfrBS40KYlBJ0xJ6UlB8jOfHorMrRXKhl1Xrv3tbs9CF1fZFoAVTg==", "3c7d7a0c-8175-4959-9fba-d5ee5c2c4c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5dfa33e-8fd2-40e8-96a9-5337a863a567", "AQAAAAIAAYagAAAAEHJlnFXC/2rwbjh6bMeZ4E8m/aW04KDBs1daKYu+mgZS10GaIiaiQCt3tTcpgb03Sg==", "c1be6dd6-00f6-4263-ac4f-78a9578d7170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPsKhLULrACedto/2xJ1KYAmjR4PQCq0L81S1fCaMzWg6uPMmfQfl9kfjKRh2Q+Wkg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95b52d7e-f0d7-4350-8b88-92ce4f50bb92", "AQAAAAIAAYagAAAAELFaHZpNxs1RhuIPZZnmizaZ0iP017MhirL1yF08DtDNNqkEgBiR2uBjaH81KdTs9A==", "bf497084-7d52-41bf-8f26-36fda38ebbe4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGHQQET3TIPPghdMDnfTTVL9dA7EkihEAO5GKjudO9WQt7c9CM6aJlEizoWdL1zxDg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO2O3oz7YQqGa6OTf96PCHi4COPDmb9NI65+uG3gqvQ4ce4+56iQCsTjRebWYQYemA==");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFeedbacks_ExerciseId",
                table: "ExerciseFeedbacks",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseFeedbacks_TrainingPlanId",
                table: "ExerciseFeedbacks",
                column: "TrainingPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseFeedbacks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFic5C7BOOarY3wbvIF6nxKx+NDJqTq07/pOuYZFriZW9shdQ9uFX/E6XDzyy0rRFw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80ae5e7-ca4b-46f9-bdb9-05dfcc036b0f", "AQAAAAIAAYagAAAAECaTjRD8GDHCG32tmfrXbgNVxmsJyTz8TTXE/cJdD+2y1fcVt2/+/RZe7m3XS4+WWQ==", "e84c8a77-e08b-46cd-a9d8-93585eaaf468" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8a82b30-b3d9-44b0-9dab-c2e1e828c489", "AQAAAAIAAYagAAAAEPBVOYSh7bZ6QqP1RTsmq9bo4qBAcvfiKz2icqRHTcFsL3zYTH9lYnu3yDZJSbPNvg==", "2b5f789b-7305-47f0-b4a7-a6728ea24c4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPCxkOjtV1gXsbHsPbwoI2qSqzvEETuFaO0vYIsTW/vPDcfGzu/3KmLD5rHEwMGA3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4c9bd74-e352-46f3-a13d-678fb79fb2a9", "AQAAAAIAAYagAAAAEBkdEx1P1hNudxQRps6R1lBGTDoKiCQguWDmszEAnIglBxIPeIdfTWUzQbRd1zDJWA==", "0803c220-3ecc-4761-96df-d7caa7f38b37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELE3AkNRZm+Bq+/W/XgsloURbiV8FG12E4U3ehYErmM4oSiKSfY1NJ05lOR1YKEX7A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOai0MmNn5jOZCdQo2qE3+iNTRLRg52L6Z5KeigWhUHjmHkptjvza4wJl7D9LTbyYA==");
        }
    }
}
