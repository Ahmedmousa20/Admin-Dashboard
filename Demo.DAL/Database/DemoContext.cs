using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Database
{
    public class DemoContext : DbContext
    {
        public DbSet<Department> Department { set; get; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { set; get; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

        public DemoContext(DbContextOptions<DemoContext> opt) : base(opt)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=DemoDb;Integrated Security=true");
        //}


    }
}
