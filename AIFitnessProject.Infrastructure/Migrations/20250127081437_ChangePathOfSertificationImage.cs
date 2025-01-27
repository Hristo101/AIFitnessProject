using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePathOfSertificationImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO2RlpKHitnXlejQ7uOfP+xkzm6V8IBzqxr2w4jFkfNFFfufWcIClEEnUaObrpxZtg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "018b2285-65fe-4d00-9983-13a430dd7e8a", "AQAAAAIAAYagAAAAEB8pC/OYcJ72eN/wr9sbhBF4+Z+HZv8MlqtHzM6SUaLIMKDcyiy9+4+T4qZOcfOA1g==", "52320ad6-ce6d-456b-aa17-d0bf2987a33c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff4420c-f4a3-465f-8828-d9c4b53b9aed", "AQAAAAIAAYagAAAAEFD1csgDIb+2u45EJlgHlsOI6qzSw3EEc0HxxM11sOnC27iFhg0uypo+CKMNMRWFCQ==", "55bc1f86-10c1-41f5-b6f6-07518a7ef39a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECATbF/F+Poy6Mhz79yBkJh9vYe0mg+twjsGlS5Szlt0EkR0TGk0yEMM1GCBdgFBRA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEq/9Gev1Ns3V9NPi5jxJZLL2lpoDuRmcuRHhf2HJBm/QFf+bCA/zQVOJtHwPb+lHw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAKp006HVbI3y+TSWxPOF4m0odFVwuPPbPkKbYY+5tWM8493MqQCpOJeKOO5F1xvKw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKXYv+uyOCIwefwNW7Ow646UsSapB1r+qRJOPDh+kgWw0AliaPwmZWmEnav37aMWhA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08d9a8e9-680a-4c53-8015-a33c7fe61b93", "AQAAAAIAAYagAAAAEIkuN7O41Uk3nSHqFoFXskRzbVi0bh9CrdlIgpfDxDn0Xh0NHi/G+Yvb2TWaNS+K8g==", "d3b403df-890c-44cf-a52b-54a724614efc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0837f2a9-bfeb-4ee8-90b8-facf79cd86fc", "AQAAAAIAAYagAAAAEKOKcGkWEDrhD2D27WxUBTuMWCU60isrFEW/y0cCTOk5UiRqch6FRT9lfHggjixHbg==", "a4bd06f9-97df-441a-8809-5b54db4183ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGjxBBxPXkurlibAMNQd8TBySGXVTMcpuktpD2KTvJ1AGZZ43xAmSS5LMobwy8G9Rw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENCoM/WGsWbcoF8iwhc7y2be7Qo2nG/YVoIW5hniv4hY4BMmEC2L1AmaEB759Loiiw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEbfkOEeLaAiqfXWaNsO4uHFAK7xgAyP4IHSsT8mPYsUbQm2s9pm3q/zigjjkyfPMA==");
        }
    }
}
