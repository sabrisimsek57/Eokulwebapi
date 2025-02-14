﻿// <auto-generated />
using System;
using Eokulwebapi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eokulwebapi.Migrations
{
    [DbContext(typeof(OkulContext))]
    [Migration("20240907203244_mig04")]
    partial class mig04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eokulwebapi.Entities.Ders", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersId"), 1L, 1);

                    b.Property<string>("DersAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DersKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HD_Sırası")
                        .HasColumnType("int");

                    b.Property<int?>("ÖğretmenId")
                        .HasColumnType("int");

                    b.HasKey("DersId");

                    b.HasIndex("ÖğretmenId");

                    b.ToTable("Ders");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.DersProgramı", b =>
                {
                    b.Property<int>("DersProgramıId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersProgramıId"), 1L, 1);

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<string>("Gün")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KaçıncıDers")
                        .HasColumnType("int");

                    b.Property<int>("SınıfId")
                        .HasColumnType("int");

                    b.HasKey("DersProgramıId");

                    b.HasIndex("DersId");

                    b.HasIndex("SınıfId");

                    b.ToTable("dersProgramıs");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğrenci", b =>
                {
                    b.Property<int>("ÖğrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ÖğrenciId"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevamDurumu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OkulNumarası")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SınıfId")
                        .HasColumnType("int");

                    b.Property<int>("ÖnKayıtId")
                        .HasColumnType("int");

                    b.Property<string>("Şube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ÖğrenciId");

                    b.HasIndex("SınıfId");

                    b.HasIndex("ÖnKayıtId")
                        .IsUnique();

                    b.ToTable("Öğrencis");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğretmen", b =>
                {
                    b.Property<int>("ÖğretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ÖğretmenId"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branş")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ÖğretmenId");

                    b.ToTable("Öğretmens");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.ÖnKayıtÖğrenci", b =>
                {
                    b.Property<int>("ÖnkayıtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ÖnkayıtId"), 1L, 1);

                    b.Property<string>("BitirdiğiOkul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvAdresi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvTelefonu")
                        .HasColumnType("int");

                    b.Property<double>("NotOrtalamsı")
                        .HasColumnType("float");

                    b.Property<string>("VeliAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeliSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ÖğrenciAD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ÖğrenciSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İlçe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("İşTelefonu")
                        .HasColumnType("int");

                    b.HasKey("ÖnkayıtId");

                    b.ToTable("ÖnKayıtÖğrencis");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Sınıf", b =>
                {
                    b.Property<int>("SınıfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SınıfId"), 1L, 1);

                    b.Property<string>("SınıfAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Şubesi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SınıfId");

                    b.ToTable("Sınıfs");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Ders", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Öğretmen", "Öğretmen")
                        .WithMany("Dersler")
                        .HasForeignKey("ÖğretmenId");

                    b.Navigation("Öğretmen");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.DersProgramı", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Ders", "Ders")
                        .WithMany("DersProgramları")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eokulwebapi.Entities.Sınıf", "Sınıf")
                        .WithMany("DersProgramları")
                        .HasForeignKey("SınıfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Sınıf");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğrenci", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Sınıf", "Sınıf")
                        .WithMany("Öğrenciler")
                        .HasForeignKey("SınıfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eokulwebapi.Entities.ÖnKayıtÖğrenci", "ÖnKayıt")
                        .WithOne("öğrenci")
                        .HasForeignKey("Eokulwebapi.Entities.Öğrenci", "ÖnKayıtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sınıf");

                    b.Navigation("ÖnKayıt");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Ders", b =>
                {
                    b.Navigation("DersProgramları");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğretmen", b =>
                {
                    b.Navigation("Dersler");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.ÖnKayıtÖğrenci", b =>
                {
                    b.Navigation("öğrenci")
                        .IsRequired();
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Sınıf", b =>
                {
                    b.Navigation("DersProgramları");

                    b.Navigation("Öğrenciler");
                });
#pragma warning restore 612, 618
        }
    }
}
