﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Savory.Models;

namespace Savory.Migrations
{
    [DbContext(typeof(SavoryContext))]
    partial class SavoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Savory.Models.Flavor", b =>
                {
                    b.Property<int>("FlavorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FlavorName");

                    b.HasKey("FlavorId");

                    b.ToTable("Flavors");
                });

            modelBuilder.Entity("Savory.Models.FlavorTreat", b =>
                {
                    b.Property<int>("FlavorTreatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlavorId");

                    b.Property<int>("TreatId");

                    b.HasKey("FlavorTreatId");

                    b.HasIndex("FlavorId");

                    b.HasIndex("TreatId");

                    b.ToTable("FlavorTreat");
                });

            modelBuilder.Entity("Savory.Models.Treat", b =>
                {
                    b.Property<int>("TreatId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TreatName");

                    b.HasKey("TreatId");

                    b.ToTable("Treats");
                });

            modelBuilder.Entity("Savory.Models.FlavorTreat", b =>
                {
                    b.HasOne("Savory.Models.Flavor", "Flavor")
                        .WithMany("Flavors")
                        .HasForeignKey("FlavorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Savory.Models.Treat", "Treat")
                        .WithMany("Flavors")
                        .HasForeignKey("TreatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}