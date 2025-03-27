using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNotificationNewColumnSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKV2dJDxv9FCsM4dIQIKXlLIkWZw4/iOPM5MKj63BeTfehd6SB8/C5LurBGf3QTpHA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca236a9-88df-4eb2-9c45-5bfd1ae8024c", "AQAAAAIAAYagAAAAEKAG8nBYoyzOq8pRc+zfBCmPwH1FPNstXOvSj2YKpewWcFJfpXxSBroS3ip4X4tVaA==", "992bb9e8-9860-4ed1-92b3-db3d2a6dba1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbac9fc-2017-4477-b26b-5455603581a8", "AQAAAAIAAYagAAAAEJnl/z5Nm99qflgTlpou02Ilkr/3068+oSzQlYftmGyqhgRGuWIGUSuCqtc76vyL7w==", "7094451d-4379-4758-aceb-52674b1b2769" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDEPbfDJIGHx95BPbJvit8TrDsSn327TQuPjfasJmUEB0/AOeV3C1Ne2AzR+96kO6g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452b061e-b8e8-4f10-a8a6-da9e8246fd6c", "AQAAAAIAAYagAAAAENttLhF0xdVeA1mj+VxO2zJAkGe55u34iiHSG9b55eJAtDmwCzzR1kaHl3y8CvPADA==", "6662c18c-c33a-4444-b45f-9a504aa04a0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAgxYcv+yG4hDltbKjph3Y6BFwOD593CO5Y92/ICNWK8cQlNBOvTlsCi8g1YiQGrgw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN4fXaUvxcvRJJv23WGjqIcN9t+BtnOlD/uY1YDW292N2EGmOpWL7JsCYxcU17M7wg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI0Czw1DThvc00cdo3lQwTLkCiTIpDHOudx50TyWKzQ+9vLYY2rbQ8G6RZS11HvwUw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a0c7fa7-fc31-421d-9796-ef4790e009f0", "AQAAAAIAAYagAAAAENNVlhnkoezCvpxhs7MRYXkZLkASq5KmaJNDAKWLnx9FlCjPTds0IQRTZzC7wwS9WQ==", "f006bee5-a37d-40dc-8110-969e88d1cc22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b8deb4b-c5ea-40d6-bf9e-f07564f2ac52", "AQAAAAIAAYagAAAAEJQYlTx3EsDeDcRJp4ui+uL/53k7tlA21sbKVWIzipLBezGSfdAe5KIXRC//r1QemQ==", "ca189242-fb59-4fa8-be6e-a881da531fa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH23T1rySq0k2ookd+meMFE3O9+zzP4FvBNBw8tJTD9PyGJLz3FmCypVRJ5V9pKtVA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2074562a-595e-4f48-8438-78db72f2dd1d", "AQAAAAIAAYagAAAAEMuUsrLZ2fSHgm9ux3Zvnpk92CYcSEIXG71bq8HLzWUvKerwBe+03dqP11WMVaI5dw==", "451e656d-9581-483f-afbe-e57f4b0a7859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEG21wwaXAe8WmF4I9quHV+KLH5Tj9jlLuKulV2+Jmhd/6QrHVCiyoQZQvZCY41cSFA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI/Ef/yIfbB/O/mAdXGl0nz/AA+0P9IIP5TkxJA69qnUZBBksXGeLSUebGzioYDw5w==");
        }
    }
}
