using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Contexts
{
    public class VetClinicDBContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
    }
}