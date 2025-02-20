using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTrainingPlanAndApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEdit",
                table: "TrainingPlan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInCalendar",
                table: "TrainingPlan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Aim",
                table: "AspNetUsers",
                type: "nvarchar(2200)",
                maxLength: 2200,
                nullable: false,
                comment: "ApplicationUser Aim",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "ApplicationUser Aim");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHDB+2s/8gQkncAh4i6jk+zbxZ8mKQ0CguQuEX4hbpTUAWssj4fLXqXSpXEExXSCKg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eacc7780-d99f-47a4-8d5e-df8806653326", "AQAAAAIAAYagAAAAEEdGygUaZTKiZ0GoW6KukdH8025psvEe44f4y/B0PV0PFXoKd3LPJ45tKnDVIYNlbQ==", "7a044abc-305b-4e29-84d8-8a257f2d78d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "631b608e-0cd2-4cc3-b0a1-0152ff241b6a", "AQAAAAIAAYagAAAAENT6TwDCaUn7+FG/EAQq18ICWKEs5tBLsvgMDVuaj7SuAB2oSVsCtwk2ZqfH8mKOkQ==", "f0d66e23-8f24-4485-b50e-7d072092007e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELz7RwprWjBQ7o7NPITseWtcUhKdLFm1g/kdGe4dhxwKEKlkLR4r7PuimkprxWcbIA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae891671-4c97-43f5-8b8c-3fe594b30cdf", "AQAAAAIAAYagAAAAEKntVeUFMPI2XTV0unV6gIM5LWFHqKn3g6AWILhV4e1ACp776vgMxxqfxNfFUidtvA==", "a31c2f82-e738-4d97-a3db-99e13a49ee8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAjOiPT9ZVeguxhB41wnWXkmG195OnD6kB6b7if+8/T4tGEe3WUh9o5SHs4WBG0zrQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECSvtr9JcBcRJ6Sd1EeBvpAUKE71vvbQBBV+3Rigz2A1q6OytsIaVH8cMG9LjZQjsg==");

            migrationBuilder.UpdateData(
                table: "TrainingPlan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsEdit", "IsInCalendar" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEdit",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "IsInCalendar",
                table: "TrainingPlan");

            migrationBuilder.AlterColumn<string>(
                name: "Aim",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "ApplicationUser Aim",
                oldClrType: typeof(string),
                oldType: "nvarchar(2200)",
                oldMaxLength: 2200,
                oldComment: "ApplicationUser Aim");

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
        }
    }
}
