using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class Volunteer_PetConfiguration : IEntityTypeConfiguration<Volunteer_Pet>
    {
        public void Configure(EntityTypeBuilder<Volunteer_Pet> builder)
        {
            builder.HasKey(vp => new { vp.IdVolunteer, vp.IdPet });
            builder.HasOne<Volunteer>().WithMany().HasForeignKey(v => v.IdVolunteer).IsRequired();
            builder.HasOne<Pet>().WithMany().HasForeignKey(p => p.IdPet).IsRequired();
            builder.Property(v => v.DateAccepted).IsRequired();
        }
    }
}
