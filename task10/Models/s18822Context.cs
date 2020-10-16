using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task10.Models
{
    public partial class s18822Context : DbContext
    {
        public s18822Context()
        {
        }

        public s18822Context(DbContextOptions<s18822Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("Animal_pk");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Owner");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("Owner_pk");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(e => e.IdProcedure)
                    .HasName("Procedure_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcedureAnimal>(entity =>
            {
                entity.HasKey(e => new { e.ProcedureIdProcedure, e.AnimalIdAnimal, e.Date })
                    .HasName("Procedure_Animal_pk");

                entity.ToTable("Procedure_Animal");

                entity.Property(e => e.ProcedureIdProcedure).HasColumnName("Procedure_IdProcedure");

                entity.Property(e => e.AnimalIdAnimal).HasColumnName("Animal_IdAnimal");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.AnimalIdAnimalNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.AnimalIdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Animal");

                entity.HasOne(d => d.ProcedureIdProcedureNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.ProcedureIdProcedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Procedure");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("Project_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("Task_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdAssignedToNavigation)
                    .WithMany(p => p.TaskIdAssignedToNavigation)
                    .HasForeignKey(d => d.IdAssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember2");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.TaskIdCreatorNavigation)
                    .HasForeignKey(d => d.IdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember1");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Project");

                entity.HasOne(d => d.IdTaskTypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdTaskType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TaskType");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.IdTaskType)
                    .HasName("TaskType_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.IdTeamMember)
                    .HasName("TeamMember_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
