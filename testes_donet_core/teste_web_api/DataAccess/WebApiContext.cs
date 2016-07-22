using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste_web_api.Models;

namespace teste_web_api.DataAccess
{
    public class WebApiContext : DbContext
    {
        public DbSet<ValuesModel> Values { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Values.db");
        }
    }
}
