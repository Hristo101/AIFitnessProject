using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteImageUrlColumnInDietitianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dietitians");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP2GHO49ffYRAIEb2Bo1yI/lzCLmjcC+U4kbk6UxeooSsVUuPla2asGPVtyuoStE/g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e63e8fe5-079e-4c8f-8c35-5bb1a29baa74", "AQAAAAIAAYagAAAAEHHmpAhijowDb0Cr0a+rSgK1kg9nU82BY3qlb6HJab70o2BEhUFdd2/XYPpuAmWnNQ==", "18600f99-8dd5-4eac-addc-a37dff36ad2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3c2f9bd-8286-4a2a-b560-c0a2ca85c68a", "AQAAAAIAAYagAAAAEDqHUWDIaJ76HtqaOTUBaO/MYxR5Ro2LjBO8dXbk9vI9LN/3vhYYm4mRfQxTX8WcDA==", "ba438cdf-33a7-4fd3-b139-122acd434422" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH9+ICM8kJl4+qcEjXn+JZRDap845j/r9fpDZlVOKkPaa10s96hPaOdQMmglBNSGGA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOG4U8UwEi2pxW4eGA+lIzdqxulZBWLtxylTguRMkPdtdH6+9ty/heRQ6DTeLtZO3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGwhaY59J8tj2YHx7zvK92gNLI8Hukdun+heZeijYOYHa1To2bwLoK2UfKsZ/cnQcw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dietitians",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDujLjOQMZcYpuU2KhAxdF5eGM76qwH2LR2ooQrMwJE4nxMr0RgPoKzjgYz1f48cwQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31abde03-b5f0-460b-a62c-bc47df1a4daa", "AQAAAAIAAYagAAAAEDZHxmTgJHHI6GHpPYBxRYcgxrLHYAblqgkXl33TbvXKhKCScqiWYuWg2O3VEns/HQ==", "2b1a2c8f-0223-4948-ac76-bca4289773e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c2d1e3-e7da-46e7-ae6a-047a6a3e4b53", "AQAAAAIAAYagAAAAEPHYsmOCCdsRmEL16O/vrWGC75pSQbXqnO5HeKJOCZGqYelLNxVNPFSLV6kKRNW+nw==", "71bf8e69-95b6-4906-9996-89d609836c78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKNogl4NhwqDdg8KF6XGjUnBGmDyLd6q8snoDfEXmyiUVp7NwdUa/oJMIm5U1E4xkQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECHIw4DyTaV/rgC1FU8QNeiU4b7nm1TGE9LtJ4fMdcA1f6WiMqF0aXuZi/SdtQBoIw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDqLwqF5vM6hVpniZKVLIKRUi0OItevoPGC4eCXUVZCYeZn3WhxdpTsWHDl0we0p8w==");

            migrationBuilder.UpdateData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");
        }
    }
}
