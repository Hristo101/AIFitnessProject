using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanAssignments");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "CalendarWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECB0NP2JnORxe9a1E0feldG2elsjasDTVSi0kDsMd0RGdFvkZB4z3sQMurxOlnPXLg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f98ec4b-d213-4916-81e9-7813f8d62263", "AQAAAAIAAYagAAAAEF9XvfiK12UsOAEB+WkVPavAUZZo53/ZDQCv+QNA4NZ54ewh/AH030vjWybcVk6uDQ==", "f67274c0-434a-4531-a518-1f9928bb07df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b52d5a-0e6d-419e-8065-4691e7aef9fb", "AQAAAAIAAYagAAAAEMYPfH4HNYe/Aw//zjyCIpoYqdyyNSnjG02iLAFgRYLpfyabUWQ1fQCOQv20NcCn4w==", "37766b5e-a4f3-427a-8d4d-a5468e4f1c01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBBlV0BJouldXtzO39yJ7UaSifH2kmfbBmscwb9/WjxBfkkcCPLGiXIb5BlIdGg5xw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8cbcd66-fcbe-4e41-9f13-b179b03488b5", "AQAAAAIAAYagAAAAEG2q7vk7YW72ztmRJKDDRYAT/ObJVsM+2U0943Vk2R+VblPllEh65mO1jKJsZXfmPA==", "f9c489ab-6a8e-46ee-8a0c-77627fb1ba63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHuHrjMHoZtZEOginj+lzf5YP9Meu2vPWWG0h+rztGSaFzRUjfTpqzVTWVRlMiti4A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMaDj6zacZ9p47LXb6UPTCm7Oy6kgWJBXPhd7wQ3/aFm+uaykjZR7GNCzz+ZNVwbOw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "CalendarWorkouts");

            migrationBuilder.CreateTable(
                name: "PlanAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Diet Id"),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Training Plan Id"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Plan Assignment User Id"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End Date And Time Of Plan Assignment"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start Date And Time Of Plan Assignment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Plan Assignment Table");

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
                name: "IX_PlanAssignments_DietId",
                table: "PlanAssignments",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssignments_TrainingPlanId",
                table: "PlanAssignments",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssignments_UserId",
                table: "PlanAssignments",
                column: "UserId");
        }
    }
}
