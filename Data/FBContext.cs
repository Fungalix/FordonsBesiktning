using FordonsBesiktning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FordonsBesiktning.Data
{
    class FBContext : DbContext
    {
        public DbSet<Reservation> Reservation { get; protected set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=Bilbesiktning;Trusted_Connection=True");
        }
    }
}
