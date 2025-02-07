using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Profile Picture stored as byte array"),
                    FirstName = table.Column<string>(type: "nvarchar(1900)", maxLength: 1900, nullable: false, comment: "ApplicationUser FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(1900)", maxLength: 1900, nullable: false, comment: "ApplicationUser LastName"),
                    Height = table.Column<double>(type: "float", nullable: false, comment: "ApplicationUser Height"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "ApplicationUser Weight"),
                    Aim = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "ApplicationUser Aim"),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(2100)", maxLength: 2100, nullable: false, comment: "ApplicationUser ExperienceLevel"),
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
                    DifficultyLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Exercise DifficultyLevel"),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false)
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
                    DificultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Meal Dificulty Level"),
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
                    Specialization = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Dietitian Specialization"),
                    Experience = table.Column<int>(type: "int", nullable: false, comment: "Dietitian Experience"),
                    SertificateImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Dietitian Sertification Image"),
                    SertificationDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Dietitian SertificationDetails"),
                    Bio = table.Column<string>(type: "nvarchar(max)", maxLength: 4500, nullable: false, comment: "Dietitian Bio"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Dietitian Phone Number"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Dietitian User Id")
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
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Document Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Document User identifier"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Document User Position"),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false, comment: "Document Is Accept"),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false, comment: "Documents User Experience In Years"),
                    SertificateImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Document User Sertification Image"),
                    Bio = table.Column<string>(type: "nvarchar(max)", maxLength: 4500, nullable: false, comment: "Document User Bio"),
                    Specialization = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Document User Specialization"),
                    SertificationDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Document User Sertification Details")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Document Table");

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false, comment: "User Opinion Content"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Opinion Sender Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Trainer Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Trainer Specialization"),
                    Experience = table.Column<int>(type: "int", nullable: false, comment: "Trainer Experience"),
                    SertificateImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Trainer Sertification Image"),
                    SertificationDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Trainer Sertification Details"),
                    Bio = table.Column<string>(type: "nvarchar(max)", maxLength: 4500, nullable: false, comment: "Trainer Bio"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Trainer Phone Number"),
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Diet Image Url"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Diet User Id"),
                    CreatedById = table.Column<int>(type: "int", nullable: false, comment: "Diet Creator Id"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Dietitians_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Diet Table");

            migrationBuilder.CreateTable(
                name: "RequestToDietitians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request To Dietitian Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Target"),
                    UserPictures = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Pictures"),
                    DietBackground = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Diet Background"),
                    HealthIssues = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Health Issues"),
                    FoodAllergies = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Foods Allergies"),
                    FavouriteFoods = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Favourite Food"),
                    MealPreparationPreference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Meal Preparation Preference"),
                    PreferredMealsPerDay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Preffered Meals Per Day"),
                    DislikedFoods = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Disliked Foods"),
                    SupplementsUsed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "User Used Supplements"),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false, comment: "Has the request been answered?"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    DietitianId = table.Column<int>(type: "int", nullable: false, comment: "Dietitian Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToDietitians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestToDietitians_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestToDietitians_Dietitians_DietitianId",
                        column: x => x.DietitianId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Request To Dietitian Table");

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
                name: "RequestsToCoaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicturesOfPersons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingBackground = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingCommitment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsToCoaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsToCoaches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsToCoaches_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Training Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Training Plan Name"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Training Plan Description"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Training Plan  User Id"),
                    CreatedById = table.Column<int>(type: "int", nullable: false, comment: "Training Plan Creator Id"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_Trainers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Training Plan Table");

            migrationBuilder.CreateTable(
                name: "DailyDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Title"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Image Url"),
                    MealTime = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan MealTime"),
                    DayOfWeel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Day Of Week"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Creator Identifier"),
                    DietId = table.Column<int>(type: "int", nullable: false, comment: "Daily Diet Plan Diet Identifier"),
                    DificultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Daily Diet Plan Dificulty Level")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDietPlans_Dietitians_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Dietitians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietPlans_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "DailyDietPlan Table");

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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Workout Image"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Workout Title"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: true, comment: "Workout Training Plan Id"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Workout Day Of Week"),
                    OrderInWorkout = table.Column<int>(type: "int", nullable: false, comment: "Workout Order In Workout"),
                    DificultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Trainers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workouts_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id");
                },
                comment: "Workout Table");

            migrationBuilder.CreateTable(
                name: "MealsDailyDietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Meals Dily Diet Plan Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyDietPlansId = table.Column<int>(type: "int", nullable: false, comment: "Dily Diet Plan Identifier"),
                    MealId = table.Column<int>(type: "int", nullable: false, comment: "Meal Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsDailyDietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealsDailyDietPlans_DailyDietPlans_DailyDietPlansId",
                        column: x => x.DailyDietPlansId,
                        principalTable: "DailyDietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealsDailyDietPlans_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Meals Dily Diet Plan Table");

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

            migrationBuilder.CreateTable(
                name: "WorkoutsExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcersiceId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutsExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Exercises_ExcersiceId",
                        column: x => x.ExcersiceId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutsExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_DailyDietPlans_CreatorId",
                table: "DailyDietPlans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietPlans_DietId",
                table: "DailyDietPlans",
                column: "DietId");

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
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDailyDietPlans_DailyDietPlansId",
                table: "MealsDailyDietPlans",
                column: "DailyDietPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsDailyDietPlans_MealId",
                table: "MealsDailyDietPlans",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TrainerId",
                table: "Notifications",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_SenderId",
                table: "Opinions",
                column: "SenderId");

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
                name: "IX_RequestsToCoaches_TrainerId",
                table: "RequestsToCoaches",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsToCoaches_UserId",
                table: "RequestsToCoaches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToDietitians_DietitianId",
                table: "RequestToDietitians",
                column: "DietitianId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToDietitians_UserId",
                table: "RequestToDietitians",
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
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ReceiverId",
                table: "UserComments",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_SenderId",
                table: "UserComments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatorId",
                table: "Workouts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainingPlanId",
                table: "Workouts",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercises_ExcersiceId",
                table: "WorkoutsExercises",
                column: "ExcersiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutsExercises_WorkoutId",
                table: "WorkoutsExercises",
                column: "WorkoutId");
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
                name: "Documents");

            migrationBuilder.DropTable(
                name: "MealsDailyDietPlans");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "PlanAssignments");

            migrationBuilder.DropTable(
                name: "RequestsToCoaches");

            migrationBuilder.DropTable(
                name: "RequestToDietitians");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "WorkoutsExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DailyDietPlans");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Diets");

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
