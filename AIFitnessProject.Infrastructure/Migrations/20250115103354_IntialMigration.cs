using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ApplicationUser FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ApplicationUser LastName"),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ApplicationUser ExperienceLevel"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "ApplicationUser Table");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Exercise Name"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Exercise Description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Exercise ImageUrl"),
                    VideoUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Exercise VideoUrl"),
                    MuscleGroup = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "Exercise MuscleGroup"),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Exercise DifficultyLevel")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Meal Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Meal Name"),
                    Recipe = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Meal Recipe"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Meal ImageUrl"),
                    VideoUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Meal VideoUrl"),
                    Calories = table.Column<int>(type: "int", nullable: false, comment: "Meal Calories")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                },
                comment: "Meal Table");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dietitians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Dietitian Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Dietitian ImageUrl"),
                    Specialization = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Dietitian Specialization"),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    SertificationDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Dietitian SertificationDetails"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietitians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dietitians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Dietitian Table");

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Trainer Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Trainer Specialization"),
                    Experience = table.Column<int>(type: "int", nullable: false, comment: "Trainer Experience"),
                    SertificationDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Trainer Sertification Details"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Trainer ImageUrl"),
                    Bio = table.Column<string>(type: "nvarchar(max)", maxLength: 4500, nullable: false, comment: "Trainer Bio"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Trainer Phone Number"),
                    SertificationImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Trainer Sertification Image"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Trainer User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Trainer Table");

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "User Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "User Comment Rating"),
                    Content = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "User Comment Content"),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Comment Receiver Id"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Comment Sender Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User Comment Table");

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Diet Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Diet Name"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Diet Name"),
                    CreatedById = table.Column<int>(type: "int", nullable: false, comment: "Diet Creator Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_Dietitians_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Diet Table");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Notification Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Notification User Id"),
                    TrainerId = table.Column<int>(type: "int", nullable: false, comment: "Notification Trainer Id"),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Notification Message"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date And Time Of Notification"),
                    ReadStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Notification Table");

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Training Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Training Plan Name"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Training Plan Description"),
                    CreatedById = table.Column<int>(type: "int", nullable: false, comment: "Training Plan Creator Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_Trainers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Training Plan Table");

            migrationBuilder.CreateTable(
                name: "DietDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "DietDetail Table")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    MealTime = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "DietDetail MealTime"),
                    DayOfWeel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "DietDetail MealTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietDetails_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietDetails_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "DietDetail Table");

            migrationBuilder.CreateTable(
                name: "PlanAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Plan Assignment User Id"),
                    DietId = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Diet Id"),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false, comment: "Plan Assignment Training Plan Id"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start Date And Time Of Plan Assignment"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End Date And Time Of Plan Assignment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlanAssignments_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Plan Assignment Table");

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Workout Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false, comment: "Workout Training Plan Id"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false, comment: "Workout Exercise Id"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Workout Day Of Week"),
                    OrderInWorkout = table.Column<int>(type: "int", nullable: false, comment: "Workout Order In Workout")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Workout Table");

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    DietitianId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calendars_Dietitians_DietitianId",
                        column: x => x.DietitianId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Calendars_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Calendars_TrainingPlan_DietId",
                        column: x => x.DietId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Calendars_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ExperienceLevel", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "0a2830ef-8be3-4ef6-910b-33b680d659d3", 0, "c37f9e70-f9ff-4e55-8c95-83ce9708cef7", "stanislav@abv.bg", false, "Начинаещ,почти не съм влизал в зала да спортувам.Изглеждам ужасно и искам да отслабна!", "Stanislav", 1.95, "Ivanov", false, null, "STANISLAV@ABV.BG", "STANISLAV@ABV.BG", "AQAAAAIAAYagAAAAEKMozVsviW+CCc2Tz+fr9N7khWE+hDIgalwfpSJNPWS7MjxQREG5/ttgIHeRq9N+TA==", null, false, "9e406138-c088-4d10-810a-8cb287aa339b", false, "stanislav@abv.bg", 131.5 },
                    { "0e136956-3e82-4e00-8f60-b274cdf40833", 0, "e105f213-ede3-4a80-842f-3c9dc11968f3", "daniela@abv.bg", false, "Активно спортуващ,занимавала съм се с фитнес от 3 години,но сега главно наблягам върху тренировките за издръжливост", "Даниела", 1.7, "Манева", false, null, "DANIELA@ABV.BG", "DANIELA_5", "AQAAAAIAAYagAAAAEKAunNIJCw49N48zrGwwwatAKCVt/9+ukGtKQSpiB1GpcG+hGjSy81X9NqtRma2vYA==", null, false, "ddfff353-d2cc-4d0c-a9cd-c40f2914296b", false, "daniela_5", 55.0 },
                    { "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", 0, "ec2261ab-a653-4698-bbf8-03187c3e1877", "svetoslav@abv.bg", false, "Активно спортуващ,занимавал съм се с фитнес от 10 години,целта ми е да направя всички трениращи в това приложение да харесват своята визия", "Светослав", 2.0299999999999998, "Ковачев", false, null, "SVETOSLAV@ABV.BG", "SVETOSLAV102", "AQAAAAIAAYagAAAAEGpGWdQycQ1YyrtSM7TavrwHEVtbEjsMGIfjtfboG/n6wz+1kgizV4bQFEuHFV/4Tg==", null, false, "d258ec24-1129-4a44-84b4-4597aecc18e9", false, "svetoslav102", 82.0 },
                    { "cd87d0e2-4047-473e-924a-3e10406c5583", 0, "ddd19b43-78e7-4f76-ada7-a863c26dda43", "pesho@abv.bg", false, "Имам някакъв малък опит с фитнес залите целта ми е да стана 100 кила,но килограмите,които кача да бъдат мускулна маса", "Pesho", 2.0299999999999998, "Ivanov", false, null, "PESHO@ABV.BG", "PESHO@ABV.BG", "AQAAAAIAAYagAAAAEA+v13AndHYx22Tkv0N4i7EST5hzENr8poObunJAvbe68+BIT85fWDXFB6NeW3+usA==", null, false, "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f", false, "pesho@abv.bg", 92.0 }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Bio", "Experience", "ImageUrl", "PhoneNumber", "SertificationDetails", "SertificationImage", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, "Даниела Манева е фитнес треньор, който активно се занимава със спорт и фитнес от 3 години. Нейната специализация е в тренировките за издръжливост и функционален фитнес. Със силно желание да помогне на своите клиенти да постигнат максимална физическа издръжливост и да повишат спортната си подготовка, тя съчетава индивидуален подход с доказани методи за тренировки.\r\nДаниела вярва, че с упоритост и правилни тренировки, всеки може да постигне отлични резултати в здравето и физическата форма.", 5, "https://pulsefit.bg/uploads/cache/N/public/uploads/media-manager/app-modules-trainers-models-trainer/305/6874/novo.png", "0895124157", "Здравейте, аз съм сертифициран специалист по издръжливост и функционален фитнес. Специализирам в създаването на тренировъчни програми, които ще повишат вашата издръжливост и функционална сила.", "https://dani-sport.eu/wp-content/uploads/2021/06/UDOSTOVERENIE_TRENER_R-688x500.jpg", "Издръжливост и функционален фитнес", "0e136956-3e82-4e00-8f60-b274cdf40833" },
                    { 2, "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация. В началото на своето фитнес пътуване той не е имал перфектно тяло, а напротив – борел се е с наднормено тегло и липса на мотивация. Със силна воля и постоянство, той успява да постигне значителни резултати и сега е не само преобразен физически, но и психически.\r\n\r\nДнес Светослав е сертифициран треньор с опит и страст за това, което прави. Неговата цел е да помага на хората да постигнат не само физическите си цели, но и да изградят здравословни навици, които да продължат през целия живот. Той вярва, че промяната е възможна за всеки, стига да има правилния подход и подкрепа.\r\n\r\n\r\n\r\n\r\n", 4, "https://pulsefit.bg/uploads/cache/N/public/uploads/media-manager/app-modules-trainers-models-trainer/305/6874/novo.png", "0895124157", "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!", "https://fitnesstime.eu/wp-content/uploads/2018/11/fitness-licenz-nsa-min.png", "Изграждане на мускулна маса", "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" }
                });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "Content", "Rating", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Светослав е прекрасен треньор,който благодарение на него хората постигат своето мечтано тяло.Препоръчвам задължително!", 5, "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", "0a2830ef-8be3-4ef6-910b-33b680d659d3" },
                    { 2, "Невероятен треньор.Изключително прецизен в работата си,с изключително добро държание,с него можете да постигенте всичко", 5, "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", "cd87d0e2-4047-473e-924a-3e10406c5583" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DietId",
                table: "Calendars",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DietitianId",
                table: "Calendars",
                column: "DietitianId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TrainerId",
                table: "Calendars",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_WorkoutId",
                table: "Calendars",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_DietId",
                table: "DietDetails",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_DietDetails_MealId",
                table: "DietDetails",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietitians_UserId",
                table: "Dietitians",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CreatedById",
                table: "Diets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TrainerId",
                table: "Notifications",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssignments_DietId",
                table: "PlanAssignments",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssignments_TrainingPlanId",
                table: "PlanAssignments",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssignments_UserId",
                table: "PlanAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_CreatedById",
                table: "TrainingPlan",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ReceiverId",
                table: "UserComments",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_SenderId",
                table: "UserComments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ExerciseId",
                table: "Workouts",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "DietDetails");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PlanAssignments");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.DropTable(
                name: "Dietitians");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
