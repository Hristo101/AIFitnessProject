using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_TrainingPlan_DietId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseFeedbacks_TrainingPlan_TrainingPlanId",
                table: "ExerciseFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanAssignments_TrainingPlan_TrainingPlanId",
                table: "PlanAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedById",
                table: "TrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanWorkouts_TrainingPlan_TrainingPlanId",
                table: "TrainingPlanWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan");

            migrationBuilder.RenameTable(
                name: "TrainingPlan",
                newName: "TrainingPlans");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlans",
                newName: "IX_TrainingPlans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlan_CreatedById",
                table: "TrainingPlans",
                newName: "IX_TrainingPlans_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_TrainingPlans_DietId",
                table: "Calendars",
                column: "DietId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseFeedbacks_TrainingPlans_TrainingPlanId",
                table: "ExerciseFeedbacks",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanAssignments_TrainingPlans_TrainingPlanId",
                table: "PlanAssignments",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_UserId",
                table: "TrainingPlans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Trainers_CreatedById",
                table: "TrainingPlans",
                column: "CreatedById",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanWorkouts_TrainingPlans_TrainingPlanId",
                table: "TrainingPlanWorkouts",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_TrainingPlans_DietId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseFeedbacks_TrainingPlans_TrainingPlanId",
                table: "ExerciseFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanAssignments_TrainingPlans_TrainingPlanId",
                table: "PlanAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_UserId",
                table: "TrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Trainers_CreatedById",
                table: "TrainingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanWorkouts_TrainingPlans_TrainingPlanId",
                table: "TrainingPlanWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans");

            migrationBuilder.RenameTable(
                name: "TrainingPlans",
                newName: "TrainingPlan");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlans_UserId",
                table: "TrainingPlan",
                newName: "IX_TrainingPlan_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlans_CreatedById",
                table: "TrainingPlan",
                newName: "IX_TrainingPlan_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_TrainingPlan_DietId",
                table: "Calendars",
                column: "DietId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseFeedbacks_TrainingPlan_TrainingPlanId",
                table: "ExerciseFeedbacks",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanAssignments_TrainingPlan_TrainingPlanId",
                table: "PlanAssignments",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedById",
                table: "TrainingPlan",
                column: "CreatedById",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanWorkouts_TrainingPlan_TrainingPlanId",
                table: "TrainingPlanWorkouts",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
