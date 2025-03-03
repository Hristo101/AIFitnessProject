using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCalendarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Calendars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPqmDS9FELiJPWELIvmDDLpih3DJUdulDy8CveeEUOuX9JAocrhEAS6607nTfw29tg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83ae84b2-eb5e-479a-9d09-f5dc6cfb0804", "AQAAAAIAAYagAAAAENDNfkk4t1WHlOOSea/0zUwo/b1OhU1QFEL3VqzJrQO5gJEvuyo0s3RxeuibWeaR/A==", "74822419-65ea-4e94-802a-3b1ec4800d8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c378360-08ab-4b4e-a435-89492f0a44bb", "AQAAAAIAAYagAAAAEBWddmt+em0UuCauZfTVu5MC0GLz6CvBYTkBA3r7hrKYNj0KshUDLJ28PUCt8NiK9g==", "27e7c069-5338-46de-92a2-ab229c8fc661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFlA4tURdKUvYIFZwQIg4tq9+omqDo2Yy3DNA9FooWEUmpGls5/cba7azrkfat6t/g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39dfbb9b-5390-41b8-aae7-488ff6a0cf69", "AQAAAAIAAYagAAAAEEtGtAblnBQA1nSwyOgNyvwUMhCCh4PHa8YFitg47VbbW0o483odGQl8d08wNQo7GA==", "9a45323d-32b4-4aff-bd23-dfcc0326a61a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECoy/0YEh2/+DD9b+8yZOt6SgoDnfNQrYrVyWUFqMbkj31dAj8x2KxE2cT277rgXPA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFlmulAG3DJpthDo/y1tdx28liEW3Aea8dxVyDymKTfgR97d+BnEyyheJJIEPKaaMA==");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Calendars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Trainers_TrainerId",
                table: "Calendars",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
