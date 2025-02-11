using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDietIdToNullablePropInDailyDietPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "DailyDietPlans",
                type: "int",
                nullable: true,
                comment: "Daily Diet Plan Diet Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Daily Diet Plan Diet Identifier");

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
                values: new object[] { "0c5c9487-b4f2-4504-a0de-c02bf045bde8", "AQAAAAIAAYagAAAAEIehJcssC0FW8XrahPMM8/F9Roz+8+1zr53BuiEpxqo8H69RnnKKJyNJoceXqF23Cg==", "04eeec27-90c4-44c3-baef-68028fc76cb6" });

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

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "DificultyLevel",
                value: "Средно-Напреднал");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "DailyDietPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Daily Diet Plan Diet Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Daily Diet Plan Diet Identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENA7KtKqGMu0R/+Je11VVtVCM5CZB2mpBuzOlZHLxALmh/FraiQpsQfS06izZ9p35A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a77f2c-3774-43cc-b12c-74ebd0741db6", "AQAAAAIAAYagAAAAEGFjCFs7PfpwCkrQf0C3U8CraGZh9fjqSQHwH/+F3i2Zt3CJZ1NmP9yHtWNJQE5P0Q==", "6f806716-2387-49be-b31f-2a85a5c82281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f102aec7-e6a2-4549-9c4e-b6cd9b7a3f81", "AQAAAAIAAYagAAAAEJleWOYxl9FgCLYIGHHon8Oy0jtUzrR8RUxEYgodeQWjcg7gZ68OAzXbAD/j3ARShQ==", "ee0ae8eb-cd06-44f6-8ec6-11d94cb36da4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH2RADxvVsgyUMwmbwsf6pWtlWqgJRVbIv+3un5NPIIRAD+MWZ/vp+ua74xaB++1rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf1a6b30-b187-4b32-af22-f82327f9c389", "AQAAAAIAAYagAAAAEE+rvci97QnSfFMAbhgpcWX25rNUplkQl+6YqEVMZIKnVYOBc4QSE1csYKmmLWUR6g==", "24769007-dfdf-4762-b635-d793b2c28cfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI8+fITeoPTBltauvJYs8ywD6bpQh2LG7ClWzXlPxiUvaVUsUwmwHOxDJTm6kltxEg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB0LOM6kGVyDxcWkPOyJLz9cvRrQSsuHZWwYpOSdizPBcFzfjf4Q1a/nJXeGV5Gk6A==");

            migrationBuilder.UpdateData(
                table: "DailyDietPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "DificultyLevel",
                value: "Средно");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDietPlans_Diets_DietId",
                table: "DailyDietPlans",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
