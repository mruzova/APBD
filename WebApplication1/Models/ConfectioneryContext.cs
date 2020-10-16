using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ConfectioneryContext: DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
         public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Confectionery> Confectionery { get; set; }
        public virtual DbSet<Confectionery_Order> Confectionery_Order { get; set; }
       

        public ConfectioneryContext()
        { }

        public ConfectioneryContext(DbContextOptions<ConfectioneryContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.IdCustomer);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Surname).IsRequired().HasMaxLength(60);

            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(60);
            });
            modelBuilder.Entity<Confectionery>(entity =>
            {

                entity.HasKey(e => e.IdConfectionery);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.PricePerItem).IsRequired();
                entity.Property(e => e.Type).IsRequired().HasMaxLength(40);

            });
            modelBuilder.Entity<Order>(entity =>
            {

                entity.HasKey(e => e.IdOrder); 
                entity.Property(p => p.DateAccepted).IsRequired();
                entity.Property(p => p.DateFinished).IsRequired();
                entity.Property(p => p.Notes).IsRequired().HasMaxLength(255);
                entity.HasOne<Customer>()
                    .WithMany()
                    .HasForeignKey(p =>p.IdCustomer)
                    .IsRequired();

                entity.HasOne<Employee>()
                    .WithMany()
                    .HasForeignKey(p => p.IdEmployee)
                    .IsRequired();
            });
            modelBuilder.Entity<Confectionery_Order>(entity =>
            {
                entity.HasKey(e => new { e.IdConfectionery, e.IdOrder });

                entity.HasOne<Confectionery>()
                    .WithMany()
                    .HasForeignKey(p => p.IdConfectionery)
                    .IsRequired();

                entity.HasOne<Order>()
                    .WithMany()
                    .HasForeignKey(p => p.IdOrder)
                    .IsRequired();

                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Notes).IsRequired().HasMaxLength(255);
             });
            Seed(modelBuilder);
        }
        protected void Seed(ModelBuilder modelBuilder)
        {
            var employees = new List<Employee>();
            var customers = new List<Customer>();
            var confectioneries = new List<Confectionery>();
            var orders = new List<Order>();
            var confectioneries_orders = new List<Confectionery_Order>();

            employees.Add(new Employee()
            {
                IdEmployee = 1,
                Name = "Alex",
                Surname = "Way"
            });
            employees.Add(new Employee()
            {
                IdEmployee = 2,
                Name = "Alex2",
                Surname = "Way2"
            });
            modelBuilder.Entity<Employee>().HasData(employees);
            customers.Add(new Customer()
            {
                IdCustomer = 1,
                Name = "Jennifer",
                Surname = "Day"
            });
            customers.Add(new Customer()
            {
                IdCustomer = 2,
                Name = "Jennifer2",
                Surname = "Day2"
            });
            modelBuilder.Entity<Customer>().HasData(customers);




            confectioneries.Add(new Confectionery()
            {
                IdConfectionery = 1,
                Name = "ponchik",
                PricePerItem = 1.2,
                Type = "sladost"
            });

            confectioneries.Add(new Confectionery()
            {
                IdConfectionery = 2,
                Name = "tortik",
                PricePerItem = 2.2,
                Type = "sladkaya sladost"
            });
            modelBuilder.Entity<Confectionery>().HasData(confectioneries);


            orders.Add(new Order()
            {
                IdOrder = 1,
                DateAccepted = Convert.ToDateTime("2020-03-10"),
                DateFinished = Convert.ToDateTime("2020-06-11"),
               Notes = "vkusno",
               IdCustomer=1,
               IdEmployee=1
            });
            orders.Add(new Order()
            {
                IdOrder = 2,
                DateAccepted = Convert.ToDateTime("2020-09-12"),
                DateFinished = Convert.ToDateTime("2020-10-12"),
                Notes = "nu ne ochen vkusno",
                IdCustomer = 2,
                IdEmployee = 2
            });
            modelBuilder.Entity<Order>().HasData(orders);


            confectioneries_orders.Add(new Confectionery_Order()
            {
               IdConfectionery = 1,
               IdOrder=1,
               Quantity = 3,
               Notes = "normik"
            });
            confectioneries_orders.Add(new Confectionery_Order()
            {
                IdConfectionery = 2,
                IdOrder = 2,
                Quantity = 5,
                Notes = "nu pochti normik"
            });
            modelBuilder.Entity<Confectionery_Order>().HasData(confectioneries_orders);



        }
    }
    }
