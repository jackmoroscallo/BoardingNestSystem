﻿// <auto-generated />
using System;
using BoardingNestSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardingNestSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardingNestSystem.Models.Bed", b =>
                {
                    b.Property<Guid>("BedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BedNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BedID");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("BoardingNestSystem.Models.BoardingHouse", b =>
                {
                    b.Property<Guid>("BoardingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BedID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasActiveReservation")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BoardingID");

                    b.HasIndex("BedID");

                    b.ToTable("BoardingHouses");
                });

            modelBuilder.Entity("BoardingNestSystem.Models.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardingHouseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientsNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationId");

                    b.HasIndex("BoardingHouseID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BoardingNestSystem.Models.BoardingHouse", b =>
                {
                    b.HasOne("BoardingNestSystem.Models.Bed", "Bed")
                        .WithMany()
                        .HasForeignKey("BedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bed");
                });

            modelBuilder.Entity("BoardingNestSystem.Models.Reservation", b =>
                {
                    b.HasOne("BoardingNestSystem.Models.BoardingHouse", "BoardingHouse")
                        .WithMany("Reservations")
                        .HasForeignKey("BoardingHouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardingHouse");
                });

            modelBuilder.Entity("BoardingNestSystem.Models.BoardingHouse", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
