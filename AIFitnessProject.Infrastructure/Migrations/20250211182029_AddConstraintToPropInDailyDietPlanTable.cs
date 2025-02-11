using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintToPropInDailyDietPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DailyDietPlans",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Daily Diet Plan Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Daily Diet Plan Title");

            migrationBuilder.AlterColumn<string>(
                name: "DificultyLevel",
                table: "DailyDietPlans",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                comment: "Daily Diet Plan Dificulty Level",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Daily Diet Plan Dificulty Level");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeel",
                table: "DailyDietPlans",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Daily Diet Plan Day Of Week",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Daily Diet Plan Day Of Week");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DailyDietPlans",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Daily Diet Plan Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Daily Diet Plan Title");

            migrationBuilder.AlterColumn<string>(
                name: "DificultyLevel",
                table: "DailyDietPlans",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Daily Diet Plan Dificulty Level",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldComment: "Daily Diet Plan Dificulty Level");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeel",
                table: "DailyDietPlans",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Daily Diet Plan Day Of Week",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Daily Diet Plan Day Of Week");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFx31ALLusFQ0GPNbbKLTM0tXNbnrgeGfnrvNKizsJVIfEyOEdc+y95nubFVPzHrGw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c8af28c-58aa-4232-b982-5381465567f6", "AQAAAAIAAYagAAAAELc6s6yP/FQOGUQ2w2mjEPss/hEE87XFplajFcIenckYViSg0Baulj4yODrMC/Kn8w==", "8df7c7d6-d617-4cdd-ab65-edbab8393e31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87fc71a6-4546-4f79-a9fe-a593954ca853", "AQAAAAIAAYagAAAAEIehJcssC0FW8XrahPMM8/F9Roz+8+1zr53BuiEpxqo8H69RnnKKJyNJoceXqF23Cg==", "04eeec27-90c4-44c3-baef-68028fc76cb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM5CaG7N9Vupu1CKHrtjydPjUsH3c+aFZDfzpsb16IBhtb6cptkWemeHZhBnfLKW7w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6dd3d22-e017-4213-bf47-c55dd8ffaaff", "AQAAAAIAAYagAAAAEKr3tZs19/SYmzTIvHZzuhakiUMpbio3uip/+1hyLWx23ZtjLZd3uTL7EFAQxKCdpg==", "c807ee5f-8ddb-46ed-a2c3-89de502ff17c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENPpVh3ACqvFQJ5gbi995ncHRObzyrp0R2mDr9GYKUu0nNB/W2Y08l6IJSVcgRAnVg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEALlfllnxvnuILCeX8VEFnDz5Ffq0/nJxgtzcY3kIbIPncnYcqkdos/jl89BA6VnkA==");
        }
    }
}
