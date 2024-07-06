using System;
using Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Globalization;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<Group>()
        //             .HasData(
        //new Group
        //{
        //    Id = 1,
        //    Name = "Front-end"
        //},
        //   new Group
        //   {
        //       Id = 2,
        //       Name = "Back-end"
        //   });
        // modelBuilder.Entity<Student>()
        //                .HasData(
        //   new Student
        //   {
        //       Id = 1,
        //       FullName = "Nisa Narimanova",
        //       GroupId = 1
        //   },
        //     new Student
        //     {
        //         Id = 2,
        //         FullName = "Arzu Kerimli",
        //         GroupId = 2
        //     },
        //       new Student
        //       {
        //           Id = 3,
        //           FullName = "Meryem Eliyeva",
        //           GroupId = 1
        //       },

        //         new Student
        //         {
        //             Id = 4,
        //             FullName = "Metanet",
        //             GroupId = 2
        //         });

        }
    }
}

