using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                columns: new[] { "Aim", "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Целта ми е да отслабна.С това надмормено тегло много се затруднявам и искам да стана поне 110 килограма,защото въобще не харесвам своята визия.", "Начинаещ", 195.0, "AQAAAAIAAYagAAAAEKXPHgyKQ4sXe9pm6FE5L4V9dJlVzVuWdNvr9wtbJFBH/6CcJalKkODYFDLFvSCOfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "ExperienceLevel", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e239336-1ba4-4be3-bea8-0753ccf27df3", "Напреднал", 168.0, "AQAAAAIAAYagAAAAEHT+HeIUG/lb1b7M2K9hGPCz70Q4s16oLOREWKt1Aq0TZwNNz3Tas13spPKW0X8Iwg==", "764ea7cf-774a-44f3-8dd7-18e8133ea056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "ExperienceLevel", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b18c24e-9708-4b7a-8a91-ef6f456fa404", "Напреднал", 170.0, "AQAAAAIAAYagAAAAELXeNEGXfygW5YwiSM8ztDQHCMqfdf3cOaQBRk/ABnrJCHFSlxb4anSJWxDtrLUKFQ==", "e1c5a571-f0be-4187-bc1e-da83ee524a3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                columns: new[] { "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Напреднал", 170.0, "AQAAAAIAAYagAAAAEFDRS4m76rJzNkbLXQ0NRAU4/aHoUsUf4OmjphUvSh6GZ7KORtKQvjL1PxsWG9MCpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fcdb134-cd79-407c-a32a-8379e2add0bc", 187.0, "AQAAAAIAAYagAAAAELXyXCg8u2NaKo2g3x7Ek6cqRnl6rmvOoPfq3YjK5SXfnYb0LoFrJumeHeVbUbk3fA==", "4e3203f0-cbb9-4ec6-a3cb-82ddcf19ae12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                columns: new[] { "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Напреднал", 203.0, "AQAAAAIAAYagAAAAEKNrNB3AlHu6wDJv9uar1b0rkLU4Dqyv2kfgq9YbSWkWzpAh7/g5Oc8gfqGC59kXVA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                columns: new[] { "Aim", "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Искам да покача своята мускулна маса.Целта ми е да стана около 95 килограма,но да кача само мускулна маса.", "Начинаещ", 203.0, "AQAAAAIAAYagAAAAEJXfKD/KbXK7aqSYeDoqmXxwhrcOpLyTeFNJiETcQAOF+P1Ndz4pEeqxKZfbihqdwg==" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://training.fit/wp-content/uploads/2020/02/liegestuetze.png");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Вертикален скрипец с тесен хват");

            migrationBuilder.UpdateData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                columns: new[] { "Aim", "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "", "Начинаещ,почти не съм влизал в зала да спортувам.Изглеждам ужасно и искам да отслабна!", 1.95, "AQAAAAIAAYagAAAAEPqmDS9FELiJPWELIvmDDLpih3DJUdulDy8CveeEUOuX9JAocrhEAS6607nTfw29tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "ExperienceLevel", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83ae84b2-eb5e-479a-9d09-f5dc6cfb0804", "Женя Желязкова е диетолог с дългогодишен опит, която се стреми да помогне на хората да водят здравословен начин на живот и да се чувстват уверени в своята визия. Тя създава индивидуални диетични програми, които водят до трайни резултати и по-добро самочувствие.", 1.6799999999999999, "AQAAAAIAAYagAAAAENDNfkk4t1WHlOOSea/0zUwo/b1OhU1QFEL3VqzJrQO5gJEvuyo0s3RxeuibWeaR/A==", "74822419-65ea-4e94-802a-3b1ec4800d8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "ExperienceLevel", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c378360-08ab-4b4e-a435-89492f0a44bb", "Росалина Узунова е диетолог с дългогодишен опит, чиято цел е да помогне на хората да постигнат здравословен начин на живот и да обикнат своята визия. Тя създава персонализирани диетични планове, които водят до дълготрайни резултати и увереност в тялото.", 1.7, "AQAAAAIAAYagAAAAEBWddmt+em0UuCauZfTVu5MC0GLz6CvBYTkBA3r7hrKYNj0KshUDLJ28PUCt8NiK9g==", "27e7c069-5338-46de-92a2-ab229c8fc661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                columns: new[] { "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост", 1.7, "AQAAAAIAAYagAAAAEFlA4tURdKUvYIFZwQIg4tq9+omqDo2Yy3DNA9FooWEUmpGls5/cba7azrkfat6t/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "Height", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39dfbb9b-5390-41b8-aae7-488ff6a0cf69", 1.8700000000000001, "AQAAAAIAAYagAAAAEEtGtAblnBQA1nSwyOgNyvwUMhCCh4PHa8YFitg47VbbW0o483odGQl8d08wNQo7GA==", "9a45323d-32b4-4aff-bd23-dfcc0326a61a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                columns: new[] { "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "Активно спортуващ,занимавал съм се с фитнес от 10 години,целта ми е да направя всички трениращи в това приложение да харесват своята визия", 2.0299999999999998, "AQAAAAIAAYagAAAAECoy/0YEh2/+DD9b+8yZOt6SgoDnfNQrYrVyWUFqMbkj31dAj8x2KxE2cT277rgXPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                columns: new[] { "Aim", "ExperienceLevel", "Height", "PasswordHash" },
                values: new object[] { "", "Имам някакъв малък опит с фитнес залите целта ми е да стана 100 кила,но килограмите,които кача да бъдат мускулна маса", 2.0299999999999998, "AQAAAAIAAYagAAAAEFlmulAG3DJpthDo/y1tdx28liEW3Aea8dxVyDymKTfgR97d+BnEyyheJJIEPKaaMA==" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/images/pushups.jpg");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Горен скрипец с широк хват");

            migrationBuilder.UpdateData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg");
        }
    }
}
