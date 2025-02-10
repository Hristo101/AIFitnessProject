using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPfcS6qR655t7k0pYEQD+n873eYjz2pb2ZrpDeim7NOhyNaBm2n/pgJjpgWTrNABtQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d08d80-6547-4343-bb4e-c536662dcdcd", "AQAAAAIAAYagAAAAEGj5CNRMIKTkU7rXZo0mVYRxNLk7uRnvIt3aQf8eUG5I6Su2K0SsR/Ks/w4j2bFWiw==", "e0458d80-0cc6-4bc5-88c0-b5070eda60f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c540985-4993-4a07-8c96-f7b027153f3d", "AQAAAAIAAYagAAAAEMOWvGOlLJ5CMyN2t8AdK4B9Vtr7UUTxFXt3V/CVh0CvmTqNKxvZKB6UlSHnJfIIIw==", "1e3fad96-5e0d-402d-95fe-df0dc4ee1f3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOfRHefajUplryPLsRfxnCiFsAJgpYPhpKil8To9x2QqEogYT3bGhDpGDeD3a4etvw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4e27b2-149e-463d-94db-ed8c413f80aa", "AQAAAAIAAYagAAAAEOZ5IEE9vqYO3Uw70iNAuKCTap4/GbUUvOEXq32uf6JmnQGlhqAnC8fJPgQ8Pgedrg==", "e445bc99-bc77-496c-9888-bae36bb48c02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL+Koko4/WIy4FGotWCNzfR92aY1Sh0RHs9omk+HriJdQ0C+YrwLZOvsqobMoFPa3A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN0LtbSLYAkRk+57VjmOCZGWz+RAoH4tJR8w0sTUS1puJLXX/FsLEZz6CU+QRT9oFA==");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "DificultyLevel", "ImageUrl", "MealTime", "Name", "Recipe", "VideoUrl" },
                values: new object[,]
                {
                    { 2, 550, "Средно", "https://static.dir.bg/uploads/images/2024/09/20/2807112/1920x1080.jpg?_=1726837485", "Обяд", "Пилешко филе с ориз и зеленчуци", "Съставки: 150 г пилешко филе, 100 г кафяв ориз, 200 г зеленчуци (зеле, моркови) и две филийки хляб. \r\n Инструкции за приготвяне:Пилешко филе: Подправи 150 г пилешко с сол, пипер и подправки по избор. Загрей тиган с малко зехтин и го готви 6-7 минути от всяка страна, докато стане златисто.\r\n Кафяв ориз: Изплакни 100 г ориз и го готви в 200 мл вода около 30 минути на среден огън, докато поеме водата.\r\n Зеленчуци: Нарежи 200 г зеле и моркови. Задуши ги на пара или ги кипни за 5-7 минути.\r\n Хляб: Запечи 2 филийки пълнозърнест хляб.\r\n Сглобяване: Подреди пилешкото, ориза, зеленчуците и хляба в чиния.", "https://youtube.com/shorts/GevngVUx-i4?si=SU5C1eU9e4iU2_qt" },
                    { 3, 460, "Средно", "https://ofertini.com/imgdata/400/riba-sharan-chaushan-som-plocha-garnitura-151750.jpg", "Вечеря", "Риба с гарнитура картофена салата", "Съставки: 150 г риба(Ципура), 200 г картофена салата, 1филийка пълнозърнест хляб, лимонов сок и сол на вкус, 1ч.л зехтин. \r\n Инструкции за приготвяне: Загрей фурната на 180°C,почисти рибата, направи 2-3 разреза върху кожата и я натрий със сол,полей със зехтин и лимонов сок.постави я в тавичка, покрита с хартия за печене, и печи 25-30 минути.След това свари 200 г картофи и ги овкуси.Поднеси ги заедно в чиния и полей малко лимонов сок за свежест. ", "https://youtu.be/2JWygq1mjeY?si=QCMfyANQfgh-AyvF" }
                });

            migrationBuilder.InsertData(
                table: "MealsDailyDietPlans",
                columns: new[] { "Id", "DailyDietPlansId", "MealId" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 3, 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealsDailyDietPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
