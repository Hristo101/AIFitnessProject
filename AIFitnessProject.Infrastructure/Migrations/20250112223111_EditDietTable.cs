using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Dietitians_UserId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_UserId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Diets");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Diets",
                type: "int",
                nullable: false,
                comment: "Diet Creator Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAuzXfsBwd2Nyks6kjfO8d+gSZoijTv3B7AvGx3T0qMKH/LnahW9xE+WkajiWr6v9g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEC4XA8NTNhj28te9IqYL1O0nw4PuYpgUZHxYg53DaHZCFvw+IHXuD7GSKz+FcMER5Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOsf6i2Cv/ahAgyAun/iZBS9lsJEQ7qKdTBgjv9Fsj5c1bvZUtXyxu9T143RWiJdQg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIiHlaJSkbxZqXCR/8MNGzjptRtmdLsuKdJHo1rUJxLzsr3fpHC/vsAJWjrHKt3jYA==");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CreatedById",
                table: "Diets",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Dietitians_CreatedById",
                table: "Diets",
                column: "CreatedById",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Dietitians_CreatedById",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_CreatedById",
                table: "Diets");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Diets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Diet Creator Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFM68RKgimHGjiKRoMSAtUzKefRBYrnao/1gjQLIbivb8Bmf4VBANs4nB7ncPVjvBQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDIpd+aKqv+7xBiIAGaP7pJYguYwZZT78GYsibjmEhQyiD2mGQ0eQ+LyJVbQY2Aoaw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECGFxDf/aNHmeD2cqTAp8/M3TftypGGpMtKKtgg1E/QZgIDo8gEnfUfsxfGcZcwSrg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIFvoI3xVPPF9gxggjgKrVjj8ia+hYGzec6NlCYEjtDYup4HhepiHbOfYedMHaMpaQ==");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Dietitians_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
