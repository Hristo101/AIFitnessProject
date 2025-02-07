using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInMealAndMealDailyDietPlanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFswzhoVplM16Ge6eqrVNTBkgN7EbWPTWqdhIutxkrq9a59lre0I9GlOOjEsQRkfEA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9466d93b-5dd7-4bc5-837c-600201aa849d", "AQAAAAIAAYagAAAAEMu8xQrMnRT65Ci3RlfknTis/ZKQOugW2yr4wG7b7Uyvp2fG2mMXdAoNTPVi9KSs8g==", "fc99d0ee-dee9-460f-9ec0-5afa117da52f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26dccb71-dda6-410b-97c2-cbf49f4565fc", "AQAAAAIAAYagAAAAEMsJsegH7xsQ/TFdoJMqH3Y6RNA1vSdww3j7Q2W1qThjWftd/ThbV+e7Ptbnj3Z0DA==", "9c0ec919-83a3-4e2a-82b0-7d235d218b9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECPNXJ0mUT/q1tkgSKEbCDgqNrEfAlTqoskUuJoOQmfgCPDoLim81nyfnlEPSNleVg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe06ea9c-96de-40e8-b990-8f26afe03f49", "AQAAAAIAAYagAAAAEBZLgHZNORoqK6rvC+Nj1BjXZrRn9PQncQAM7JdMTz8L7GeYMu1EiODKo4BYjsLc3w==", "cd239a0d-ced3-49b3-ab2c-4bcabdf196ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDnsC8syruxNpPkG4TjXupoG1qvFA72EBOi+bAdJhbkZLVPdP7mqqLnXrzWy2uR0Jg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA9tnpjY6vWgTD97DAyN+Cy+hmQ0V2RGAnK8tkKVSXyNMXnxTOBPAfi4QADIxgLiBQ==");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "DificultyLevel", "ImageUrl", "MealTime", "Name", "Recipe", "VideoUrl" },
                values: new object[] { 1, 400, "Лесно", "https://inthebeniskitchen.com/wp-content/uploads/2020/08/img_20200806_130537.jpg", "Закуска", "Пържени яйца с гарнитура домати", "Съставки:4 яйца, 1 домат ,2 филийки пълнозърнест хляб ,1 ч.л. зехтин, сол и пипер на вкус ,листенца пресен босилек (по желание)\r\n Инструкции за приготвяне:Загрейте малко масло или зехтин в тиган на средна температура.Разбийте 4 яйца и ги изпържете, като добавите малко сол и пипер по вкус.След това измийте доматите и ги нарежете.Накрая добавете 2 филийки пълнозърнест хляб.", "https://youtube.com/shorts/f_dzcO3PsjI?si=C1qR4_cE7Yjtb7Eg" });

            migrationBuilder.InsertData(
                table: "MealsDailyDietPlans",
                columns: new[] { "Id", "DailyDietPlansId", "MealId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBAsTvhkkedrr8aF28oQTQr80HEhdPTF+hu5+kEf10H8/kAIl/lFdQNONceP0qiYOg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aada79db-e2f5-4e9d-aef9-873ebb98b388", "AQAAAAIAAYagAAAAEMOJH6rLjHQnKv3MHYKAXx8XCkVaXLKV9lYONJwO+JrnbB9T6ZAUf7mj1aMeeXgvXA==", "e152a6d0-1bc3-4a71-b87e-140499576ce7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "247994d4-86d1-4484-b33a-94a89348fb97", "AQAAAAIAAYagAAAAEHq44x9eFV/7dChXYyzSiBbRsShieQtzKqgppXmrr42UHNZAMGNL/MT7cQRWDu+qVA==", "d92d6a21-d7e5-4962-8201-3be3f9ecb654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEzH3LLyzawLVjfamDrT2Xk2umx11ra07PmEAIuFrPmtIWeZLFc2NwC/PUCM80r1cQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "133fdc1d-0cec-410f-bb3b-aa21a72e2233", "AQAAAAIAAYagAAAAEMlX880i77chHIieAAPZ2d02S/EhiVYYksBpA/9IFY6dGp0faYTooIIuKx/NMPupNA==", "8ebcac42-4f29-467d-a0a1-d81180835be0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOuknV/M+4k0ryvmWI6+uF3StO3KVI+/UqkBvn5pHc0V1RSGbd1xO/S1gxCjQEzNpQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEC/mClinqMxueiO56XV8O9oSifsUBPqMIWzgaPnirb+l6T/AMQS0cpsw7Ws4BUK3Rg==");
        }
    }
}
