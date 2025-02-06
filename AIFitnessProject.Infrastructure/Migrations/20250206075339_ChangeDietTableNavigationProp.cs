using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDietTableNavigationProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails");

            migrationBuilder.DropIndex(
                name: "IX_MealsDietDietails_DietId",
                table: "MealsDietDietails");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "MealsDietDietails");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "DietDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFv7UMGW8DUVQnAslOyuVMmK9fpMQWTZGvjdWnAAmad9LCl6vUmwmcHA+wSOQccz4g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a03dad0-f78e-40f4-a253-a63176ab9d93", "AQAAAAIAAYagAAAAEJ3Bj5hvPEW4cRWmoN7ixC46M6D2Xpapnlf7LvfMjlma/nhAGChVSeAaPjvLJ4w6/Q==", "d29de29f-04a7-4de0-b1fb-741107baab23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b35a63b4-8e07-4e53-a6aa-5db94fa8e5e0", "AQAAAAIAAYagAAAAEFHeoHdhbtHCXQ6518E3paPjGvlD6gpXl0P9GRDI2YCU5uIIfHUnSNGfUCKdNWkBmg==", "abc91bbe-d990-46ae-b176-e34d4dd2c246" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJQSaQ31N18HshBBBJ6pRrcMW/T++0adXn8uOBk5so8ALI0VBMSNR3KaJBeHAZ4jJw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da8c3433-a544-43fb-8098-94ef5946afef", "AQAAAAIAAYagAAAAEGDQVsz4KdfanaOj+Vi8xuHzXlyPMmGsqWjBmZ/dRCgLisdEdNlfqsk0P5qtVVSq2A==", "e79c621f-8af7-4c13-9eb9-e79c3f4517ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFAydFAnEvweCI+Wrh8RzATmMtnLQtsXmPlam8CfhrD6FvlwPabI+v5/7lUOVdKmfQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMS4a5se1KD/kd8ta15FtL3xI9RFE4iwWJTZfFC1DidOCdqoWcK0KFywndjJW6sdCw==");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietDetails_Diets_DietId",
                table: "DietDetails",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietDetails_Diets_DietId",
                table: "DietDetails");

            migrationBuilder.DropIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "DietDetails");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "MealsDietDietails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO8ny8Vsad+1+1or0XUMeu7yGBcm9tNQTxkwVcDQDFltNdRP1xsNQw4RUfc20HXYlQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "890ec9c0-3dd9-42fd-a267-32e147cbce28", "AQAAAAIAAYagAAAAEBOO+9miiQjXGD+fL9J3wKcW67eGsHqtHu1pgjZHes2kTo3Pex0i/lStQdt/oz6PoQ==", "3a91d2f3-1ce4-4e8a-99ae-9f646cba776e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f19eeb30-631b-49b7-8bd0-4d9209c16522", "AQAAAAIAAYagAAAAEMM8bDe5E9Vc6Q8qG4bUCDz8mzf3v0bxFS6f0Y8Cxewh+R2H8UFYkBYGG5YU/l+8yw==", "e9e4b51e-12f8-4cfa-bac0-94b0159b674e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBZePoovseTkriTX6c6t+wP4QxFvUOn/HAqe47siTpzmIG15FLEgUQA7PCjUIv667g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eaecbb1-5abc-4e10-aded-8423d0aea1a3", "AQAAAAIAAYagAAAAEO+byBEyzYiwL/1UU8LeXzR+2Sdczk0jMlW6iIEubptt1mNkCBClA3z8SA3SJ56ncw==", "d30abbf4-ed9b-40d6-b274-29fcb0e722a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJShhGOfHc/UZ8wFsBX/eKk2nmT/ARscfX8qwVoicfmro/Z1ymA5e+biWPJX7DTewQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKZyC4OoelluhCdR2/6zp12T2YdpGPB8xRbqvIH53sHfUjFMLNcD5buYPexWhxH9Jg==");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_DietId",
                table: "MealsDietDietails",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }
    }
}
