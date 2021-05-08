using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class PersonelTakipContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PersonelTakipDb;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Database=PersonelTakip;Integrated Security=True;Trusted_Connection=true");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("User");

        //}

        public DbSet<Company> Companys { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineTracking> VaccineTrackings { get; set; }

    }
}
