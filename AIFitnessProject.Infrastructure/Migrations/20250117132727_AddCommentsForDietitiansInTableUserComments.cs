using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsForDietitiansInTableUserComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGEvudGNruREAF9cO4hcLW7p9V0F2M71XbETuNebUNS9V6EslFNLX65knkcZJ96GpA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a3b8f68-be5e-4398-9c55-fb0323cda6a4", "AQAAAAIAAYagAAAAEHgkkG3k1hytn9/D+pDegljdLkf2eTTtInCATLbFpxJymcvtEeEvCG2xXZee+ydP6g==", "7f7ea4ba-2ddf-496a-83e3-67ae972478e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "844161f1-0ed1-4dc1-9abd-7520565c353c", "AQAAAAIAAYagAAAAEAcIpjb4hIH+8k5eoyzZihSMga0fEEMAlumaE9VUvakpcLwNirU+3n7vmsQthdsZ9g==", "26a9c21c-e687-4848-bf86-a883925f1455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAJoyPczJnlN4Xl6RxcAtpBrbTNkpYtpqZ2gnJBaDBaffwklzGsNhZlR3CzD+ope2A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP1ORGyXndy+0iNG86rWXouqDhFIXOKm/EpzAKcebueI9jQ5zN1nQyyxxeIAmNxvJw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPgtcvEiBMC/gTxgPaVLTJmsgYOzcnSETGZp2ActYhTFNj3x9rfWJXSsaIO46mffDg==");

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "Content", "Rating", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 3, "Страхотна диетоложка - хранителният ми режим никога не е бил по-вкусен и ефективен.", 5, "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8", "0a2830ef-8be3-4ef6-910b-33b680d659d3" },
                    { 4, "Експерт в покачването на мускулна маса!Диетата,която изготви,е ефективна и лесна за спазване.", 5, "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708", "cd87d0e2-4047-473e-924a-3e10406c5583" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
