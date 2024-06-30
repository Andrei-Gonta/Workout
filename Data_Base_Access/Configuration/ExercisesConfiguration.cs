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
    public class ExercisesConfiguration : IEntityTypeConfiguration<Exercises>
    {
        public void Configure(EntityTypeBuilder<Exercises> builder)
        {
            builder.ToTable("Exercises").HasKey(e => e.Id);

            builder.Property(u => u.Ex_Name).IsRequired();
        }
    }
}
