using Microsoft.EntityFrameworkCore;
using System;
using UserAuthenticationSystem.model;

namespace UserAuthenticationSystem.Data
{
    public class ApDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-EBGDS2LB;database=data;Integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<User> Users { get; set; }
    }
}
