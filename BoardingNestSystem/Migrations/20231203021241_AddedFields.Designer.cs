﻿// <auto-generated />
using System;
using BoardingNestSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardingNestSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231203021241_AddedFields")]
    partial class AddedFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoardingID");

                    b.HasIndex("BedID");

                    b.ToTable("BoardingHouses");
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
#pragma warning restore 612, 618
        }
    }
}
