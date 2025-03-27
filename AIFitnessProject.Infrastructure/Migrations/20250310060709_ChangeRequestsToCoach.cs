using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRequestsToCoach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RequestsToCoaches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF8RQYkNaDv4AINV1SOUxI64WP9Rdf5lOnyZiXRIgTEqm6vo+kWrG/RpQir0lSIm4w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "234baa83-4c85-4181-a3d2-412a2a5d4bfa", "AQAAAAIAAYagAAAAENLt22VXN0H7GB0h96iYauszUmLTpOdd0QnlQEfdEtLz2zZs4J6ikj/LUeZddVWchg==", "99e2431e-eb4b-4a5a-9927-d424e333c985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3f1d094-770c-4c29-886b-7a77c6b328b7", "AQAAAAIAAYagAAAAEHityKWSZvqLpocNEhPPv+dDYGLdwRFerVltPa9vuoCy5fQXT+7cMQ/yvLFT3TPR1A==", "2bf2673d-c788-4cdd-9f15-8dcce80c08ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI5gnQpKduA5fUnRWnQPrLwWYPp03DeLYQv7GTNtCWCDgfla1co9N6PLYsqAk4oPug==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fac0db6d-6051-4dd5-ae0b-3c0e6661dc69", "AQAAAAIAAYagAAAAEGliIHjX2Utu0y8SvGzt2J/phS3tNnKNRUQmajt70n8V0G3Re5fbzi0/esUpndkVsQ==", "97bf2c45-63db-4eb5-a749-842da1bed5b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO5cqXjOE99saszXXCDqVg/EaFzD+T/zlfgISFd+YHNc+YQOYDFtSSLgjOlxt5VBew==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKDaFkN1kYddCcXD5X0ravi4u27PJctz6IbDgHe/UWO7sftbJBzBvztJ+nyctz3ROA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "RequestsToCoaches");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBBUGzic2sLvFmNhIRxPeoDJtRJfc7TS9BEB9OU5i012GPxw1MEfZWduIUp+FSwQ+Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "185de985-6676-423a-9c5a-872f506c26ea", "AQAAAAIAAYagAAAAEL6muBYCqgLr2OocjvGQxENhgEm00UIqeh4EdVPoUudT5fz26JmVGp5Ev+JWKPtilQ==", "1faf5c48-ba1b-43c1-bbe4-fc65fd8a1958" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d1cbe0-3b89-4574-a0c0-c131ebaf1923", "AQAAAAIAAYagAAAAEBHklPDZ0zhqTJKU57FW2E3R2+EYyAq2Fx1PSg3DUo31WSGCZonLOwci3QYe5o0V3A==", "2dc17d6c-b0fc-45f1-b78b-48b42cc34f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEidhiqCcNYz2/eUY+RWpOWHOkMbbuV9tlA2m2EWXc6WE3sSMjZ2GzflKOvgOz8mOQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899cbf9c-2850-4905-854e-34cadcf6dbab", "AQAAAAIAAYagAAAAEFj1gdcl4kWjgg1mx2h6iBpPgsen0vZwObiOF70xjZl4EyU3+UZkX7MZlbzUXP1Vzw==", "7dde9c98-3c3e-4fac-98bf-8dde15201bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJOHFukm7sOscMLeIFtqCIcu+JdmkxL5fMPH6PLxbocECEqrkXDVP3xQSAE1TQxRGg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA3UOHJ+S+6KUzIPsrbtxEB3pX9tszfmUyIZCJFbwqSc1lDD7fikGg3EfsDZ9oCFRw==");
        }
    }
}
