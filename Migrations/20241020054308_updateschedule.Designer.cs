﻿// <auto-generated />
using System;
using DoAn_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAn_API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241020054308_updateschedule")]
    partial class updateschedule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DoAn_API.Data.Appointment", b =>
                {
                    b.Property<int>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("appointmentId"));

                    b.Property<string>("appointmentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("appointmentStatus")
                        .HasColumnType("int");

                    b.Property<string>("appointmentTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("scheduleId")
                        .HasColumnType("int");

                    b.HasKey("appointmentId");

                    b.HasIndex("doctorId");

                    b.HasIndex("patientId");

                    b.HasIndex("scheduleId");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("roleId"));

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("roleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Schedule", b =>
                {
                    b.Property<int>("scheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("scheduleId");

                    b.ToTable("Schedule", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Specialization", b =>
                {
                    b.Property<int>("specializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("specializationId"));

                    b.Property<string>("specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("specializationId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("DoAn_API.Data.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("userId");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DoctorSpecialization", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("specializationId")
                        .HasColumnType("int");

                    b.HasKey("userId", "specializationId");

                    b.HasIndex("specializationId");

                    b.ToTable("DoctorSpecialization", (string)null);
                });

            modelBuilder.Entity("PatientRole", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("userId", "roleId");

                    b.HasIndex("roleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Doctor", b =>
                {
                    b.HasBaseType("DoAn_API.Data.User");

                    b.Property<double>("bookingFee")
                        .HasColumnType("double");

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doctorAbout")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("experience")
                        .HasColumnType("double");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Patient", b =>
                {
                    b.HasBaseType("DoAn_API.Data.User");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Appointment", b =>
                {
                    b.HasOne("DoAn_API.Data.Doctor", "doctor")
                        .WithMany("appointments")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAn_API.Data.Patient", "patient")
                        .WithMany("appointments")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAn_API.Data.Schedule", "schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("patient");

                    b.Navigation("schedule");
                });

            modelBuilder.Entity("DoAn_API.Data.Schedule", b =>
                {
                    b.HasOne("DoAn_API.Data.Doctor", "doctor")
                        .WithMany("schedules")
                        .HasForeignKey("scheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");
                });

            modelBuilder.Entity("DoctorSpecialization", b =>
                {
                    b.HasOne("DoAn_API.Data.Specialization", null)
                        .WithMany()
                        .HasForeignKey("specializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAn_API.Data.Doctor", null)
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientRole", b =>
                {
                    b.HasOne("DoAn_API.Data.Role", null)
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAn_API.Data.User", null)
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAn_API.Data.Doctor", b =>
                {
                    b.HasOne("DoAn_API.Data.User", null)
                        .WithOne()
                        .HasForeignKey("DoAn_API.Data.Doctor", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAn_API.Data.Patient", b =>
                {
                    b.HasOne("DoAn_API.Data.User", null)
                        .WithOne()
                        .HasForeignKey("DoAn_API.Data.Patient", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAn_API.Data.Doctor", b =>
                {
                    b.Navigation("appointments");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("DoAn_API.Data.Patient", b =>
                {
                    b.Navigation("appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
