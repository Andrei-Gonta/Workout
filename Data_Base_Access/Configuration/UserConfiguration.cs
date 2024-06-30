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
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.Phone).HasMaxLength(15);

        }

    }
}
