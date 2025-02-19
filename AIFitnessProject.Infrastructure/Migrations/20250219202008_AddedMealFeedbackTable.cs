using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMealFeedbackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealFeedbacks_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFeedbacks_Meals_MealId",
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
                value: "AQAAAAIAAYagAAAAECiypZH/cuN5pQRG6Rtf3Ig/bd+idqupkFBMcwmc2WRMuVpXHFWTdOmHkkBe6JaHfg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c91eb2e4-b50b-4307-867a-4d8ba99459a2", "AQAAAAIAAYagAAAAELza3/L6rte/xxns75h+1RdseS2Hn6NIjRClzzk8ALRrlK1w+Axot4LhXmfClOgsRQ==", "703e1eeb-066c-4668-8a18-d22694caa1ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97fbd764-dd00-4656-a13f-70ddeeb89ccb", "AQAAAAIAAYagAAAAEAdAy4ElIxprYzzCf3ZqGb2lIPDdu/jHSVecx5WlgQIXz0SL/G0FLgT5hL4TQgXScQ==", "b5f39067-4681-45ca-b962-ca53717ce184" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMUwfBFAsmXHsaqy7HjeLiESAS1xybbG/la7TWprD+9a7bx3mhIgD1e1+NDm0JQssg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78e433a2-6bb7-4b33-945a-5cce4623675f", "AQAAAAIAAYagAAAAELQ3bnxlBlJqFhDD95N6aa5RJsMhPLgAXNA/ngVEfCBSwMV1TYJurL0nR7ezF+dxOw==", "ecb2063b-3d97-493f-a5b9-1638d48666fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBQJFaoXphIs+BdY25q2dAMaME6ubdSGF/IMn51N6UWjbXN0YOgONWuXDLFnlLFr9g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBslj5gyzT+HB+cOfuB32/R963CPnKsHszaXa8i1ehJZW9BqggFsM51/r3BqQft3jg==");

            migrationBuilder.CreateIndex(
                name: "IX_MealFeedbacks_DietId",
                table: "MealFeedbacks",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFeedbacks_MealId",
                table: "MealFeedbacks",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFeedbacks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKzOf+se9QPvJXOnRVuRpWMaLI+9m6tkRMbSq+Z3A4vHtGqeZObVZrbFVZEJ2hUniQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8953f088-98a8-498a-8dd6-201b5e4b8190", "AQAAAAIAAYagAAAAEGPCRA3VXhRBKeVjx5UGb76AfvQ/94+cgX4mghToF6RUxOHmdMfv4WFHaKzSIeXvzg==", "25551af7-8b78-4884-b50a-5b9c6ff66a45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b36ad33e-7af9-407a-9d14-5f0cf310652b", "AQAAAAIAAYagAAAAEI2idzsYyPxDMYmmt2RxiN8J7SeR+foXiwwQlHCE5zcStPNfioDcJ07p2kO1wjnDJg==", "8f9e01b1-fb33-4c13-bd27-7a563a47439e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFPolLW/wP7dwEcptyIsHx6zF2XozBJVPHntgWBL2OkIc50JFLIl/Ih2Cv9z7Vj68g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb936daa-012b-4983-baf3-2c11d9e5df7f", "AQAAAAIAAYagAAAAEJrZk+mxIpTsDZvNRakfL0LMDaXCoyNojcm5IhMmf1p8o2qNGNAd8lSYJK/Uzq5jbQ==", "498088db-d240-4262-8404-03beffd5f5ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENiy9XGp4DGGKjkgHx958AvGM5EXDObGirOzIihRvpq/OI5PZRcQGjrQDv7MazO+Gg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOHEYPJeUowpWntlVwTfsoPhQdd779yzj4WAU7FzsS2cdEkKl0G+anEz6ETJm19yug==");
        }
    }
}
