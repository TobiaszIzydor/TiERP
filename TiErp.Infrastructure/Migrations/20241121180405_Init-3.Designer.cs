﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiErp.Infrastructure.Persistence;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    [DbContext(typeof(TiErpDbContext))]
    [Migration("20241121180405_Init-3")]
    partial class Init3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TiErp.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.EmployeePayroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BaseSallary")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("numeric");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("PayPeriodEnd")
                        .HasColumnType("date");

                    b.Property<DateOnly>("PayPeriodStart")
                        .HasColumnType("date");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeePayroll");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.Employee", b =>
                {
                    b.OwnsOne("TiErp.Domain.Entities.EmployeeContactInfo", "ContactInfo", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("EmergencyPhone")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner("Employee")
                                .HasForeignKey("EmployeeId");

                            b1.Navigation("Employee");
                        });

                    b.Navigation("ContactInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("TiErp.Domain.Entities.EmployeePayroll", b =>
                {
                    b.HasOne("TiErp.Domain.Entities.Employee", "Employee")
                        .WithOne("Payroll")
                        .HasForeignKey("TiErp.Domain.Entities.EmployeePayroll", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.User", b =>
                {
                    b.HasOne("TiErp.Domain.Entities.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("TiErp.Domain.Entities.User", "EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("TiErp.Domain.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TiErp.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Payroll")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("TiErp.Domain.Entities.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}