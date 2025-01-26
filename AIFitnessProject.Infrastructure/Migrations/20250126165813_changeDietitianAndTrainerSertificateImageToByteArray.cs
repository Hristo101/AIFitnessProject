using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDietitianAndTrainerSertificateImageToByteArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dietitians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SertificationImage",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "SertificationImage",
                table: "Dietitians");

            migrationBuilder.AddColumn<byte[]>(
                name: "SertificateImage",
                table: "Trainers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "Trainer Sertification Image");

            migrationBuilder.AddColumn<byte[]>(
                name: "SertificateImage",
                table: "Dietitians",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "Dietitian Sertification Image");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKrATyoy1Y0xFSBYmaocLGG3eawxuZar7Gc/redwyGwF+fZnT9HNhc8msQKo2alvwg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1f59720-652f-4f10-9900-877c60e81604", "AQAAAAIAAYagAAAAEA+JEAeCEcUmcGWXX8aKlx8HqIkhY3W+6Pi/Y+te4Z0YCkV+9O2y7bvsxxBl7iWsyg==", "21f78911-5e52-4012-8c84-fe0398583de4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd351843-d0c7-4fb7-b0e8-1a74ded17f49", "AQAAAAIAAYagAAAAEEImtqxtBUNy+HBMb/PBEGvbAlOmjVwm0KSr4JMhtpkvccRz7fcmuMXYZ5oItxv58g==", "c03808be-61f4-4c1d-9dce-d4638ad17829" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOQ1KmyMC9XtKzpz8qS0s6sqwINhQ7clxCJTxUljunuZ/TV8GopQwPi9EmC5JioYCQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDtzPukuFZA3forv00kCkYAZpiC5/iv+ybbh4ZjaswhTnnbacypvTlCWt2NZi8SGcg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPG53U3GxN6wS6a40IRlqm9fDQKIhK9TNxgwCwPsI8b3plynWSJ/cVYGxpYuoRUz3Q==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SertificateImage",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "SertificateImage",
                table: "Dietitians");

            migrationBuilder.AddColumn<string>(
                name: "SertificationImage",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Trainer Sertification Image");

            migrationBuilder.AddColumn<string>(
                name: "SertificationImage",
                table: "Dietitians",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian Sertification Image");

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

            migrationBuilder.InsertData(
                table: "Dietitians",
                columns: new[] { "Id", "Bio", "Experience", "PhoneNumber", "SertificationDetails", "SertificationImage", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, "Росалина Узунова е опитен диетолог, специализирала в покачването на мускулна маса и оптимизация на физическата форма. Завършила е специалност \"Хранене и диетология\" и е работила с различни клиенти – от аматьори до професионални атлети. Тя вярва, че правилната диета е не по-малко важна от тренировките за постигането на желаните резултати и предлага персонализирани хранителни планове, които са насочени към оптимално усвояване на хранителни вещества и растеж на мускулите.", 8, "0886352233", "Здравейте, аз съм сертифициран специалист по покачване на мускулна маса. Специализирам в създаването на хранителни режими, които ще повишат вашата сила и мускулна маса. С правилното хранене и постоянство в тренировките, всяка капка усилие ще се превърне в здрава мускулна маса и нови постижения!", "https://cardinalbites.com/wp-content/uploads/2023/04/r1-600x782.jpg", "Покачване на мускулна маса", "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708" },
                    { 2, "Женя Желязкова е сертифициран диетолог със специализация в отслабването и изгарянето на мазнини, с над 4 години опит в трансформирането на тела и навици. Вярва, че всяко тяло е уникално и предлага персонализирани хранителни режими, съчетани с научно обосновани методи за дълготрайни резултати. Работи активно със спортисти и фитнес ентусиасти, помагайки им да постигнат оптимална форма и здраве. Постоянно се усъвършенства, следвайки последните тенденции в спортното хранене и метаболитната оптимизация. За нея здравословното хранене не е диета, а начин на живот.", 4, "0874856290", "Здравейте, аз съм сертифициран специалист по отслабване и изгаряне на мазнини. Специализирам в създаването на хранителни режими, които помагат за отслабване и изгаряне на мазнини. Заедно ще постигнем вашата мечтана визия и ще постигнем всички цели!", "https://healthy-lifestyle.bg/wp-content/uploads/2023/10/%D0%94%D0%B8%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3.png", "Отслабване и изгаряне на мазнини", "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Bio", "Experience", "PhoneNumber", "SertificationDetails", "SertificationImage", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, "Даниела Манева е фитнес треньор, който активно се занимава със спорт и фитнес от 3 години. Нейната специализация е в тренировките за издръжливост и функционален фитнес. Със силно желание да помогне на своите клиенти да постигнат максимална физическа издръжливост и да повишат спортната си подготовка, тя съчетава индивидуален подход с доказани методи за тренировки.\r\nДаниела вярва, че с упоритост и правилни тренировки, всеки може да постигне отлични резултати в здравето и физическата форма.", 5, "0895124157", "Здравейте, аз съм сертифициран специалист по издръжливост и функционален фитнес. Специализирам в създаването на тренировъчни програми, които ще повишат вашата издръжливост и функционална сила.", "https://dani-sport.eu/wp-content/uploads/2021/06/UDOSTOVERENIE_TRENER_R-688x500.jpg", "Издръжливост и функционален фитнес", "0e136956-3e82-4e00-8f60-b274cdf40833" },
                    { 2, "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация. В началото на своето фитнес пътуване той не е имал перфектно тяло, а напротив – борел се е с наднормено тегло и липса на мотивация. Със силна воля и постоянство, той успява да постигне значителни резултати и сега е не само преобразен физически, но и психически.\r\n\r\nДнес Светослав е сертифициран треньор с опит и страст за това, което прави. Неговата цел е да помага на хората да постигнат не само физическите си цели, но и да изградят здравословни навици, които да продължат през целия живот. Той вярва, че промяната е възможна за всеки, стига да има правилния подход и подкрепа.\r\n\r\n\r\n\r\n\r\n", 4, "0895124157", "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!", "https://fitnesstime.eu/wp-content/uploads/2018/11/fitness-licenz-nsa-min.png", "Изграждане на мускулна маса", "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" }
                });
        }
    }
}
