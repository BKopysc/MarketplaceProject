// <auto-generated />
using System;
using Marketplace.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marketplace.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220123164445_offer_start")]
    partial class offer_start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Marketplace.Core.Domain.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("OfferId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("OfferId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Offer_Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("ProductId");

                    b.ToTable("Offer_Products");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("StatusType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Comment", b =>
                {
                    b.HasOne("Marketplace.Core.Domain.Offer", "Offer")
                        .WithMany("Comments")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Contact", b =>
                {
                    b.HasOne("Marketplace.Core.Domain.Profile", "Profile")
                        .WithOne("Contact")
                        .HasForeignKey("Marketplace.Core.Domain.Contact", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Offer", b =>
                {
                    b.HasOne("Marketplace.Core.Domain.Profile", "Profile")
                        .WithMany("Offers")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Offer_Product", b =>
                {
                    b.HasOne("Marketplace.Core.Domain.Offer", "Offer")
                        .WithMany("Offer_Products")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.Core.Domain.Product", "Product")
                        .WithMany("Offer_Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Product", b =>
                {
                    b.HasOne("Marketplace.Core.Domain.Profile", "Profile")
                        .WithMany("Products")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Offer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Offer_Products");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Product", b =>
                {
                    b.Navigation("Offer_Products");
                });

            modelBuilder.Entity("Marketplace.Core.Domain.Profile", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("Offers");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
