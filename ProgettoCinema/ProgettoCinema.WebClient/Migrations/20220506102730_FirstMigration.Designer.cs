﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgettoCinema.ClientWeb.Data;

#nullable disable

namespace ProgettoCinema.WebClient.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20220506102730_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProgettoCinema.Domain.Biglietto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaRoomId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaRoomId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CinemaRoomId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("FilmGenreId")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmGenreId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.GenereFilm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FilmGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GenereFilms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.SalaCinematografica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("OccupiedSeats")
                        .HasColumnType("tinyint");

                    b.Property<byte>("RoomCapacity")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmId");

                    b.ToTable("CinemaRooms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Spettatore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OverSeventyYear")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<bool>("UnderFiveYear")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Biglietto", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.SalaCinematografica", "CinemaRoom")
                        .WithMany("Tickets")
                        .HasForeignKey("CinemaRoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProgettoCinema.Domain.Spettatore", "Person")
                        .WithOne("Ticket")
                        .HasForeignKey("ProgettoCinema.Domain.Biglietto", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CinemaRoom");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Film", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.GenereFilm", "FilmGenre")
                        .WithMany("Films")
                        .HasForeignKey("FilmGenreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FilmGenre");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.SalaCinematografica", b =>
                {
                    b.HasOne("ProgettoCinema.Domain.Cinema", "Cinema")
                        .WithMany("CinemaRooms")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProgettoCinema.Domain.Film", "Film")
                        .WithMany("CinemaRooms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Cinema", b =>
                {
                    b.Navigation("CinemaRooms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Film", b =>
                {
                    b.Navigation("CinemaRooms");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.GenereFilm", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.SalaCinematografica", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ProgettoCinema.Domain.Spettatore", b =>
                {
                    b.Navigation("Ticket")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
