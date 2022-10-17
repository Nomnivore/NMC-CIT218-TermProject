﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Data;

#nullable disable

namespace TermProject.Migrations
{
    [DbContext(typeof(EventsContext))]
    [Migration("20221017013335_AddGroup")]
    partial class AddGroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TermProject.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("MaxAttendees")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Come watch an awesome movie with us!",
                            EndDateTime = new DateTime(2022, 10, 22, 23, 0, 0, 0, DateTimeKind.Local),
                            Location = "The movie theater",
                            MaxAttendees = 50,
                            Name = "Movie Night",
                            StartDateTime = new DateTime(2022, 10, 22, 20, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            Description = "A 3-day event loaded with speakers, Q&A's, networking opportunities, and more! You won't want to miss this.",
                            EndDateTime = new DateTime(2022, 10, 28, 20, 0, 0, 0, DateTimeKind.Local),
                            Location = "Large conference hall in Big City",
                            Name = "CIT Conference",
                            StartDateTime = new DateTime(2022, 10, 26, 11, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("TermProject.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AllowJoin")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
