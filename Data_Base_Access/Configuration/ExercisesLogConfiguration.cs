using Data_Base_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Configuration
{
    public class ExercisesLogConfiguration : IEntityTypeConfiguration<ExercisesLog>
    {
        public void Configure(EntityTypeBuilder<ExercisesLog> builder)
        {
            builder.ToTable("ExercisesLog");
            builder.HasKey(e => new { e.Id_Workout, e.Id_Exercice });

            builder.HasOne(el => el.Workout).WithMany(e => e.ExercisesLog).HasForeignKey(el => el.Id_Workout);


            builder.HasOne(el => el.Exercise).WithMany(e => e.ExerciseLogs).HasForeignKey(el => el.Id_Exercice);

        }
    }
}
