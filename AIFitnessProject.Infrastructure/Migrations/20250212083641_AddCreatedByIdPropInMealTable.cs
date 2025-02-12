using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdPropInMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Meal Creator Identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFic5C7BOOarY3wbvIF6nxKx+NDJqTq07/pOuYZFriZW9shdQ9uFX/E6XDzyy0rRFw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80ae5e7-ca4b-46f9-bdb9-05dfcc036b0f", "AQAAAAIAAYagAAAAECaTjRD8GDHCG32tmfrXbgNVxmsJyTz8TTXE/cJdD+2y1fcVt2/+/RZe7m3XS4+WWQ==", "e84c8a77-e08b-46cd-a9d8-93585eaaf468" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8a82b30-b3d9-44b0-9dab-c2e1e828c489", "AQAAAAIAAYagAAAAEPBVOYSh7bZ6QqP1RTsmq9bo4qBAcvfiKz2icqRHTcFsL3zYTH9lYnu3yDZJSbPNvg==", "2b5f789b-7305-47f0-b4a7-a6728ea24c4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPCxkOjtV1gXsbHsPbwoI2qSqzvEETuFaO0vYIsTW/vPDcfGzu/3KmLD5rHEwMGA3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4c9bd74-e352-46f3-a13d-678fb79fb2a9", "AQAAAAIAAYagAAAAEBkdEx1P1hNudxQRps6R1lBGTDoKiCQguWDmszEAnIglBxIPeIdfTWUzQbRd1zDJWA==", "0803c220-3ecc-4761-96df-d7caa7f38b37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELE3AkNRZm+Bq+/W/XgsloURbiV8FG12E4U3ehYErmM4oSiKSfY1NJ05lOR1YKEX7A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOai0MmNn5jOZCdQo2qE3+iNTRLRg52L6Z5KeigWhUHjmHkptjvza4wJl7D9LTbyYA==");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedById",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedById",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CreatedById",
                table: "Meals",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Dietitians_CreatedById",
                table: "Meals",
                column: "CreatedById",
                principalTable: "Dietitians",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Dietitians_CreatedById",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CreatedById",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIRqEZZ93CoqXKp1ypVi4uBy5Vm4/VY+H2pk7a6T2y3SCJAlh9wkj05iuitEGhyoUA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0207b940-cd76-4bfa-af00-eb358fc7fcb5", "AQAAAAIAAYagAAAAEBe91Jdp+9dSWVq/k9NoOA2QkMMPp4mnYBvYyh6okwNaQHklkXd1YYrVGt4wKWapBw==", "a4d03d60-12d9-4b68-a2d5-ccc4ba134357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "068e5a6c-de17-4431-8c2d-098c19c2634e", "AQAAAAIAAYagAAAAECtsxqlQotdgrbYih1l2Y8uSd+x8bNtK94n45LhW7hlpuZ8rjlCoWBEgJFODS46FFQ==", "0d915e60-9890-466e-9fed-c4f975f76fc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELvQbJP/oTFdu5IyWpoDoDK0VQctcWIOhRNIB/y+o7+OjaceZtl7Eab6zFR6MXh+1A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f692ad1-e375-4ded-a3f7-486772122e31", "AQAAAAIAAYagAAAAELh6tmpI/RVM+cyvTtAZS8qu9UuhorWOskWpAHsmt8oVq+HfM9d3fe1L1+IH+LmIYw==", "89cb8012-b215-4034-a241-7afa69b662ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPjNNJt3CCegUux/oxRDNky2OsJNM5LRKcuhJV1Fn1LL05FB9VXcN5bPqnWNTZKc7w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECvFvG52wvOcPenRHbTEMfim2/0IXTa66whIXNNp7HqOlYbWZEquQneszJSf1tzn+A==");
        }
    }
}
