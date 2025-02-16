using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewMappingTableDietDailyDietPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "DailyDietPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Daily Diet Plan Diet Identifier");

            migrationBuilder.CreateTable(
                name: "DietDailyDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    DailyDietPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietDailyDietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietDailyDietPlans_DailyDietPlans_DailyDietPlanId",
                        column: x => x.DailyDietPlanId,
                        principalTable: "DailyDietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietDailyDietPlans_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyDietPlans_DailyDietPlanId",
                table: "DietDailyDietPlans",
                column: "DailyDietPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyDietPlans_DietId",
                table: "DietDailyDietPlans",
                column: "DietId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietDailyDietPlans");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "DailyDietPlans",
                type: "int",
                nullable: true,
                comment: "Daily Diet Plan Diet Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "DietId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "DietId",
                value: 1);
        }
    }
}
