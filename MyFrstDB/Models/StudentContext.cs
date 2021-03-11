using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MyFrstDB.Models;
namespace MyFrstDB.Models
{
    public class StudentContext:DbContext
    {
        //public StudentContext()
        //{

        //}

        //public StudentContext(DbContextOptions<StudentContext> options)
        // : base(options)
        //{

        //}

        public DbSet<Student> students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= (localdb)\\MSSQLLocalDB;Database =University;trusted_connection=true");
           
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(x =>
            {
                x.HasKey(y => y.Id);
                x.ToTable("Students");
                x.Property(y => y.Name).HasColumnType("NVARCHAR(50)");
                x.Property(y => y.LastName).HasColumnType("NVARCHAR(50)");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
