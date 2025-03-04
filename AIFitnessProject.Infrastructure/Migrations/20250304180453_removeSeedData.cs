using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietDailyDietPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DietDailyDietPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMp+thEIjy7jOYmn9VQKUwGSy7BmUPHcmMZEl7pNT5oDRv/r5KTYG1/l1VeiA5/06w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a76f7998-f479-40ac-a86a-06885e2084e4", "AQAAAAIAAYagAAAAEIo5Ie8+Y8cRf4nG7rV0jxf+8yxxaeh+M4SWL0bF/SNwSbgXGMu3m6zQW5gQhq+RxA==", "a54d203f-b947-46eb-9c9f-70add57b8a56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8d70685-5e6f-4973-a5c5-32f98ecaddab", "AQAAAAIAAYagAAAAENAUTeSmd8AnHjOBx5VsLLR6KFL1gD5oUgqbavb08yNMZPB4TDw/6rvuN7CblCpN8Q==", "31b558e8-190d-4588-a790-b1d3e924e714" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPJoRC7X3rV0smB8FgQ6/j2CJb4k2vHAH6ZiCHj0OrV/5UIoivfSCahleBXhx5iePQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef423e3c-a26e-40b5-a76b-6949b027de30", "AQAAAAIAAYagAAAAENe1WT6IRJSXggO5gh/MWrHG+Q473+2NSCbzy/J9a+/RJ6uPSp05P+ZUQoXQa7TiUw==", "e8142af4-5b50-44f2-8931-74484ee37176" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHGVKdM+1sCAdAIToNy65k7CgOD9U3lpBHGMSZqkUY4zDOXb7iw/CokjXM6x0jWtIA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBzOTDJ1dTt2VYebwxRyQEq6QX4pniBo7BrHFNjKVn8xXinv6CJQioA6tVflC6Lp4g==");

            migrationBuilder.UpdateData(
                table: "RequestToDietitians",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAnswered",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIODMc+rVYt62ZGgs2Ve1RU/ARgz7uRVUgcozHFSLTUJff/FOmxMrFRJcm05A5HsSA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "061c149c-0d20-4eda-9558-28fc7f8f46b5", "AQAAAAIAAYagAAAAEMnVYZtv/UCgvQnlFE5dd6kCNNYWNjml4MYM8sOulHqTionjS1FpDowjCNwwSaAWtg==", "a28a3ea0-24aa-42fa-809a-cd3a20fe479a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98e7c93f-5145-49f6-93d9-e4876e7a408b", "AQAAAAIAAYagAAAAEKqIxGl0+SPNue/tixoxBetE9VASMka/4LldtEaFA/XVvLh8CXebjFWFKdRfY7bHLw==", "1fff5368-1b72-4f2c-bcc8-36442b229fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHCr+YCcc64/6ZJTjq/h1fEVZ9Yg6IPyKS0tq5tXkO2+ux5QxxX9xquW5ZN78adz/A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4ac93a4-eb76-4e35-9046-49fe725a3158", "AQAAAAIAAYagAAAAEGgFZE2dBGxn6CICeqXqQkHu1i8NCoL9CamZOpzBk3fGAOddJ8qqGOm5v/0ZuTL7CA==", "76cc6333-21e6-4351-8839-6a18b69b2524" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL6Kjrw23N6uPmmmt/W3hAySgLtYEBSe7uReT5+SuCJhc6p49UP5SdDS0UeH5F2oxQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIA8YXTRqNKaHEfENcOOrdBFJe18zsFc3lpKXSyTZQ2eA8Yw0vFz9bfJrIWwVEzr8g==");

            migrationBuilder.InsertData(
                table: "DietDailyDietPlans",
                columns: new[] { "Id", "DailyDietPlanId", "DietId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "RequestToDietitians",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAnswered",
                value: false);
        }
    }
}
