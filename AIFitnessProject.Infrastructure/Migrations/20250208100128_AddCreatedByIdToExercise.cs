using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPwMsrhHnx3R/VkxiMi8ZM7X0z7JCQcWr14Gud0VBitSv/glvR/zcV1pKP3mAjmjcw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6596fc1-6bf8-48f6-80fe-07cb37b9f402", "AQAAAAIAAYagAAAAEA3lkoO9arq/kQ0eG+s7PjJjcR4C3ZFviTWwfKdULeRH5I5Fwtb5RAvJGhKcScHb8g==", "9a25ce15-47eb-42e8-a552-f7bda2c2037e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd1d4ecc-7927-4a5b-8602-9b9afee6323c", "AQAAAAIAAYagAAAAEKdXXFyJXr6c6h5URSvgT8WmsKyZ20HJYVMtrlt44nzuY0nVndf46g3riofF0SOpBA==", "e7a0a057-140a-42bc-b7f3-e2d90a27a119" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECG6WufFOlecZoQt8bH7k0NXcCrp4OLXV0t0ABemfZUw6JSqCood0nK8V2FLwUFh0w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df2956cd-92a8-4899-92a1-35e2a306b46b", "AQAAAAIAAYagAAAAEIpn99fO0AbYlvMi+YziKV1XZLXCcDtKzNaGrspkNbIFmYncdYQt/hFuyfgU3FLCSg==", "321546f7-c4d5-4b09-9433-494615a4e393" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN+hTUdDcPkjJSub38QdcqyFtZjAweuLJJE9DrgdHYakZ3sYXYW+ACmb1OwwqIs0Iw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENBkjkgM+jckmSShtvfSrpvXdtFaYSaTi4INzxp9+vFwMU5sqjq/zclO4QR6CKAAGQ==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedById",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatedById",
                table: "Exercises",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainers_CreatedById",
                table: "Exercises",
                column: "CreatedById",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainers_CreatedById",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CreatedById",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBE1N5Nh7YseY6u/zDwnBGmEfrOO5pJr+4Xy4rLugJp4u1/aIVE7aa5Oa6n/uS67Rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02e3a6a4-ba4d-478c-866e-be720ef50274", "AQAAAAIAAYagAAAAEKZDJekImafXpvHHoauR2VQt8y6P/TWjQFUszYU1ff4P/llRi+SArdL4cQ8unB2Ubg==", "cb764a9a-ce66-42d0-affb-c8da13a258d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838cc9b9-0517-48d8-ac0e-3576f3dcdc28", "AQAAAAIAAYagAAAAEMXxQVamrPSpWthwdPQeTrheZ/joEmpjqOOukmfFhekQrH0uTIcMxZWzHaUtI98QtA==", "11956b47-e50e-4b04-a738-d1eb75835c8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPkt99gy/mPVNChyt64gBAVBk65aKX/Q3xYjCHcgPBgbs4CJ1qM+q5DtSEujJ8GQzA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507dcf1a-2b22-4eb7-a0b7-c0b37d7bfe1e", "AQAAAAIAAYagAAAAEFHEZeddETx3XHMU3sYEPoAYRe10YGuA8uMwfkK+Tzu3pXF7gha/ZGvQsQo2aKssHA==", "3d10e5a6-413c-49c0-aa9d-d2c3da9537f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKFXhuR/H5fCfvCkzucIfQqYLQCL3JNnjxZQmX3ulrw5mXWVoqzjEcKOGNQTeuxpGw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM181BeDirLzz4aoDI7DByq+3fWQcBFUaWDngdDvizLc4id3Jjstr6ovI9V1Tn6ZSA==");
        }
    }
}
