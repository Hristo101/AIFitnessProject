using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIFitnessProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedConstraintForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedBy",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_CreatedBy",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Diets");

            migrationBuilder.AlterTable(
                name: "Workouts",
                comment: "Workout Table");

            migrationBuilder.AlterTable(
                name: "UserComments",
                comment: "User Comment Table");

            migrationBuilder.AlterTable(
                name: "TrainingPlan",
                comment: "Training Plan Table");

            migrationBuilder.AlterTable(
                name: "Trainers",
                comment: "Trainer Table");

            migrationBuilder.AlterTable(
                name: "PlanAssignments",
                comment: "Plan Assignment Table");

            migrationBuilder.AlterTable(
                name: "Notifications",
                comment: "Notification Table");

            migrationBuilder.AlterTable(
                name: "Meals",
                comment: "Meal Table");

            migrationBuilder.AlterTable(
                name: "Diets",
                comment: "Diet Table");

            migrationBuilder.AlterTable(
                name: "Dietitians",
                comment: "Dietitian Table");

            migrationBuilder.AlterTable(
                name: "DietDetails",
                comment: "DietDetail Table");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "ApplicationUser Table");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Workout Training Plan Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderInWorkout",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Workout Order In Workout",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Workout Exercise Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "Workouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Workout Day Of Week",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Workout Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Comment Sender Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Comment Receiver Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UserComments",
                type: "int",
                nullable: false,
                comment: "User Comment Rating",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "UserComments",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                comment: "User Comment Content",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserComments",
                type: "int",
                nullable: false,
                comment: "User Comment Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingPlan",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Training Plan Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrainingPlan",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                comment: "Training Plan Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                comment: "Training Plan Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Training Plan Creator Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Trainers",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Trainer User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Trainers",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "Trainer Specialization",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SertificationDetails",
                table: "Trainers",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                comment: "Trainer Sertification Details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Trainers",
                type: "int",
                nullable: false,
                comment: "Trainer Experience",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Trainers",
                type: "int",
                nullable: false,
                comment: "Trainer Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trainers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Trainer ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PlanAssignments",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Plan Assignment User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                comment: "Plan Assignment Training Plan Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "PlanAssignments",
                type: "datetime2",
                nullable: false,
                comment: "Start Date And Time Of Plan Assignment",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "PlanAssignments",
                type: "datetime2",
                nullable: false,
                comment: "End Date And Time Of Plan Assignment",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                comment: "Plan Assignment Diet Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                comment: "Plan Assignment Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Notification User Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Notifications",
                type: "int",
                nullable: false,
                comment: "Notification Trainer Id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "Notification Message",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                comment: "Date And Time Of Notification",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Notifications",
                type: "int",
                nullable: false,
                comment: "Notification Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Meals",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Meal VideoUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Recipe",
                table: "Meals",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "Meal Recipe",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Meal Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Meal ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Meals",
                type: "int",
                nullable: false,
                comment: "Meal Calories",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Meals",
                type: "int",
                nullable: false,
                comment: "Meal Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Exercises",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Exercise VideoUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Exercise Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "Exercise MuscleGroup",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                comment: "Exercise ImageUrl",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevel",
                table: "Exercises",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Exercise DifficultyLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                comment: "Exercise Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Exercises",
                type: "int",
                nullable: false,
                comment: "Comment Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Diet Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                comment: "Diet Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Diets",
                type: "int",
                nullable: false,
                comment: "Diet Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Dietitians",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "Dietitian Specialization",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SertificationDetails",
                table: "Dietitians",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                comment: "Dietitian SertificationDetails",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dietitians",
                type: "int",
                nullable: false,
                comment: "Dietitian Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dietitians",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Dietitian ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "MealTime",
                table: "DietDetails",
                type: "nvarchar(max)",
                nullable: false,
                comment: "DietDetail MealTime",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeel",
                table: "DietDetails",
                type: "nvarchar(max)",
                nullable: false,
                comment: "DietDetail MealTime",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DietDetails",
                type: "int",
                nullable: false,
                comment: "DietDetail Table",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "ApplicationUser ExperienceLevel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_CreatedById",
                table: "TrainingPlan",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedById",
                table: "TrainingPlan",
                column: "CreatedById",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedById",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_CreatedById",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dietitians");

            migrationBuilder.AlterTable(
                name: "Workouts",
                oldComment: "Workout Table");

            migrationBuilder.AlterTable(
                name: "UserComments",
                oldComment: "User Comment Table");

            migrationBuilder.AlterTable(
                name: "TrainingPlan",
                oldComment: "Training Plan Table");

            migrationBuilder.AlterTable(
                name: "Trainers",
                oldComment: "Trainer Table");

            migrationBuilder.AlterTable(
                name: "PlanAssignments",
                oldComment: "Plan Assignment Table");

            migrationBuilder.AlterTable(
                name: "Notifications",
                oldComment: "Notification Table");

            migrationBuilder.AlterTable(
                name: "Meals",
                oldComment: "Meal Table");

            migrationBuilder.AlterTable(
                name: "Diets",
                oldComment: "Diet Table");

            migrationBuilder.AlterTable(
                name: "Dietitians",
                oldComment: "Dietitian Table");

            migrationBuilder.AlterTable(
                name: "DietDetails",
                oldComment: "DietDetail Table");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "ApplicationUser Table");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "Workouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Workout Training Plan Id");

            migrationBuilder.AlterColumn<int>(
                name: "OrderInWorkout",
                table: "Workouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Workout Order In Workout");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Workouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Workout Exercise Id");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Workout Day Of Week");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Workouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Workout Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Comment Sender Id");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Comment Receiver Id");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UserComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "User Comment Rating");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldComment: "User Comment Content");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "User Comment Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingPlan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Training Plan Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrainingPlan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldComment: "Training Plan Description");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Training Plan Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Trainers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Trainer User Id");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "Trainer Specialization");

            migrationBuilder.AlterColumn<string>(
                name: "SertificationDetails",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldComment: "Trainer Sertification Details");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Trainers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Trainer Experience");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Trainers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Trainer Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PlanAssignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Plan Assignment User Id");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Plan Assignment Training Plan Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "PlanAssignments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Start Date And Time Of Plan Assignment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "PlanAssignments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "End Date And Time Of Plan Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Plan Assignment Diet Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlanAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Plan Assignment Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Notification User Id");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Notification Trainer Id");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "Notification Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date And Time Of Notification");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Notification Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Meal VideoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Recipe",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "Meal Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Meal Name");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Meal ImageUrl");

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Meals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Meal Calories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Meals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Meal Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Exercise VideoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Exercise Name");

            migrationBuilder.AlterColumn<string>(
                name: "MuscleGroup",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "Exercise MuscleGroup");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldComment: "Exercise ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevel",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Exercise DifficultyLevel");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldComment: "Exercise Description");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Exercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Comment Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Diet Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldComment: "Diet Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Diets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Diet Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Dietitians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "Dietitian Specialization");

            migrationBuilder.AlterColumn<string>(
                name: "SertificationDetails",
                table: "Dietitians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500,
                oldComment: "Dietitian SertificationDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dietitians",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Dietitian Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "MealTime",
                table: "DietDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "DietDetail MealTime");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeel",
                table: "DietDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "DietDetail MealTime");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DietDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "DietDetail Table")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser LastName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "ApplicationUser ExperienceLevel");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_CreatedBy",
                table: "TrainingPlan",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_Trainers_CreatedBy",
                table: "TrainingPlan",
                column: "CreatedBy",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
