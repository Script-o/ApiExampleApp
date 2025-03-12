using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ApiExampleShared;

namespace ApiExampleApi.Data
{
    public class EmployeeDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EmployeeDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* This is what is actually needed to set up the file path the the Sqlite database.
             * It uses the connection string specified in appsettings.json */
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("EmployeeDB"));
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employee");

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Nonie",
                        LastName = "Norgue",
                        Email = "nnorgue0@disqus.com",
                        Department = "Research and Development"
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Bonie",
                        LastName = "Borgue",
                        Email = "bborgue0@disqus.com",
                        Department = "Research and Development"
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Wonie",
                        LastName = "Worgue",
                        Email = "wworgue0@disqus.com",
                        Department = "Research and Development"
                    },
                    new Employee
                    {
                        Id = 4,
                        FirstName = "Gonie",
                        LastName = "Gorgue",
                        Email = "ggorgue0@disqus.com",
                        Department = "Research and Development"
                    },
                    new Employee
                    {
                        Id = 5,
                        FirstName = "Monie",
                        LastName = "Morgue",
                        Email = "mmorgue0@disqus.com",
                        Department = "Research and Development"
                    }
                );
        }
    }
}
