using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedDocumentsTableInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: false,
                comment: "Trainer Bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(3500)",
                oldMaxLength: 3500,
                oldComment: "Trainer Bio");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Document Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Document User identifier"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Document User Position"),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false, comment: "Document Is Accept")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Document Table");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHakbUjY+/a1G2fv2s5p3DQNtBaJSJe3+wu9ERAkfHJXpkbRGFiBAhGFsbb7X4A3CQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50a19b2a-70ea-4606-950d-0bbaadc3db8a", "AQAAAAIAAYagAAAAEH11hNongUrlM1BSHf2NU5Y8tiX5LPZddWCthGCAxHvLurK8t7wJQQzDPiAPv7ZORA==", "2e2c8851-ac0c-40ef-a88d-c44fbef44dbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76c5d75c-5079-48c4-9dc2-65ce04417b6a", "AQAAAAIAAYagAAAAELwCGMZDnNDBMZvOgNaJs+b9sE7/vT9b4Z43WXrhkJK02GlNMhMAdAfx/B3LjlVHBg==", "5fcc6de8-9aa5-4408-93cc-278a0ea7fa76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHYDyNwzF35sBf0I70QhXFf65OmygFnStQE5dOa9/tDCnKBfVZG/jSk4URMOyKxeFw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECskWHdYIwFPLPHvIoBilSkyGE7/1Xd43d8b1ndRQSsTgw2bxqFSm4K9MBXwjEFrZQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENCib6vBjCHEvk7IcDKJSWZKS7IA6lBMfAiBOH80VVkOrXhDNlKlEPm/hpUGNAIp7w==");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(3500)",
                maxLength: 3500,
                nullable: false,
                comment: "Trainer Bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4500,
                oldComment: "Trainer Bio");

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
    }
}
