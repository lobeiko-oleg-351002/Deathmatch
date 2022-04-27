using Microsoft.EntityFrameworkCore;
using Models;
using Models.InitialSeed;
using System;

namespace Database
{
    public class DeathmatchDbContext : DbContext
    {
        public DeathmatchDbContext(DbContextOptions<DeathmatchDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserInSession> UserInSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity("SchedulerModels.EventTemplate", b =>
            //{
            //    b.HasOne("SchedulerModels.Chief", null)
            //        .WithMany("EventTemplates")
            //        .HasForeignKey("ChiefId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity("SchedulerModels.WeeklyEventTime", b =>
            //{
            //    b.HasOne("SchedulerModels.WeeklyEvent", null)
            //        .WithMany("DateAndTime")
            //        .HasForeignKey("WeeklyEventId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }
    }
}
