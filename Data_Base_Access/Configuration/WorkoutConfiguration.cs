using Data_Base_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Configuration
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workout").HasKey(u => u.Id);

            builder.Property(w => w.Date).IsRequired();

            builder.HasOne(w => w.User).WithMany(u => u.Workouts).HasForeignKey(w => w.CientID); //optional nume
        }
    }
}
