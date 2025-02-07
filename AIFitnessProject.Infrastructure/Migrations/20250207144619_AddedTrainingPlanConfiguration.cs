using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainingPlanConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH0vqckloulTZGTUMxCqDVW7UrIfAjrmg21Hc+R64FuQLozM7BY/HoAdDk7XvEdFjw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af9db9d-3f4b-4d14-8679-dfadbf3e43c6", "AQAAAAIAAYagAAAAEHaSNL6WOOixxD2/CbETTU3LXexk5JwnbRv+bV8Lfvmt3PHnUN1aw9slkgEqHCoB6A==", "aeb26cb4-fa29-4a7e-b721-d5a832657093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c47c73d-709c-4db4-9a7e-e6da26583ef2", "AQAAAAIAAYagAAAAEPCcmit0eff6jPR4gW/V0INBFmVzkoI1PG5j832nXaTfa52mt9364EeILBhTpWm5Uw==", "defcd5ef-af83-4b12-8dcc-6a796e863349" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJINcOaAZp6wRdpkOIxwi/E8Idt2mYKBbZXo9u5a5Niby6fEjnmYO0RsgtDIg0sseA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edd78b23-a65f-4260-8342-ae3ae804819d", "AQAAAAIAAYagAAAAEF9DZohmtiXp2m4tpKA/Ylj7zP+j7WLBk1kdejS8J0klqIb3VJgh3OvnhPm3uUpwqA==", "3b3dbb9c-56e5-49dd-8dcc-5c69df8555db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEK5BiipjZ51jCFg5KcTonKNiL5hKQ3IiqAHRy63y3792/dnmZ8biHhXaHXvs5dFolA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENzZRHdVEjjTBxldzXF5MAceykSGe8untFjW1GvFTUk2nhVvv3iEJF1+SlyeX/HsjQ==");

            migrationBuilder.InsertData(
                table: "TrainingPlan",
                columns: new[] { "Id", "CreatedById", "Description", "ImageUrl", "IsActive", "Name", "UserId" },
                values: new object[] { 1, 2, "Тренировъчният план за покачване на мускулна маса ще ти помогне да стимулираш растежа на мускулите чрез прогресивно натоварване и правилна техника. Когато увеличаваш тежестта или повторенията постепенно, мускулите ти ще бъдат предизвикани да се адаптират и да растат по-големи и по-силни. Силовите тренировки не само увеличават обема на мускулите, но и подобряват силата, което ти дава възможност да работиш с по-големи тежести и да продължаваш да напредваш. Това ще оптимизира метаболизма ти и ще подобри цялостната ти физическа форма, като същевременно ще увеличи способността ти да изгаряш мазнини, дори когато не тренираш активно. Ключово е да комбинираш тези тренировки с подходящо хранене и възстановяване, за да постигнеш максимални резултати в покачването на мускулната маса.", "~img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg", false, "План за покачване на мускулна маса", "cd87d0e2-4047-473e-924a-3e10406c5583" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPlan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB1nVjxTD47TURya47uMrLENDEPf7uEQWG9UNusg0yzihGvAP1MbKasWPePDv1wZHA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aee1d58d-18b3-4d8d-945b-9ca32a38ffd6", "AQAAAAIAAYagAAAAECC43Q2N7q2fJ1dKlhe8+V5febPzD6pW4Cy9VDrwb2PwuudKoa+1vkiP6y8Lh4BRdg==", "c5ad3a4a-c5a6-4aa2-bf76-166984c3f39d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c714ffe6-2b28-439a-bb29-123513cbcf08", "AQAAAAIAAYagAAAAEFbRawXhiz3nXvJEF6mXFH5t9VH7fl5AthS/KkrwDlHXGW5b/nrQHmYIzaD2O2HX4g==", "a2efca8b-2a2e-4b34-890f-aae673fc4dae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEGw2hKV8EC4G5rs+vMuvOmT/WZabGTFmjLlkgF1c46NFa/rggEzWUnV2vJNreoFjw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d5bdd46-f30f-426e-8dac-7d67735001ff", "AQAAAAIAAYagAAAAEB53xe22/RY8vRaXmW/dc7ZF0jnKCtbn+rAZb1JfAsOcTmjXpEbJjMRmyNzzW2bWfg==", "e08aa5d6-627d-4bb4-adaf-503ef6316b82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHviwjVzP0HzeGfz09S7x/mCEnTIAuDGp56d1AuXhsSGx0oX2xj0iyzKp4UE1woBgw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHPO40y5vpZoa/WKWbwJYtKdvSjOiSRRJGZ1g0ndtB+NnbYFDej506FJRWO22fQVNQ==");
        }
    }
}
