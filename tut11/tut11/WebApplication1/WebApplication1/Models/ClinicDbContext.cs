using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public ClinicDbContext()
        {

        }
        public ClinicDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.IdPatient);
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(100);
                entity.Property(p => p.BirthDate).IsRequired();

            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(d => d.LastName).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Email).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Medicament>(entity =>
           {

               entity.HasKey(e => e.IdMedicament);
               entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
               entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
               entity.Property(e => e.Type).IsRequired().HasMaxLength(100);

           });

            modelBuilder.Entity<Prescription>(entity =>
            {

                entity.HasKey(e => e.IdPrescription);
                entity.Property(p => p.Date).IsRequired();
                entity.Property(p => p.DueDate).IsRequired();

                entity.HasOne<Patient>()
                    .WithMany()
                    .HasForeignKey(p => p.IdPatient)
                    .IsRequired();

                entity.HasOne<Doctor>()
                    .WithMany()
                    .HasForeignKey(p => p.IdDoctor)
                    .IsRequired();
            });


            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });





                entity.HasOne<Medicament>()
                    .WithMany()
                    .HasForeignKey(p => p.IdMedicament)
                    .IsRequired();

                entity.HasOne<Prescription>()
                    .WithMany()
                    .HasForeignKey(p => p.IdPrescription)
                    .IsRequired();

                entity.Property(e => e.Dose);
                entity.Property(e => e.Details).IsRequired().HasMaxLength(100);

                Seed(modelBuilder);
            });

        }
        protected void Seed(ModelBuilder modelBuilder)
        {
            var patients = new List<Patient>();
            var doctors = new List<Doctor>();
            var medicaments = new List<Medicament>();
            var prescriptions = new List<Prescription>();
            var prescriptions_medicaments = new List<Prescription_Medicament>();

            patients.Add(new Patient()
            {
                IdPatient = 1,
                FirstName = "Alex",
                LastName = "Way",
                BirthDate = Convert.ToDateTime("2001-02-07")
            });
            patients.Add(new Patient()
            {
                IdPatient = 2,
                FirstName = "Kate",
                LastName = "Abrams",
                BirthDate = Convert.ToDateTime("1988-07-11")
            });
            patients.Add(new Patient()
            {
                IdPatient = 3,
                FirstName = "Louis",
                LastName = "Jones",
                BirthDate = Convert.ToDateTime("1976-12-03")
            });
            modelBuilder.Entity<Patient>().HasData(patients);
            doctors.Add(new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Jennifer",
                LastName = "Day",
                Email = "jenniferDay87@gmail.com"
            });
            doctors.Add(new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Anthony",
                LastName = "Miller",
                Email = "drMilleranth@gmail.com"
            });
            doctors.Add(new Doctor()
            {
                IdDoctor = 3,
                FirstName = "Anna",
                LastName = "Cooper",
                Email = "cooperdocAnn@gmail.com"
            });
            modelBuilder.Entity<Doctor>().HasData(doctors);

          

          
            medicaments.Add(new Medicament()
            {
                IdMedicament = 1,
                Name = "Carboxine",
                Description = "used to treat symptoms such as sneezing, runny nose, etc",
                Type = "antihistamine"
            });
            medicaments.Add(new Medicament()
            {
                IdMedicament = 2,
                Name = "Ofloxacin",
                Description = "used to treat bacterial infections ",
                Type = " antibiotic"
            });
            medicaments.Add(new Medicament()
            {
                IdMedicament = 3,
                Name = "Neurontin",
                Description = " used in adults to treat neuropathic pain",
                Type = "anti-epileptic drug"
            });
            modelBuilder.Entity<Medicament>().HasData(medicaments);

          
            prescriptions.Add(new Prescription()
            {
                IdPrescription = 1,
                Date = Convert.ToDateTime("2020-03-10"),
                DueDate = Convert.ToDateTime("2020-06-11"),
                IdPatient = 1,
                IdDoctor = 1
            });
            prescriptions.Add(new Prescription()
            {
                IdPrescription = 2,
                Date = Convert.ToDateTime("2019-02-02"),
                DueDate = Convert.ToDateTime("2020-02-02"),
                IdPatient = 2,
                IdDoctor = 2
            });
            prescriptions.Add(new Prescription()
            {
                IdPrescription = 3,
                Date = Convert.ToDateTime("2017-09-09"),
                DueDate = Convert.ToDateTime("2017-12-10"),
                IdPatient = 3,
                IdDoctor = 3
            });
            modelBuilder.Entity<Prescription>().HasData(prescriptions);

           
            prescriptions_medicaments.Add(new Prescription_Medicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "use in the moment of allergic reaction"
            });
            prescriptions_medicaments.Add(new Prescription_Medicament()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 1,
                Details = "3 times a day for 1 week"
            });
            prescriptions_medicaments.Add(new Prescription_Medicament()
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Dose = 3,
                Details = "once a month"
            });
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptions_medicaments);



        }
    }
}
