using Data_Base_Access.Configuration;
using Data_Base_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access
{
    public class WorkoutContext : DbContext

    {

        public WorkoutContext() { }
        public WorkoutContext (DbContextOptions<WorkoutContext> options ) :base(options)  
        { 
            
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<ExercisesLog> ExercisesLogs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                var conncectionString = "Data Source=DESKTOP-IO1IGP9\\SQLEXPRESS;Initial Catalog=SmartWorkoutFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(conncectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating( modelBuilder);

            new UserConfiguration().Configure(modelBuilder.Entity<Users>());
            new WorkoutConfiguration().Configure(modelBuilder.Entity<Workout>());
            new ExercisesConfiguration().Configure(modelBuilder.Entity<Exercises>());
            new ExercisesLogConfiguration().Configure(modelBuilder.Entity<ExercisesLog>());


        }

    }
}
