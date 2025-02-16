using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDietDailyDietPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "DietDailyDietPlans",
                columns: new[] { "Id", "DailyDietPlanId", "DietId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietDailyDietPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DietDailyDietPlans",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
