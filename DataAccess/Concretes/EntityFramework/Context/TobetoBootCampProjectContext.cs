using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.Context;

public class TobetoBootCampProjectContext : DbContext
{

    public TobetoBootCampProjectContext()
    {

    }
    public TobetoBootCampProjectContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>().ToTable("Applicants");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Instructor>().ToTable("Instructors");
        modelBuilder.Entity<User>().ToTable("Users");


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var reletioship in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
        {
            reletioship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }

    protected IConfiguration Configuration { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
}
