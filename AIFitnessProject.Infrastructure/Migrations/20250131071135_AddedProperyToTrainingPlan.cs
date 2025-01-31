using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProperyToTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TrainingPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGu0w4g1LDVMkKf34mqjStbO8x9d/lnBgpzFxBwa/QBjh4MP+yeUAMhSJrmYoxwZGg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e865fc41-aae0-471d-9b16-2ad6d5cd93b8", "AQAAAAIAAYagAAAAEHCanGP/JnWu1x4dfY0gFwLWsY02zFIXULCkikgfe/cYPeHXmSsOcWxSbAowTev5ww==", "6c69a6c4-6188-42d5-b695-c0418000b29b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c07ec1df-d41a-4320-be2e-6beae4fdeed1", "AQAAAAIAAYagAAAAECjSxamoONDQNM0tWH9WUG+APOU4/pzajmGydZn/IWCa60Mdpxh6qFqGQePAM/sQjA==", "baecbdb3-0e8b-44eb-a815-14e1680b770e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIFZElTjS+Ul+rf/7IxKzh8cnLd2dPt/D0fTXUnIygI3hqZQTqOAyMqmYHQmcXq3wQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6a3ae9-0f1e-406c-9bf9-a55b561064f7", "AQAAAAIAAYagAAAAECimxsNXLxuSbWTDU5rP6XwHoAk6rh/d8okbDjfJRQ9ztJ6hoy3sCPbngZWtO7P/NA==", "447a5baf-9d28-4b9b-bb17-83a86730e657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHxqNU8buyXwYzAq3I8jMpBzQm6LM3hH19MvGKne08qlrn3Hg+6YtW0h5HokuB4zlw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOMtt4inNFYPcuJmaPAviiYT3X7180e1FKWrMeXHbpuxEpxviGGWPcKFMNOm7WuZHQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TrainingPlan");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECXUkySsbOGpdM/wtUEgtrJMlwiELSXnYYPdgeVubKOgE1u8ieomWLLXy5eIWr2Gmw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb0a68b5-1d40-4464-9773-7c1504c995fe", "AQAAAAIAAYagAAAAEEdoTY8cwmqpCvsBZMIVJ2N2KZ5Gjr7lXyMU1SFHRe4iz/a5ygE5DOxduc036YPfdg==", "a16cadc8-ba2b-4bb1-89ea-d2deae6fa7c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3b9624e-acc7-4fac-946d-93cf27281d5e", "AQAAAAIAAYagAAAAEAd9TK4duDNZ8aTN6CEJI10kIUJIluigQ1yk6kqpWbPwhZkjBmicHQOHkCf91XhO+w==", "01eb230b-7533-4137-8c7a-8fa4e078a838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKvgasPKVVgUXPyrYr/1iRzMxeHiRKdEoUmUn3eiooyiAodHuV38wzkI1h6sZ0YwkA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3906521-0535-41b4-8c8a-0e483ce12bf7", "AQAAAAIAAYagAAAAEE2zitJX3jSo+Tzwr8m1CvwvZ50uL/3eOevSOYGhPj+YKR+UGQNOEfAtZQICYNCRAg==", "72d51d9f-5183-447d-a88b-bf3b64b8257e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIB4MMGMSkUEoVOIQp1NHce1f2mfgjCMfKcHgkn058tWJIxYgsuAyXH0QNN/tYNTGA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDRtAvHCJn5oYrRFj2S4qYdGGi3QdAJgTVR0tLjrROVd8YFshdeia72dln52t2qdSQ==");
        }
    }
}
