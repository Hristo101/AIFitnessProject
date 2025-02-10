using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovedMealTimePropertyInMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealTime",
                table: "DailyDietPlans");

            migrationBuilder.AddColumn<string>(
                name: "MealTime",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Daily Diet Plan MealTime");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFRMvOx0GtDg8chbwDN4eZuif0GrBKS3J0lMEbfS5Q2DFajzt2hltpD+OrZEgrj8/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84c29739-2496-49d5-96a1-85615225352e", "AQAAAAIAAYagAAAAEOtGhJ0mv7oXO2bbp9nDmPUiYN86MkYbg+5h68v4ULjwGub9oyTWHGwAkKDDm4lLBg==", "0300b2ad-a87d-4353-9b2c-433613070083" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "488bd4e1-95b6-4ac7-938f-67c605524919", "AQAAAAIAAYagAAAAEOypSmdWJE0pjgawvfOHht2C52V/eqW8E6NJaDCL3YrOn9TCdgZCIbKH4l4WSs/Cmg==", "e3386b9e-e750-4443-8d63-b1f220ed0a41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFGRthJGJooMr92X/H0RKkn2cj7uqqPwW7LplPZo/gcWSuRbbMXPyp4W67C4ADBxxg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0d9a0b5-d71a-4880-bd27-81b6aba71941", "AQAAAAIAAYagAAAAEIBfcfbnXJoPOOYVrUrxSEe0D9pNZLgJgUdjZq+wIvGZq1lNBlWhMotPluQkWMnc9w==", "183950f2-646d-4a76-8aa9-6f70e221b107" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEvR2BMWNTuZ7swh6XAojyuXzb0USHuGRZUV9NDuV7jOd3XI0j6H//jfnWW/xIPaew==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFDvVPLzLdeywgfwI6ga4/aQQjhIh2kLLyiTT3casS/UDsk5ECTD35Vc+eqwjoo4Fg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealTime",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "MealTime",
                table: "DailyDietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Daily Diet Plan MealTime");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIVibYLKQzWHj7S4uEKEjemvUq+zORHxO9iNbyvBXOkn7nhbo3B32zx7oP2rpuzcgg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3deb52-c177-4506-bb92-dff2f9c27547", "AQAAAAIAAYagAAAAEHZLjEAonGWN7frD+ThtBGS8+SY+DcbI1UK5iKAwW9Gv9cknyib+Lp5nVnIXRUUMhg==", "98a847f5-00c8-4fae-8623-6fba94d05e65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e4406fc-0cf0-4693-b7b6-0b501bdcf96a", "AQAAAAIAAYagAAAAEBsWIMz38qTvMXEN1Dvy58Lbb6MzuZ/H7tyB9RZw7TAqIndJaTwKbbaLkFzO4rrmqA==", "4e20cd1d-3960-4c03-aad9-f87dc8b6c990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGOHYPMdMDzN/suiIVu/ZiWcSCMDhA7W1xVkoKYVzxvxyTn2+FCJvCBEWqxZWZOLug==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9aaf97-ccf0-4003-88bc-282cdb0011e4", "AQAAAAIAAYagAAAAEI7sl2SC9ZiTEB4PmQnOy4U5fQg8fzoAYdIZ4GECWAAjzDv/q7Cxx5MCYxZIYE76lA==", "aaa84e4a-5173-454c-a690-6f368f21b984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECWUXWbA/VYgklqVrd0L1tfsuKmCCc1V8dm0TtskvfgQfoproHb0oBzJkhgtM5uFXw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMP412Im/yfrBjzmLZzN2P1RQKFsLjRNz4790S1/bZC0yz+pWi7wUD5nzso7hDb76Q==");
        }
    }
}
