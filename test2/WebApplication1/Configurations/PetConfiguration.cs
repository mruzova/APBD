using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
      
                builder.HasKey(p => p.IdPet);
                builder.HasOne<BreedType>().WithMany().HasForeignKey(b=>b.IdBreedType).IsRequired();
                builder.Property(p => p.Name).IsRequired().HasMaxLength(80);
                builder.Property(p => p.IsMale).IsRequired();
                builder.Property(p => p.DateRegistered).IsRequired();
                builder.Property(p => p.ApproximateDateOfBirth).IsRequired();
                builder.Property(p => p.ApproximateDateOfBirth);

           
        }
    }
}
