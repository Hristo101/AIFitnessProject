using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEdit",
                table: "Diets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInCalendar",
                table: "Diets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKNVIyhquXWaSCxj5xmPRAWqzGUeVCfRuka3ETKG0Fei1mgIak4kGU73uN/GCSxsfg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75a4fe9d-0b95-4bbb-8dec-02f0ba5b826a", "AQAAAAIAAYagAAAAEFNU0WamcUVbP+dEOR/VL6eP02hjvr+W3VqNfwuA4jXKwxm0ph5EuFYfPUL/ET32ZQ==", "76d031cb-8f69-4ea1-9dbc-c65630768d4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8906ab53-6e1b-4771-9fbd-807a32826bc9", "AQAAAAIAAYagAAAAEBkMxGRrrfnKZDcPzkazeu4mErBUusH87fy4vsH0hyfNCFH5CKISepphGODcteDHew==", "b893ed92-78b6-4a5d-9e87-217011ba5897" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJ94gqFRboTL4ElAxjWU3fZZ94jNp+5AtoIfY6jORpXI0AgiTEeeAkwzdFHEoR5c7Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5119f1a7-f0b5-415b-abcd-0abcc9c5a4a8", "AQAAAAIAAYagAAAAEPCMRP391lnHV82KlXryZlX0LNrR6HmI1PzJTfxDweEgAKISRzmpQdTQO8eeSqdHHA==", "8925b306-3091-4a14-b576-c157695e9ae2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECRbFVlOGNORAQRufPmIRjA+u5l/LfGfQjtP4Ha1TuiHwP5pJMhs1F2eKcizHfiGuQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAany/e39w+Vl2aV16ILy9bCANL4NsMIcZvihSu5dU7I94G9Tm10SpcqgRlrDkNhiQ==");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsEdit", "IsInCalendar" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEdit",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "IsInCalendar",
                table: "Diets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPv7OCRxKrBRhEvFqdYE/7gqXX9Ks9eKgR6xI6d9UYU4F+2a21peOsL61hlrH4+PBg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b294c6d3-1fb1-40ab-8188-62bd8ee63bda", "AQAAAAIAAYagAAAAECCcfzUz1RWjsKW6KthrvNG42z2W/HOXYE8rKEP8TZdJ78Nk3rx3XI58Ajzid4/XnA==", "c0493c08-6e3a-4837-ad30-1545d61c0d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59cb9121-dbf3-4184-97fe-59fef136440b", "AQAAAAIAAYagAAAAECTg0KoE0S32lfn7h2VFge4R06Mc6uykrxwzYS0gIW8s+fm1Jwwrj5YbbjdmsKp5sw==", "e66b6189-3a73-40f7-ba62-6658d324f438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMMSMU1UElP+7nNE4wg/GKxamFuNGTWCyk3AY639zFxnQVViq+r7HswVejtU/3/peQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b36f37dd-b44c-48ce-b7bf-88095052ec0a", "AQAAAAIAAYagAAAAEAtvNO/rd20LeEmmowx0fYgSUH3rvxjX/skKfGtoio7YrCCUt256dnUtywsigaPI7g==", "89bdd483-2854-4b59-8d02-87e4fad1d3a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHf0ZLdPhqYbXjHD5vc3EXIOwTUvT2abwcK3ILa+sr1atfHE1iASg6j5KU+OAz1Sdw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGe5EvK6A6s4w9Gm2w1P5E5nXqZ4ZHGydI05u6aQ0cG249su8XRenpeUBAijchPSOA==");
        }
    }
}
