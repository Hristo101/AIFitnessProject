using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableCalendarWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarWorkouts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    StartEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndEventTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWorkouts", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_CalendarWorkouts_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CalendarWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_CalendarWorkouts_CalendarId",
                table: "CalendarWorkouts",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWorkouts_WorkoutId",
                table: "CalendarWorkouts",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarWorkouts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBQ9rR8ADBMAxrqtcF8731OUIVpp9h4Nkq6FgwBQZVH30RktObHbCe3H/4IOiZnvDQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b6ebd59-8743-4279-b304-44c27afc099e", "AQAAAAIAAYagAAAAEFgzIhnfIFwhu0pgn0p5o35CrzCqtbM/bvI7YQVWLyQ8rPvs75jLsrRp416MNR90Eg==", "6c820c64-b8e3-437b-bb17-7f0f9ccdd1bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3753d0eb-dae2-4eec-9ec9-8a08e6366d24", "AQAAAAIAAYagAAAAEJlCFFlx9b9ThUIMY0W4WY8oaUJNEHO0/ghGM713EuO/aBTNNXEQU63KS6MUsUbDAg==", "2a4ffe9f-9139-4ca0-ab69-90b72390431b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENJxMn+9aF35atG1Dc+x5BYq+hcrKkPYI80J3MCP1LCN+SiBM6DDCebD55Y1InOGzQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3da8f3c3-5414-49ed-b4c4-8088fa226424", "AQAAAAIAAYagAAAAEFk1pVSrfAS9eeCLwTHOs1tl2G0a1a0xe4jSo+ptvkdDoHyIsJ+gqr98/YsXBCAwwQ==", "0f77c635-0b6e-4159-a826-a8b543e07296" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM293l7le3rkMTDmRllwv+2WTYomxzEwBy6UFJLJdCxZEYbLamdTWMx3WVMsC5FQJg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHY13NfI9WTfFID0xxkDBZjYQ/9uN5WDdLcnuHeL5cAf0QCigCmTqhcFu14dHIHWzA==");
        }
    }
}
