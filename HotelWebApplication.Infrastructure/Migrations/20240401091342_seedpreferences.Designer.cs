﻿// <auto-generated />
using System;
using HotelWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelWebApplication.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240401091342_seedpreferences")]
    partial class seedpreferences
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.GuestAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Guests", (string)null);
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.PreferenceAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Preferences", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Бесплатный интернет"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Кондиционер"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Ванная комната в номере"
                        },
                        new
                        {
                            Id = 4,
                            Value = "Кухня"
                        },
                        new
                        {
                            Id = 5,
                            Value = "Балкон"
                        },
                        new
                        {
                            Id = 6,
                            Value = "Общая ванная комната"
                        },
                        new
                        {
                            Id = 7,
                            Value = "Мини бар"
                        },
                        new
                        {
                            Id = 8,
                            Value = "Телевизор"
                        },
                        new
                        {
                            Id = 9,
                            Value = "Джакузи"
                        });
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.RoomAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.RoomTypeAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes", (string)null);
                });

            modelBuilder.Entity("PreferenceAggregateRoomAggregate", b =>
                {
                    b.Property<int>("PreferencesId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomsId")
                        .HasColumnType("integer");

                    b.HasKey("PreferencesId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("RoomPreference", (string)null);
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.GuestAggregate", b =>
                {
                    b.HasOne("HotelWebApplication.Domain.Entities.RoomAggregate", "RoomAggregate")
                        .WithMany("Guests")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomAggregate");
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.RoomAggregate", b =>
                {
                    b.HasOne("HotelWebApplication.Domain.Entities.RoomTypeAggregate", "RoomTypeAggregate")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomTypeAggregate");
                });

            modelBuilder.Entity("PreferenceAggregateRoomAggregate", b =>
                {
                    b.HasOne("HotelWebApplication.Domain.Entities.PreferenceAggregate", null)
                        .WithMany()
                        .HasForeignKey("PreferencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelWebApplication.Domain.Entities.RoomAggregate", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.RoomAggregate", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("HotelWebApplication.Domain.Entities.RoomTypeAggregate", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}