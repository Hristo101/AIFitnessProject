using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedOpinions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP7twYbD73L1tvMYvBNEZtu/Irwgx2BfqaK06ZPUe6NGhDIeyjBiTrCLM1XdqRylBA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d24ac6c6-b750-4280-a556-f8911fc905d9", "AQAAAAIAAYagAAAAECa5kfpC399ybPM9Zg/r+bq+YYSSIF1/ki/Ynnecw1wCdIMsCRtI79CdmY/QBTG7Sg==", "71a67f19-fe3f-4b4c-b6d2-3cb01afd5ec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "158f6189-4683-4b56-a35f-27652f1a82f0", "AQAAAAIAAYagAAAAEJHEu6pnH8nXNjZgueHlq50koP7jHiOSwHMbFHjbCZp4eSZNuDg4MxeDrv8hpn+YnA==", "cd0cd8b6-1c0f-4ec8-80a2-cf080506db53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIpexVp+g5ChxXkCUr86ISikpOgz4e20bdaJ7A+fW53fZ7fzblWYp87wI0Ws3KUCkQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBPNWOeLUtn/B282arHwdNWfjI7EKjGOIceb5MOW3HY5unwF6IaKpdmI3JUinGTvsA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECcA6ozTYEU1yLlVrSBuwB3TO1uicImnG5ypE4J58e2xFQqL+GDtE42RFgyzftzfOQ==");

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id", "Content", "Rating", "SenderId" },
                values: new object[,]
                {
                    { 1, "Работя с тази компания от няколко месеца и съм изключително доволен от подкрепата и ресурсите, които ми предоставят. Приложението е мощно и интуитивно, което ми позволява да предоставям персонализирани тренировъчни планове на моите клиенти и да следя техния напредък в реално време. Също така, екипът осигурява отлични условия за професионално развитие и редовно ни мотивират да постигаме още по-добри резултати. Заплащането е конкурентно и редовно, като винаги се чувствам оценен за усилията, които влагам в работата си. Гордея се, че съм част от този екип и се надявам да продължим да растем заедно.", 5, "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" },
                    { 2, "Работя с тази компания от около половин година и съм изключително благодарна за възможността да бъда част от екипа. Приложението е изключително удобно и лесно за използване, като ми дава възможност да създавам и персонализирам тренировъчни планове за моите клиенти. Отношението на компанията към нас, като треньори, е безупречно – получавам постоянно обучение и подкрепа, което ми помага да бъда още по-добра в това, което правя. Заплащането е справедливо и винаги се чувствам оценена за труда си. Най-хубавото е, че работя с екип, който има ясна визия и ценности, които съвпадат с моите. Препоръчвам горещо тази компания за всички, които искат да се развиват в професията си и да се чувстват част от нещо голямо.", 5, "0e136956-3e82-4e00-8f60-b274cdf40833" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECyF1mmDyUfQmc3isKmPlQ9fOXo10+2wp9RxnX8WsTG0yb2OwA/njTuQHpzJZVboEw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5646ba3-b598-46be-af2f-14a982f416ca", "AQAAAAIAAYagAAAAEF2N+uCRPH0K/JQUWkgb1gLVmKh4ewVsCCgvENhHn+rL2Bw0R9JoqHWNzxx/ShY7IA==", "4a93d8fc-489e-4675-8c84-87b1f4918b4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3633cdb7-4ec3-42e7-b0f0-be3f123b1e6c", "AQAAAAIAAYagAAAAEMfqQ+vULoDc1RASQBugb8WUiVbVJRmRe5QqDmI9YmL4iozE9ev9UztZE7G5PP59hg==", "0a671033-959a-4110-ae75-b54dd8baa2ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFnmYbhSFu4TPWebf82WQPKvJpxonn9yYPX3xh0QCBt7cAnN8O5PBDsoGDAjGJMOfg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECaXPhcT98iN2NpS+gEmwIgErvx837Tjg++CXz+9Z2EQ7I0O7hhYO6jeCmeMZ6Ze3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH3BJ7BkxC6T0okuNT78ai9Kc+/n0Mr+pB0lwr3qs2U3urg27OzbisZ1rmMH9ofzHw==");
        }
    }
}
