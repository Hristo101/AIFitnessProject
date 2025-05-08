using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailForSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'pierceabv245@gmail.com', NormalizedEmail = 'PIERCEABV245@GMAIL.COM', UserName = 'stanislav', NormalizedUserName = 'STANISLAV' WHERE Id = '0a2830ef-8be3-4ef6-910b-33b680d659d3';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'pmgclaude.team06@gmail.com', NormalizedEmail = 'PMGCLAUDE.TEAM06@GMAIL.COM', UserName = 'daniela', NormalizedUserName = 'DANIELA' WHERE Id = '0e136956-3e82-4e00-8f60-b274cdf40833';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'jordanmilchev87@gmail.com', NormalizedEmail = 'JORDANMILCHEV87@GMAIL.COM', UserName = 'pesho', NormalizedUserName = 'PESHO' WHERE Id = 'cd87d0e2-4047-473e-924a-3e10406c5583';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'pierceabv980@gmail.com', NormalizedEmail = 'PIERCEABV980@GMAIL.COM', UserName = 'svetoslav', NormalizedUserName = 'SVETOSLAV' WHERE Id = '70280028-a1a0-4b5e-89d8-b4e65cbae8d8';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'jd6125416@gmail.com', NormalizedEmail = 'JD6125416@GMAIL.COM', UserName = 'rosalina', NormalizedUserName = 'ROSALINA' WHERE Id = '0e0e4964-6fa8-43ef-b6ba-a8722a1d5708';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'm.smith.online@gmail.com', NormalizedEmail = 'M.SMITH.ONLINE@GMAIL.COM', UserName = 'zhenya', NormalizedUserName = 'ZHENYA' WHERE Id = '0c4c8519-6a0a-45a5-acc2-64c0de9af4a8';");
            migrationBuilder.Sql("UPDATE AspNetUsers SET Email = 'hserev789@gmail.com', NormalizedEmail = 'HSEREV789@GMAIL.COM', UserName = 'Terry26', NormalizedUserName = 'TERRY26' WHERE Id = '5df58ef6-da85-4d1d-a429-001e0856de72';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
