using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TrainingPlan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TrainingPlan",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Training Plan  User Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMOTvvzlfkfmmOCuhpRw1FltUwnlKKWbwk/xVI4Q7CmVSc2OdWKV0RQU9WgD3dxl7g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a31b8f8-aa02-46f9-9bf3-87e722bddc28", "AQAAAAIAAYagAAAAEEwPrePHLOODbXDgwfFTPue+Q7qCcvL/MKhOq3qIRljAl0B7HsC/jgkxfL2ejsAV3g==", "7a2918af-d13f-4869-8025-41b949876307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d56dd3-51f5-4621-9128-89a26ae9ffd8", "AQAAAAIAAYagAAAAEOfF1jEOmKI8kSlbPKXIlSSRkwSwR9DWMkE+rOSZ42/+HNstqgqxoaC4rVRv6C2EHw==", "efceadad-c536-40c8-a232-f66716f5dab5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA47QmHbITddCTwSzVsxSPtRIfZO6J7ek4QHVCo/ywXdJ4r1N7IIdnYAE2Mzkcvczg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "617dd460-d5af-412c-a207-5a1e0aee823e", "AQAAAAIAAYagAAAAEJjCNgFuNY19JwKyTCzezDNmp1wQdxxHlMXN/BWegtz9BzQsAkQk1v0rh9ehwvg2TQ==", "7b9daa33-bbc7-4f7a-a188-8d34227a3c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMUQ+V/f1zrA/OznLhwZJnIO+7jj2gYxswr7/tQzT9noeQf1uyRo1WtR8c7SAh+bYA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPfwqYZ0BfvppCrGnLCIK9vewII5KrTn9AA1kc+fwy9wCBt0MseJQ39/GJt128qLiQ==");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TrainingPlan");

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
        }
    }
}
