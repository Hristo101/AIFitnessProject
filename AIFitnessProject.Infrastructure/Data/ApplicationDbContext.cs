using AIFitnessProject.Infrastructure.Data.Configuration;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AIFitnessProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<RequestsToCoach>
            //    ().HasKey(x => new { x.TrainerId, x.UserId });


            builder.Entity<ExerciseFeedback>()
         .HasOne(x => x.TrainingPlan)
         .WithMany(x => x.ExerciseFeedbacks)
         .HasForeignKey(x => x.TrainingPlanId);


            builder.Entity<ExerciseFeedback>()
         .HasOne(x => x.Exercise)
         .WithMany(x => x.ExerciseFeedbacks)
         .HasForeignKey(x => x.ExerciseId);

            builder.Entity<MealsDailyDietPlan>()
         .HasOne(x => x.DailyDietPlans)
         .WithMany(x => x.MealsDailyDietPlans)
         .HasForeignKey(x => x.DailyDietPlansId);

            builder.Entity<TrainingPlanWorkout>()
                .HasOne(x => x.Workout)
                .WithMany(x => x.TrainingPlanWorkouts)
                 .HasForeignKey(x => x.WorkoutId);


            builder.Entity<TrainingPlanWorkout>()
                .HasOne(x => x.TrainingPlan)
                .WithMany(x => x.TrainingPlanWorkouts)
                 .HasForeignKey(x => x.TrainingPlanId);

            builder.Entity<MealsDailyDietPlan>()
            .HasOne(x => x.Meal)
            .WithMany(x => x.MealsDailyDietPlans)
            .HasForeignKey(x => x.MealId);

            builder.Entity<WorkoutsExercise>()
              .HasOne(x => x.Workout)
              .WithMany(x => x.WorkoutsExercises)
              .HasForeignKey(x => x.WorkoutId);


            builder.Entity<WorkoutsExercise>()
           .HasOne(x => x.Exercise)
           .WithMany(x => x.WorkoutsExercises)
           .HasForeignKey(x => x.ExcersiceId);


            builder.Entity<RequestsToCoach>()
                .HasOne(x => x.User)
                .WithMany(x => x.ReceivedRequests)
                .HasForeignKey(x =>x.UserId);


            builder.Entity<RequestsToCoach>()
                .HasOne(x => x.Trainer)
                .WithMany(x => x.ReceivedRequests)
                .HasForeignKey(x => x.TrainerId);


            builder.Entity<Trainer>()
                .HasOne(t => t.User)
                .WithOne(u => u.Trainer)
                .HasForeignKey<Trainer>(t => t.UserId);

            builder.Entity<Dietitian>()
                .HasOne(t => t.User)
                .WithOne(u => u.Dietitian)
                .HasForeignKey<Dietitian>(t => t.UserId);

            builder.Entity<UserComment>()
                .HasOne(uc => uc.Receiver)
                .WithMany(u => u.ReceivedComments)
                .HasForeignKey(uc => uc.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<UserComment>()
                .HasOne(uc => uc.Sender)
                .WithMany(u => u.SentComments)
                .HasForeignKey(uc => uc.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TrainerConfiguration());
            builder.ApplyConfiguration(new CommentsConfiguration());
            builder.ApplyConfiguration(new DietitianConfiguration());
            builder.ApplyConfiguration(new OpinionConfiguration());

            //Треньор
            builder.ApplyConfiguration(new TrainingPlanConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
            builder.ApplyConfiguration(new WorkoutsExerciseConfiguration());
            builder.ApplyConfiguration(new TrainingPlanWorkoutConfiguration());


            builder.ApplyConfiguration(new DietConfiguration());
            builder.ApplyConfiguration(new RequestToDietitianConfiguration());
            builder.ApplyConfiguration(new DailyDietPlanConfiguration());
            builder.ApplyConfiguration(new MealConfiguration());
            builder.ApplyConfiguration(new MealDailyDietPlanConfiguration());

            base.OnModelCreating(builder);
        }
            public DbSet<Diet> Diets {get; set; }
            public DbSet<Calendar> Calendars { get; set; }
            public DbSet<DailyDietPlan> DailyDietPlans { get; set; }
            public DbSet<RequestsToCoach> RequestsToCoaches { get; set; }
        public DbSet<TrainingPlanWorkout> TrainingPlanWorkouts { get; set; }
        public DbSet<MealsDailyDietPlan> MealsDailyDietPlans { get; set; }
            public DbSet<WorkoutsExercise> WorkoutsExercises { get; set; }
            public DbSet<RequestToDietitian> RequestToDietitians { get; set; }
            public DbSet<Exercise> Exercises { get; set; }
            public DbSet<Meal> Meals { get; set; }
            public DbSet<Opinion> Opinions { get; set; }
            public DbSet<PlanAssignment> PlanAssignments { get; set; }
            public DbSet<ExerciseFeedback> ExerciseFeedbacks { get; set; }
            public DbSet<Workout> Workouts { get; set; }
            public DbSet<Trainer> Trainers { get; set; }
            public DbSet<Dietitian> Dietitians { get; set; }
            public DbSet<UserComment> UserComments { get; set; }
            public DbSet<Notification> Notifications { get; set; }
            public DbSet<Document> Documents { get; set; }



    }
}
