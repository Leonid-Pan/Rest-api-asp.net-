using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfirstwebapi.Models.Entities;

namespace myfirstwebapi.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Common> Commons { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { 
        }
    }
}
