using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Diet Image Url");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPIgdhMF2auuGAbuLX12wPF0MeA2oHnkC3eUaCVV0u5tCjLKtfy0WezvjeYfFskpxw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe799749-f898-4c45-86ec-8a5fd5014cb7", "AQAAAAIAAYagAAAAECtO2CqZIazijIlaTsgAfX8hkUXnBDle/Z9X1vXedDJ+KGvnjNp+0jmcrltPoFWwUw==", "bba93f4b-fab4-4724-b1b7-c5da1d250fd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0c8dec0-766d-4fa4-8810-b86bc6d67d77", "AQAAAAIAAYagAAAAENHQnImzBlGI0pyRhpGZq1YU6zYbAE1+TSJHmJc0wz9Yj2Emtb5OwCASkZ/Px+feZA==", "5a505559-e3ab-4a59-89ac-8c1c5911eb1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELuWl4bU0jhKFo3G8ySSQLxaCpRdE9X8q0d0tC1t3yEAo6iSto4afTuJ6u9jj++OfQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "709ffada-158d-43b5-b070-710bf8818282", "AQAAAAIAAYagAAAAEL1qpT5LDgfTEQEB8+sFUbW5U+VpkC68nu/WP9z+4CPh/dGjYdkDkbkNDS/Kosos9Q==", "601c2329-a8f5-4e94-b9f6-281a50c39eaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKl7GlCeEczvTaF8mP6JJl1iqrZRLbCA6ufYiOZRbu9fGSE3KddpeXlypQBEYuK2Wg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA1qba/RjHxnvEkEnq80caPvpksAQjgR0T5tsvS1Xp4xX+nDN15bSjLmMvxZHv8cYA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Diets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGu0w4g1LDVMkKf34mqjStbO8x9d/lnBgpzFxBwa/QBjh4MP+yeUAMhSJrmYoxwZGg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e865fc41-aae0-471d-9b16-2ad6d5cd93b8", "AQAAAAIAAYagAAAAEHCanGP/JnWu1x4dfY0gFwLWsY02zFIXULCkikgfe/cYPeHXmSsOcWxSbAowTev5ww==", "6c69a6c4-6188-42d5-b695-c0418000b29b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c07ec1df-d41a-4320-be2e-6beae4fdeed1", "AQAAAAIAAYagAAAAECjSxamoONDQNM0tWH9WUG+APOU4/pzajmGydZn/IWCa60Mdpxh6qFqGQePAM/sQjA==", "baecbdb3-0e8b-44eb-a815-14e1680b770e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIFZElTjS+Ul+rf/7IxKzh8cnLd2dPt/D0fTXUnIygI3hqZQTqOAyMqmYHQmcXq3wQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6a3ae9-0f1e-406c-9bf9-a55b561064f7", "AQAAAAIAAYagAAAAECimxsNXLxuSbWTDU5rP6XwHoAk6rh/d8okbDjfJRQ9ztJ6hoy3sCPbngZWtO7P/NA==", "447a5baf-9d28-4b9b-bb17-83a86730e657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHxqNU8buyXwYzAq3I8jMpBzQm6LM3hH19MvGKne08qlrn3Hg+6YtW0h5HokuB4zlw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOMtt4inNFYPcuJmaPAviiYT3X7180e1FKWrMeXHbpuxEpxviGGWPcKFMNOm7WuZHQ==");
        }
    }
}
