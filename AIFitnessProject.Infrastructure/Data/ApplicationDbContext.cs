using AIFitnessProject.Infrastructure.Data.Configuration;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            builder.Entity<RequestsToCoach>
                ().HasKey(x => new { x.TrainerId, x.UserId });

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

            base.OnModelCreating(builder);
        }
            public DbSet<Diet> Diets {get; set; }
            public DbSet<Calendar> Calendars { get; set; }
            public DbSet<DietDetail> DietDetails { get; set; }
            public DbSet<RequestsToCoach> RequestsToCoaches { get; set; }
            public DbSet<Exercise> Exercises { get; set; }
            public DbSet<Meal> Meals { get; set; }
            public DbSet<Opinion> Opinions { get; set; }
            public DbSet<PlanAssignment> PlanAssignments { get; set; }
            public DbSet<Workout> Workouts { get; set; }
            public DbSet<Trainer> Trainers { get; set; }
            public DbSet<Dietitian> Dietitians { get; set; }
            public DbSet<UserComment> UserComments { get; set; }
            public DbSet<Notification> Notifications { get; set; }
            public DbSet<Document> Documents { get; set; }



    }
}
