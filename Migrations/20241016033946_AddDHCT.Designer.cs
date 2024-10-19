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
    [Migration("20241016033946_AddDHCT")]
    partial class AddDHCT
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DoAn_API.Data.DonHang", b =>
                {
                    b.Property<Guid>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Hoten")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NgayDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("current_date()");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TinhTrangDonHang")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.DonHangChiTiet", b =>
                {
                    b.Property<Guid>("MaDonHang")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<double>("DonGia")
                        .HasColumnType("double");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang", "Id");

                    b.HasIndex("Id");

                    b.ToTable("DonHangChiTiet", (string)null);
                });

            modelBuilder.Entity("DoAn_API.Data.Type", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdType"));

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdType");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("DoAn_API.Data.product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdType");

                    b.ToTable("product");
                });

            modelBuilder.Entity("DoAn_API.Data.DonHangChiTiet", b =>
                {
                    b.HasOne("DoAn_API.Data.product", "product")
                        .WithMany("DonHangChiTiets")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DonHangChiTiet_HangHoa");

                    b.HasOne("DoAn_API.Data.DonHang", "DonHang")
                        .WithMany("DonHangChiTiets")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DonHangChiTiet_DonHang");

                    b.Navigation("DonHang");

                    b.Navigation("product");
                });

            modelBuilder.Entity("DoAn_API.Data.product", b =>
                {
                    b.HasOne("DoAn_API.Data.Type", "Type")
                        .WithMany()
                        .HasForeignKey("IdType");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DoAn_API.Data.DonHang", b =>
                {
                    b.Navigation("DonHangChiTiets");
                });

            modelBuilder.Entity("DoAn_API.Data.product", b =>
                {
                    b.Navigation("DonHangChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}