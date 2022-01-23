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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer_Product>()
                .HasOne(o => o.Offer)
                .WithMany(op => op.Offer_Products)
                .HasForeignKey(oi => oi.OfferId);

            modelBuilder.Entity<Offer_Product>()
    .HasOne(o => o.Product)
    .WithMany(op => op.Offer_Products)
    .HasForeignKey(oi => oi.ProductId);
        }

        //public DbSet<SkiJumper> SkiJumper { get; set; } //dla pozostalych klas to samo

        //public DbSet<Coach> Coach { get; set; }

        public DbSet<Offer> Offer { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Offer_Product> Offer_Products {get;set;}
    }

}
