using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCalendarTableAndAddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_TrainingPlans_DietId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Workouts_WorkoutId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_DietId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_WorkoutId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "EventTime",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Calendars");

            migrationBuilder.AlterColumn<int>(
                name: "DietitianId",
                table: "Calendars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CalendarWorkouts",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    StartEventTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndEventTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWorkouts", x => new { x.CalendarId, x.WorkoutId });
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
                value: "AQAAAAIAAYagAAAAEPv7OCRxKrBRhEvFqdYE/7gqXX9Ks9eKgR6xI6d9UYU4F+2a21peOsL61hlrH4+PBg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b294c6d3-1fb1-40ab-8188-62bd8ee63bda", "AQAAAAIAAYagAAAAECCcfzUz1RWjsKW6KthrvNG42z2W/HOXYE8rKEP8TZdJ78Nk3rx3XI58Ajzid4/XnA==", "c0493c08-6e3a-4837-ad30-1545d61c0d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59cb9121-dbf3-4184-97fe-59fef136440b", "AQAAAAIAAYagAAAAECTg0KoE0S32lfn7h2VFge4R06Mc6uykrxwzYS0gIW8s+fm1Jwwrj5YbbjdmsKp5sw==", "e66b6189-3a73-40f7-ba62-6658d324f438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMMSMU1UElP+7nNE4wg/GKxamFuNGTWCyk3AY639zFxnQVViq+r7HswVejtU/3/peQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b36f37dd-b44c-48ce-b7bf-88095052ec0a", "AQAAAAIAAYagAAAAEAtvNO/rd20LeEmmowx0fYgSUH3rvxjX/skKfGtoio7YrCCUt256dnUtywsigaPI7g==", "89bdd483-2854-4b59-8d02-87e4fad1d3a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHf0ZLdPhqYbXjHD5vc3EXIOwTUvT2abwcK3ILa+sr1atfHE1iASg6j5KU+OAz1Sdw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGe5EvK6A6s4w9Gm2w1P5E5nXqZ4ZHGydI05u6aQ0cG249su8XRenpeUBAijchPSOA==");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWorkouts_WorkoutId",
                table: "CalendarWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars",
                column: "DietitianId",
                principalTable: "Dietitians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars");

            migrationBuilder.DropTable(
                name: "CalendarWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "DietitianId",
                table: "Calendars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Calendars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Calendars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EventTime",
                table: "Calendars",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Calendars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEEkmV4XErrYm1wfMKawz+wbM8Y3UBKLuYv/kH/776YYsdPF39+8+FVndR917bw5DA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "238e19e1-6c11-4558-93ae-6cf4e57e7d53", "AQAAAAIAAYagAAAAEPsfPuxpH9mNTT1segFEHziOYM4DtGGbePjWgfPB726yplWypM8+HSnk/NyPYpFBew==", "329942c7-0253-4ec2-a75a-ffd8f17333df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ab93eb4-e89c-4b67-a696-21c36945a433", "AQAAAAIAAYagAAAAEAyUIFtScj4BrJ9AdJQh/F9+sZzype33tENSftTfT8AlflxQGDN09KZD1w58EmtVxg==", "b9cae169-7712-4708-8e22-299c34de2e77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENGy/Y9K2zIBRvI8QvC5oZiz2P1rzJaEgd0LRR/WAIIeJJaGloWYVGgIZ6BiYsn/Yw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77e4d07c-b9cc-483d-bec6-7ce42b3c0108", "AQAAAAIAAYagAAAAEIuUbikMJOYBqBLYVooEssgckkuZFH6uo/gPO+PX7s0fzroDSNpBES0vWoKE4E+oRA==", "bd350ca9-bbc2-4e19-8dc5-5fa6209395c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGBnYEnXGVT+T+cBfcbeSTB5jxAQtHei9HSX5cmpUJ04DWjCr+0UNfxPlcv78Hb3CQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENqW8jBN0A0elPs+W/0UVnTMZKMbtPw6IBILPZMOkTpsN1aqi2WfGSR0AoSH2L18Lw==");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DietId",
                table: "Calendars",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_WorkoutId",
                table: "Calendars",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Dietitians_DietitianId",
                table: "Calendars",
                column: "DietitianId",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_TrainingPlans_DietId",
                table: "Calendars",
                column: "DietId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Workouts_WorkoutId",
                table: "Calendars",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
