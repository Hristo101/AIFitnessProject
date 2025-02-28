using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCalendarMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.CreateTable(
                name: "CalendarMeals",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    StartEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndEventTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarMeals", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_CalendarMeals_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarMeals_Meals_MealId",
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
                value: "AQAAAAIAAYagAAAAEO+/1fjb5S4E8bpE9PaBY0YM8Dup5eYUSlOXcy8qVJvw1nusmNDXVnFDMEUDde6VoA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a80c08c-bb66-48d3-97ad-6c32996696ae", "AQAAAAIAAYagAAAAEMP/31Rt0B4nckNHE6CQKi8soaOk41Hco72KnnRDD3cuUk+MrLol9VwRPPGTJD3pVg==", "c5f2bf67-c1ef-4869-8b26-e2e4be885d9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca75aa53-eb6a-4dd4-a282-811236f6e191", "AQAAAAIAAYagAAAAEFrO6CsJsv8Tdv4Q6vmqgbkmsNAhdr/WAoLXDDZ3Xn4m9y7GwbpvwvCjxJ0gEF2EmQ==", "ff4c7cda-52db-405c-84af-bdf95a214c23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELxKVxFf58HUkiernDun7xnV1Er2tm6/y//MWa/SkTUauQkFhxoAIN1D2c5SaPumPQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a043cfe-2411-4e5f-a79d-35a7902e52fc", "AQAAAAIAAYagAAAAEA6AQxI6bmuFabyPRWnMKiQoGSq6+Mr9VDvkParY9Mcn8iBe1S5uRerpTIcX0dekGg==", "7c307885-3190-46f2-8275-e71546b32a3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBsZjVdlooBIpqLIEsD3m3k72/HzWn8nG4mx0Iiz94NUF4L6WNtx8MgOXaEothLH/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFy1bQhMPD+kdzwwJ/LDQdrNJH10qWY4+NxFasWYo+gEBbR6wsm/wHoNMj8nqYkn1A==");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarMeals_CalendarId",
                table: "CalendarMeals",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarMeals_MealId",
                table: "CalendarMeals",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarMeals");

            migrationBuilder.CreateTable(
                name: "CalendarDiets",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    EndEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    StartEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarDiets", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_CalendarDiets_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEL1zwvk8bq8uXpU49PrthbbgF8aSBpZxTuunnE1DocL5pZl4mzrT0TUyPhPmW6PEA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6b06a71-b0fa-49a1-af5a-f26e7defe08a", "AQAAAAIAAYagAAAAEG5sTj9ghBrkEL486qLaWlgOLlIlnI/KKF5lZDHF20NSAVaMrFpA9Nzj2xb5GOSNRA==", "90044d0e-a001-4360-afd2-f9a4b3f10ce3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee365639-8e4a-4fb9-8391-3b849c1aa4cb", "AQAAAAIAAYagAAAAEFK/eFvrHoKt27aOZ2TyK0jPQp137iI3g/31cVl97QFENRKrSCAFTbwy7D0uwV22sA==", "be87d7bb-661d-4893-88e4-5fd7ea59436b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJqsgrP0DaYbty5DWxSLqQ5pD9wA7MFtUZ0MlWQ3ibOO4rJkYcprFCCMqJlacfyrsg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc7e8fcd-4722-4485-97b9-b7d8812634d1", "AQAAAAIAAYagAAAAEHm5oSuYBUrUvl+7cazKJhuqxS3l8/O4V6h8a6FarpZEEXMhGOBDZT5um3WRBVOHuw==", "4b60a54e-df6c-4df4-aa2a-962a8f504207" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFVrwH4p8kxfekYPktkHt+aEmp6+Ky1pkYqwSy3DjPS1DqIKDGXsYSGEHR8FtLVDTw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIRB2W1q4PEC7anAAU2ObBE51liFPWZg++c2Om36gjF26icHO2+QFL96Gq4uCNFFqQ==");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDiets_CalendarId",
                table: "CalendarDiets",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDiets_DietId",
                table: "CalendarDiets",
                column: "DietId");
        }
    }
}
