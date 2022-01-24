using Marketplace.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Offer_Product>()
                .HasOne(o => o.Offer)
                .WithMany(op => op.Offer_Products)
                .HasForeignKey(oi => oi.OfferId);

            modelBuilder.Entity<Offer_Product>()
            .HasOne(o => o.Product)
            .WithMany(op => op.Offer_Products)
            .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(us => us.Profile)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<Profile>(us => us.UserId);
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
