using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteCalendarWorkoutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarWorkouts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    EndEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    StartEventTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWorkouts", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_CalendarWorkouts_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEJ+sY5gH4cdCsZrnuoaiaiqjpO7jLn5G01XXme7iIeSndvCq/NqsArIwNhmT7Iefg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e67bf3-7e56-40c9-8228-cae37d7c0c1b", "AQAAAAIAAYagAAAAEGzZxjSFurKHhbaHZY7kUSzmXsHWJUAZ2DSu5MW9/qGKiHyTl2jz1ZPi8q6dmiVtBw==", "c9866cd1-558f-4452-9b93-d942f21b575e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b664b52b-7c60-42a3-8bb5-48b584952754", "AQAAAAIAAYagAAAAEJi6IUEymjFJbSoIVO6gR0Zg4riBnfYX7fOc0sdVT0iHg1TNAG/nomwW+AUK/9LJxw==", "4597b12a-95ee-4651-8511-dde943447a34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDHGNP1r2XsfLEfqlcmGUK2YtqWxNpLbF3yUR9AUnt/dBdBPqg/TRdCjt2tO10j+Uw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae8b58cb-b492-4673-93b3-3e59f7094242", "AQAAAAIAAYagAAAAEMYl5/gy2yuQ3IYYPCzihfSopyoYWZ4ILX9CiEHziHzK3OPLCuu+vExRumCeYYXDAQ==", "8279b7ef-9fa4-4910-b2fb-be9dbcf356eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFaKvXemyLv0tc63W0Mu77bDVrUMxQQMhA48hvgvSRwdHkGlyM435xdxWgQJ5F5ywg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGHvQDYE8HEsAbIBF89Iu+yiT2axphh5fGAG9ZBdLjWtLBDxtHNvc2c/zS3UFvD4Sg==");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWorkouts_CalendarId",
                table: "CalendarWorkouts",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWorkouts_WorkoutId",
                table: "CalendarWorkouts",
                column: "WorkoutId");
        }
    }
}
