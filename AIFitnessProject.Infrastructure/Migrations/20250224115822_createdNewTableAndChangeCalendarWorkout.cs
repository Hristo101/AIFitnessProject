using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createdNewTableAndChangeCalendarWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEJ+sY5gH4cdCsZrnuoaiaiqjpO7jLn5G01XXme7iIeSndvCq/NqsArIwNhmT7Iefg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e67bf3-7e56-40c9-8228-cae37d7c0c1b", "AQAAAAIAAYagAAAAEGzZxjSFurKHhbaHZY7kUSzmXsHWJUAZ2DSu5MW9/qGKiHyTl2jz1ZPi8q6dmiVtBw==", "c9866cd1-558f-4452-9b93-d942f21b575e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b664b52b-7c60-42a3-8bb5-48b584952754", "AQAAAAIAAYagAAAAEJi6IUEymjFJbSoIVO6gR0Zg4riBnfYX7fOc0sdVT0iHg1TNAG/nomwW+AUK/9LJxw==", "4597b12a-95ee-4651-8511-dde943447a34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDHGNP1r2XsfLEfqlcmGUK2YtqWxNpLbF3yUR9AUnt/dBdBPqg/TRdCjt2tO10j+Uw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae8b58cb-b492-4673-93b3-3e59f7094242", "AQAAAAIAAYagAAAAEMYl5/gy2yuQ3IYYPCzihfSopyoYWZ4ILX9CiEHziHzK3OPLCuu+vExRumCeYYXDAQ==", "8279b7ef-9fa4-4910-b2fb-be9dbcf356eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFaKvXemyLv0tc63W0Mu77bDVrUMxQQMhA48hvgvSRwdHkGlyM435xdxWgQJ5F5ywg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGHvQDYE8HEsAbIBF89Iu+yiT2axphh5fGAG9ZBdLjWtLBDxtHNvc2c/zS3UFvD4Sg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJ6gpmTFHvcKKm3W9QP9IAAfL4lL3IVfav0aNFFa3CXGwWhqyg6xerFWExiuHFLwug==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea95f94d-4b82-49bc-9c9b-e02ba512ee99", "AQAAAAIAAYagAAAAEJhihTCfPc0M/yUo0Qk43sw6hkM/rL5e1gK60yi6Zy/7irnfBvRfe1wU7GyaOmDtyQ==", "f3d5c48c-d0ac-4338-85d5-e3acef9adafb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07ebec71-c43a-4fb1-af90-016571316b40", "AQAAAAIAAYagAAAAEE4lmuVF5fIKfH7NJh545dDuAXo27BU/HPtfrA58k0+WgKKjF2lwXkaGNCIpCJtpkw==", "6340a619-8897-4a01-955c-38ce6b6d7e0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL1P1bZ2ndGQNtkAlgGF4gMHEYyXA2scxsZfZf5CSPQI/qEINAu2D02AJ1Lx5Vg2xA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8fdcc6e-ecc4-4c90-93ea-312336e9a8ec", "AQAAAAIAAYagAAAAEHwwZrZ+lrLZ41eyqjDIq84PXH/Ywi07z3taaTgPh6pRJIlPNbk4BjbLeJQp0Hy6rA==", "7c2c3bd7-4e1b-4b94-8cd5-e6929cee5ba8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELjYP+Iaq9ghb8EdAieeKo38pizAhfXtJQqaexEu10x5XS5ik+ILF2pEIG+4/r51Fw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMhy//a1saN75963cnetQlIJ6LqUukcfeZzd6/ParyW5qzPh7Y8o8ipM9Hj0aD611Q==");
        }
    }
}
