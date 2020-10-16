using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Configurations;

namespace WebApplication1.Models
{
    public class PetAdoptionContext : DbContext
    {
        public virtual DbSet<BreedType> BreedType { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }
        public virtual DbSet<Volunteer_Pet> Volunteer_Pet { get; set; }
        public PetAdoptionContext() { }
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options) : base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PetConfiguration());

            modelBuilder.ApplyConfiguration(new VolunteerConfiguration());

            modelBuilder.ApplyConfiguration(new Volunteer_PetConfiguration());


            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        
        }
        protected void Seed(ModelBuilder modelBuilder)
        {
            var breedtypes = new List<BreedType>();
            var pets = new List<Pet>();
            var volunteers = new List<Volunteer>();
            var v_p = new List<Volunteer_Pet>();
            breedtypes.Add(new BreedType()
            {
                IdBreedType = 1,
                Name = "Rassel Terrier",
                Description = "SUPER NICE"
            });
            breedtypes.Add(new BreedType()
            {
                IdBreedType = 2,
                Name = "Corgi",
                Description = "fluffy!!!"
            });
            modelBuilder.Entity<BreedType>().HasData(breedtypes);

            pets.Add(new Pet()
            {
                IdPet = 1,
                IdBreedType = 1,
                Name = "Mickey",
                IsMale = true,
                DateRegistered = Convert.ToDateTime("2019-09-09"),
                ApproximateDateOfBirth = Convert.ToDateTime("2018-08-09"),
                DateAdopted = Convert.ToDateTime("2020-05-05")

            });
            pets.Add(new Pet()
            {
                IdPet = 2,
                IdBreedType = 2,
                Name = "Ash",
                IsMale = false,
                DateRegistered = Convert.ToDateTime("2020-01-09"),
                ApproximateDateOfBirth = Convert.ToDateTime("2019-07-09")

            });
            modelBuilder.Entity<Pet>().HasData(pets);


            volunteers.Add(new Volunteer()
            {
                IdVolunteer = 1,
                Name = "Alex",
                Surname="Koakoka",
                Phone="+48999999999",
                Address="Warsaw, Dobra 9/12",
                Email="alexilovepets@gmail.com",
                StartingDate = Convert.ToDateTime("2013-09-09")
            

            });
            volunteers.Add(new Volunteer()
            {
                IdVolunteer = 2,
                IdSupervisor=1,
                Name = "John",
                Surname = "Plskksoakoka",
                Phone = "+48991111113",
                Address = "Warsaw, Konarskiego 11/112",
                Email = "johnPkskkd@gmail.com",
                StartingDate = Convert.ToDateTime("2019-09-10")

            });
            modelBuilder.Entity<Volunteer>().HasData(volunteers);

            v_p.Add(new Volunteer_Pet()
            {
                IdVolunteer = 1,
                IdPet = 1,
                DateAccepted = Convert.ToDateTime("2020-04-09")
            });
            v_p.Add(new Volunteer_Pet()
            {
                IdVolunteer = 2,
                IdPet = 2,
                DateAccepted = Convert.ToDateTime("2020-05-01")

            });
            modelBuilder.Entity<Volunteer_Pet>().HasData(v_p);

        }
    }
}
