using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.HasKey(v => v.IdVolunteer);
            builder.HasOne(s => s.Supervisor).WithMany().HasForeignKey(s => s.IdSupervisor);
            builder.Property(v => v.Name).IsRequired().HasMaxLength(80);
            builder.Property(v => v.Surname).IsRequired().HasMaxLength(80);
            builder.Property(v => v.Phone).IsRequired().HasMaxLength(30);
            builder.Property(v => v.Address).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Email).IsRequired().HasMaxLength(80);
            builder.Property(v => v.StartingDate).IsRequired();
        }
    }
}
