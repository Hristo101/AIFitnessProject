using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateANewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false, comment: "User Opinion Content"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Opinion Sender Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_SenderId",
                table: "Opinions",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinions");

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
        }
    }
}
