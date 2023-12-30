﻿// <auto-generated />
using System;
using LivrariaOnline.Backend.Infra.Database.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LivrariaOnline.Backend.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231230015754_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFEmailConfirmationEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ConfirmedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Expired")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("GeneratedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GenerationType")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("character varying(21)");

                    b.Property<DateTime>("ValidTill")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("UserId");

                    b.ToTable("UserEmailConfirmation");
                });

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserAddressEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("AddressId")
                        .HasColumnType("character varying(21)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("character varying(90)");

                    b.Property<int>("EmailStatus")
                        .HasColumnType("integer");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("RolesJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFEmailConfirmationEntity", b =>
                {
                    b.HasOne("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserEntity", b =>
                {
                    b.HasOne("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserAddressEntity", "Address")
                        .WithOne("User")
                        .HasForeignKey("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserEntity", "AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("LivrariaOnline.Backend.Infra.Database.EF.Entities.EFUserAddressEntity", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
