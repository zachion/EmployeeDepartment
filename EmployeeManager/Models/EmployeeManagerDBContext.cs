using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class EmployeeManagerDBContext : DbContext
    {
        public EmployeeManagerDBContext(DbContextOptions<EmployeeManagerDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=myTestDB;Persist Security Info=True;Integrated Security = true");
            }
        }
    }
}
