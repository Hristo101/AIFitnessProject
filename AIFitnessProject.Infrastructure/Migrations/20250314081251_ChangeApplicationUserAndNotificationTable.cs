using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeApplicationUserAndNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Trainers_TrainerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TrainerId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_SenderId");

            migrationBuilder.AddColumn<string>(
                name: "RecieverId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Notification Trainer Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI0Czw1DThvc00cdo3lQwTLkCiTIpDHOudx50TyWKzQ+9vLYY2rbQ8G6RZS11HvwUw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a0c7fa7-fc31-421d-9796-ef4790e009f0", "AQAAAAIAAYagAAAAENNVlhnkoezCvpxhs7MRYXkZLkASq5KmaJNDAKWLnx9FlCjPTds0IQRTZzC7wwS9WQ==", "f006bee5-a37d-40dc-8110-969e88d1cc22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b8deb4b-c5ea-40d6-bf9e-f07564f2ac52", "AQAAAAIAAYagAAAAEJQYlTx3EsDeDcRJp4ui+uL/53k7tlA21sbKVWIzipLBezGSfdAe5KIXRC//r1QemQ==", "ca189242-fb59-4fa8-be6e-a881da531fa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH23T1rySq0k2ookd+meMFE3O9+zzP4FvBNBw8tJTD9PyGJLz3FmCypVRJ5V9pKtVA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2074562a-595e-4f48-8438-78db72f2dd1d", "AQAAAAIAAYagAAAAEMuUsrLZ2fSHgm9ux3Zvnpk92CYcSEIXG71bq8HLzWUvKerwBe+03dqP11WMVaI5dw==", "451e656d-9581-483f-afbe-e57f4b0a7859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEG21wwaXAe8WmF4I9quHV+KLH5Tj9jlLuKulV2+Jmhd/6QrHVCiyoQZQvZCY41cSFA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI/Ef/yIfbB/O/mAdXGl0nz/AA+0P9IIP5TkxJA69qnUZBBksXGeLSUebGzioYDw5w==");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecieverId",
                table: "Notifications",
                column: "RecieverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_RecieverId",
                table: "Notifications",
                column: "RecieverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_RecieverId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_RecieverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Notification Trainer Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TrainerId",
                table: "Notifications",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Trainers_TrainerId",
                table: "Notifications",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
