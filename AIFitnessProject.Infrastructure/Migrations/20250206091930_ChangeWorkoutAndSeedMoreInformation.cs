using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkoutAndSeedMoreInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: true,
                comment: "Workout Training Plan Id",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Workout Training Plan Id");

            migrationBuilder.AddColumn<string>(
                name: "DificultyLevel",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroup",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Series",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAVI0Po5ciGeeTM43GFPrJrRaPbrLo7N1X1WwIzH12hSRAwCsayPvsnX4ilGR6FnFg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2ebaf6-bb1b-42f9-8d65-126b6f28fdc5", "AQAAAAIAAYagAAAAEEpXl7YCaBLXzp76Mj2eJNrNVR4tRJxL520I8b8b/R+GKh20lvSzKANrj8+dy60z7Q==", "8afd5f13-17a8-41eb-8465-25afcad46e77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51056973-ecda-4506-ad83-ade323d55ad2", "AQAAAAIAAYagAAAAENZ+bHXcqukGADSciHb0CBSExI9P46YPcZ03TvA0LDF7Aq0tqszmDbKBFKFQpE8pjg==", "59dd3f57-8360-4b9e-8553-ce4bed4f496a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECyZrPDRvDm4hd3pFHmr1uZhFXVyPL0JGQYA8nZe1cPu6aL/0DtwE5Fuvfw8twU50A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e871db4b-8edd-48d1-b99e-484030e33fa5", "AQAAAAIAAYagAAAAEEsAWJmXA4SABgd8cotdJJ2dzzeKCBOrp5ZHaXlztKbZtAs/dIQKE0YJQlXYsBSlYw==", "c16d7ee8-b6ac-4a92-bcea-9717c6426c79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBLjDXS101WYWyCbvWeJPlTV0tY7cPlVrBA5US/MCdnOlO34o6khGSavePy49jECZQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELvwmRkU2n59m3SzVJWapAXf5edFEHtG9mRfMRqx+olZYKtAW1Jlt8IImFJ5qqNBoQ==");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 8, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 8, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 12, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Repetitions", "Series" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "DifficultyLevel", "ImageUrl", "MuscleGroup", "Name", "Repetitions", "Series", "VideoUrl" },
                values: new object[,]
                {
                    { 9, "Римската тяга основно натоварва задното бедро (хамстринги), седалищните мускули (глутеуси) и еректорите на гръбначния стълб. Второстепенно участват прасците, трапецът и предмишниците.", "Трудно", "https://4fitness.bg/blog/Files/Images/exercises/rimska-tqga.jpg", "Крака", "Римска тяга с лост", 12, 4, "https://www.youtube.com/watch?v=9MfK_wio48o" },
                    { 10, "Нападите с дъмбели основно натоварват квадрицепсите, седалищните мускули и задното бедро. Второстепенно участват прасците, коремните мускули и стабилизаторите на тялото.", "Трудно", "https://fitnesdieta.com/images/uprajneniya/napadi-dumbbell.webp", "Крака", "Напади с дъмбели", 10, 3, "https://www.youtube.com/watch?v=5VnSY1HG3gE" },
                    { 11, "Клекът с щанга основно натоварва квадрицепсите, седалищните мускули и задното бедро. Второстепенно участват еректорите на гръбначния стълб, прасците, коремните мускули и аддукторите.", "Средно", "https://www.mybodycreator.com/content/files/2023/05/26/159_M.png", "Крака", "Клек с щанга", 12, 4, "https://www.youtube.com/watch?v=LhwTU5VQVc4" },
                    { 12, "Предният клек основно натоварва квадрицепсите, седалищните мускули и задното бедро. Той също така активно включва ядрени мускули като коремните мускули и еректорите на гръбначния стълб, тъй като те стабилизират тялото. Поради позицията на щангата, натоварването върху коленете и горната част на бедрата е по-голямо в сравнение с традиционния клек.", "Средно", "https://www.mybodycreator.com/content/files/2023/05/25/181_M.png", "Крака", "Преден клек", 10, 3, "https://www.youtube.com/watch?v=AMezBp0JPOs" },
                    { 13, "Лег пресата основно натоварва квадрицепсите, седалищните мускули и задното бедро. Второстепенно се включват прасците и аддукторите. Позицията на краката на платформата може да променя акцента върху различните мускулни групи, като по-широкото разположение на краката натоварва повече вътрешната част на бедрата.", "Лесно", "https://static.vecteezy.com/ti/vetor-gratis/p1/15708604-homem-fazendo-exercicio-de-leg-press-na-maquina-ilustracaoial-plana-isolada-no-fundo-branco-vetor.jpg", "Крака", "Лег Преса", 10, 3, "https://www.youtube.com/watch?v=hYyPQkrOsJs" },
                    { 14, "Екстензиите за предно бедро основно натоварват квадрицепсите, като акцентът е върху правия бедрен мускул. Второстепенно могат да се активират и мускулите на бедрото като страничните части на квадрицепсите, в зависимост от позицията на краката. Тази упражнение е много ефективно за изолация на предната част на бедрата.", "Лесно", "https://i0.wp.com/muscu-street-et-crossfit.fr/wp-content/uploads/2022/09/Muscles-Leg-Extension.001.jpeg?resize=1024%2C576&ssl=1", "Крака", "Екстензии за предно бедро", 12, 4, "https://www.youtube.com/watch?v=uo9nJ8V13Ys" },
                    { 15, "Сгъване за задно бедро – основно натоварва хамстрингите (задната част на бедрото). Включват се и седалищните мускули в зависимост от амплитудата на движението.", "Лесно", "https://knockoutbg.com/wp-content/uploads/2022/10/mashina-zadno-bedro-evolve-leg-curl-ec-015-1.jpg", "Крака", "Екстензии за задно бедро", 12, 4, "https://www.youtube.com/watch?v=pey4eP2-PRw" },
                    { 16, "Сгъването на адуктори на машина се изпълнява, като седнеш на специализирана машина със странични подложки за бедрата. Краката са разтворени и поставени на подложките, след което ги приближаваш една към друга, като напрягаш вътрешната част на бедрата. Това упражнение активно натоварва адукторите, които са мускулите на вътрешната част на бедрата.", "Лесно", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOTSS_jxjKXyZSlClKwR6ugHui3cx5OPJX0Q&s", "Крака", "Сгъване на адуктори", 10, 3, "https://www.youtube.com/shorts/RNRgMox8xwE" },
                    { 17, "Българският клек се изпълнява с един крак на стъпало или пейка, а другият е в изправено положение. При спускането се извършва клякане с единия крак, докато другият остава на място. Това упражнение натоварва квадрицепсите, седалищните мускули и задното бедро, като включва и стабилизаторите на тялото.", "Трудно", "https://hercules.bg/wp-content/uploads/2020/10/bulgarian-split-squat.jpg", "Крака", "Български клек", 8, 3, "https://www.youtube.com/watch?v=CChuXbuB3XU" },
                    { 18, "Упражнението „топка към стена“ включва клякане и хвърляне на медицинска топка към стена. Изпълняваш клек, избутваш топката с ръце към стената и след това я хващаш и повтаряш. То натоварва квадрицепсите, седалището, раменете и ядрото.", "Средно", "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/04/wall-ball-1109.jpg?quality=86&strip=all", "Крака", "Топка към стена", 4, 15, "https://www.youtube.com/watch?v=ZRO2yxaibc0" }
                });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DificultyLevel", "MuscleGroup" },
                values: new object[] { "Средно-Напреднал", "Гърди" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DificultyLevel", "MuscleGroup" },
                values: new object[] { "Средно-Напреднал", "Гръб" });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatorId", "DayOfWeek", "DificultyLevel", "ImageUrl", "MuscleGroup", "OrderInWorkout", "Title", "TrainingPlanId" },
                values: new object[,]
                {
                    { 3, 2, "Сряда", "Средно-Напреднал", "https://4fitness.bg/blog/Files/Images/Article/Cache/580_232_koi-sa-nay-chestite-prichini-krakata-vi-da-izostavat.jpg", "Крака", 3, "Основна тренировка за крака", null },
                    { 4, 2, "Сряда", "Лесно", "https://pulsefit.bg/uploads/cache/O/public/uploads/media-manager/app-modules-blog-models-blog/header/71/797/back_1800x675.jpg", "Крака", 3, "Основна тренировка за крака", null },
                    { 5, 2, "Сряда", "Трудно", "https://www.obekti.bg/sites/default/files/styles/facebook/public/images/shutterstock_714092962.jpg?itok=8KXBwu4y", "Крака", 3, "Основна тренировка за крака", null }
                });

            migrationBuilder.InsertData(
                table: "WorkoutsExercises",
                columns: new[] { "Id", "ExcersiceId", "WorkoutId" },
                values: new object[,]
                {
                    { 9, 14, 4 },
                    { 10, 13, 4 },
                    { 11, 15, 4 },
                    { 12, 16, 4 },
                    { 13, 18, 4 },
                    { 14, 9, 3 },
                    { 15, 10, 3 },
                    { 16, 11, 3 },
                    { 17, 12, 3 },
                    { 18, 17, 3 },
                    { 19, 9, 5 },
                    { 20, 10, 5 },
                    { 21, 11, 5 },
                    { 22, 12, 5 },
                    { 23, 17, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts");

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "WorkoutsExercises",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DificultyLevel",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "MuscleGroup",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Workout Training Plan Id",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Workout Training Plan Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a2830ef-8be3-4ef6-910b-33b680d659d3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHh7juMMqDw4po08MRFQsYqoL0+D5X2QtyqtquU4cWmAbA7O1FR1meTWBKjYC8T0aA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "277e18ca-f6bd-4aa5-9bf0-b9826deb20ec", "AQAAAAIAAYagAAAAELLPnE67g7Z1JfOa1EQobxPc51fNj5kMFcAHbvHkxWa2Phj+Gu3Sh/5jGPs9/JlWTw==", "83ebe5c3-d706-4474-87e0-bed9bd430502" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5ad3b5f-9e79-4c05-8bbc-fc92288e84b5", "AQAAAAIAAYagAAAAEAnpRCcb6tEslxW35zcubyK8eQwfinRkR7HgsRCXaWFRKmunIHem5ksYb6mE5E01LQ==", "236b33b6-9df8-462e-8f39-01e390fdcf2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e136956-3e82-4e00-8f60-b274cdf40833",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFCVXahQMP+0Ha4TZXH1n7cYO3NN1Gb4ZjqoGxUtMLFXlyPpJoL10VQwh4fiwgzPkA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5df58ef6-da85-4d1d-a429-001e0856de72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02aad1d0-e757-448d-bdfa-faedc3e5aafd", "AQAAAAIAAYagAAAAEBfiPRR9bqfJRZnSmMZJRglMMZodXP3Zb0JATe4dp8m8gHsbWjo10pByBQW5S/qLsA==", "cf455523-4476-4268-878e-0f48e95b3e56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM13asjMhq+jmm2qClF1oCrG6CTExJWrE/+qgZO6Ytd1xnj9BtHGnKjNxD5xA4bYwQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd87d0e2-4047-473e-924a-3e10406c5583",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF410sa9FLRbWqtFz1YjuPbfZadXQtC/aAWuen1sVncTxHdg07nRJ6y8C1lPMiMgKg==");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
