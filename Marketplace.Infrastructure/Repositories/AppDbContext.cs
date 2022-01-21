using Marketplace.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<SkiJumper> SkiJumper { get; set; } //dla pozostalych klas to samo

        //public DbSet<Coach> Coach { get; set; }

        public DbSet<Offer> Offer { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Product> Product { get; set; }
    }

}
