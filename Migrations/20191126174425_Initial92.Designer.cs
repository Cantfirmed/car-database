﻿// <auto-generated />
using CarDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDatabase.Migrations
{
    [DbContext(typeof(CarDbContext))]
    [Migration("20191126174425_Initial92")]
    partial class Initial92
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("CarDatabase.CarMake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("CarDatabase.CarModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarMakeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CarMakeId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("CarDatabase.Ownership", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehicleIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CarModelId");

                    b.HasIndex("PersonId");

                    b.HasIndex("VehicleIdentificationNumber")
                        .IsUnique();

                    b.ToTable("Ownerships");
                });

            modelBuilder.Entity("CarDatabase.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("CarDatabase.CarModel", b =>
                {
                    b.HasOne("CarDatabase.CarMake", "CarMake")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarDatabase.Ownership", b =>
                {
                    b.HasOne("CarDatabase.CarModel", "CarModel")
                        .WithMany("Ownerships")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarDatabase.Person", "Person")
                        .WithMany("Ownerships")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
