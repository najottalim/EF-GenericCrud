using EntityCrud.Models;
using EntityCrud.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCrud.Data.Contexts
{
    internal class NajotTalimDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Constants.NajotTalimConnectionString);
        }
    }
}
