using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMealsDietDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealsDietDietails_DietDetails_DietDetailId",
                table: "MealsDietDietails");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails");

            migrationBuilder.DropIndex(
                name: "IX_MealsDietDietails_DietDetailId",
                table: "MealsDietDietails");

            migrationBuilder.DropColumn(
                name: "DietDetailId",
                table: "MealsDietDietails");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "MealsDietDietails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DietDetailsId",
                table: "MealsDietDietails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_MealsDietDietails_DietDetailsId",
                table: "MealsDietDietails",
                column: "DietDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsDietDietails_DietDetails_DietDetailsId",
                table: "MealsDietDietails",
                column: "DietDetailsId",
                principalTable: "DietDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealsDietDietails_DietDetails_DietDetailsId",
                table: "MealsDietDietails");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails");

            migrationBuilder.DropIndex(
                name: "IX_MealsDietDietails_DietDetailsId",
                table: "MealsDietDietails");

            migrationBuilder.DropColumn(
                name: "DietDetailsId",
                table: "MealsDietDietails");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "MealsDietDietails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietDetailId",
                table: "MealsDietDietails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEcpA5icvbY9w0T5lp5u+kCsd7hxpZr6bggVho/t7F4g6HLpZotDYpA3qmHz3cv+IQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "054a63dd-fdd3-4fd1-95bf-f4848b04ce49", "AQAAAAIAAYagAAAAEFkNferNnnFJZ/lxLZRubHqJC0Dc31OTeuYchjC0SSkihpKLXPpZki3Lo4uWX9tD4A==", "41a150f7-bc84-4e1c-890d-6608e2a1cb37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c546f22c-0ddc-48f9-83d7-8b97ab49456a", "AQAAAAIAAYagAAAAEM4IpfL8EQDpAU0dAmbXGz6wVe5BLy7gHrPzCWvk0p96QbTfpCqF3jUPseTLdq/ZIg==", "2f63ef50-e91b-47ce-87e1-bc381b89bfe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOv1+pwKehtmbDiKzhMvsD7BBktPXUP8Qb+RdxS8JGZla3zTomXuzbt095h20NNuIw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c988e7ff-662e-45cd-b240-5c8b8d56be3a", "AQAAAAIAAYagAAAAEAVSAilzATF7EQVkuQvERHcb8TOmYzV88fejop+dpTv2YgvsEOeM97fJWtcHN4sZlg==", "ef9bf7b3-031d-48df-a355-6d248897d3a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGjuHOVqHSwGs/z9nD1I2PrWBDLVOM21OlokK1tuSW8VlJbvxN0F5nV7SGOzzNbgdA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI8/iht7VoUHApoGaMMHIaHkkJ9kj3FGbVexv1z2wLJ9ngHqcJK2/Tgeg3IKIvevXQ==");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDietDietails_DietDetailId",
                table: "MealsDietDietails",
                column: "DietDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsDietDietails_DietDetails_DietDetailId",
                table: "MealsDietDietails",
                column: "DietDetailId",
                principalTable: "DietDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsDietDietails_Diets_DietId",
                table: "MealsDietDietails",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
