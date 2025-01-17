using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageForTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIaX0o1CC4uryFeywER5KTvS7kvVMJLfLeGmGIyvoR/PsjVzp9+pRxYG+XfihxV5Ww==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "791bda0d-3588-4cc3-8355-cd593930cca9", "AQAAAAIAAYagAAAAEIF7g3fbJiXz8hC7bCxVxaSJjNPcSr2qfqhxCIwg75/p6q27+P+Qj99R6UHQTIc8Ew==", "693672ed-505a-4cfc-91e8-38764a00a152" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0307a75-e3ab-48d5-8f16-e1db31aef8e8", "AQAAAAIAAYagAAAAEFI1AdlddTITFkSAx8hmDpNtYPg1VhDkUztsOKfl3pWTbsMuAmENc5IlmtCzpVAX3Q==", "7e1c395c-e4e4-4492-8f81-639a68fc5e9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGQ2uWty0TRf8os/xjGzvRXEcMjQ86o8FHtcsW5FK0Fj5I7gHkhFLrM+Mt+xSAf2Fw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPdGEtaj1CvE3XnziGoAFHEzPBl+gOsx8S85Sub8I7pgd5RNU5Bmzk1GywrcdQT3lw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKRefWgAl/fHzG8vFev1KUILHwsi7swocjipr0U/P0KAZu2fcvbfYnADTnjExmYYCw==");

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://momichetata.com/media/1/2024/01/18/117000/original.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJDx6iGLNfLzGFoup5znS9M+pcvwx5bcQVwtpdxMsMwR25DHtrwd2OndY5BENHQclg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27956fea-0ef6-4a90-866d-c3d1020d9526", "AQAAAAIAAYagAAAAENOk2V8wLIxuS+ETbw0ps6sHCmA3TSTmS1vWblKqtQchzFN74HWFUmOtnpml8MnCeQ==", "c76fbd83-aa75-4d3a-b63d-c607ce974605" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dafec03f-a147-46ec-b317-e9dfa2e4bbf4", "AQAAAAIAAYagAAAAEALHNLEkGjBD7kLaXCPgoOlpVwusefmnkQ+fDA6Teayevybd2umgdNKAX+nSngbsmA==", "854dee6b-a37b-4051-8310-5f1012b7feab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO4+y3cEPuXsPX18O+jqHMfTL7x/EQORsUcmZqQjfpOvnWH53emGd7mADYWOt4tXqA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH7pdWym6xm8z7F/Uglxd2xZQTvCAuBb0WD31mNvoNd2/XQ+SiXg6NmeBaHu87NyAQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKbt32yAV/NPrZQKAU+2fpXbZEtTozBRonYGUK+osdnNfjDLHCcbJ7tlgtpyuTvs8g==");

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://pulsefit.bg/uploads/cache/N/public/uploads/media-manager/app-modules-trainers-models-trainer/305/6874/novo.png");
        }
    }
}
