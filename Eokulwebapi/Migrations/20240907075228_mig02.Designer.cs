﻿// <auto-generated />
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
    [Migration("20240907075228_mig02")]
    partial class mig02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("Eokulwebapi.Entities.ÖnKayıtÖğrenci", b =>
                {
                    b.Navigation("öğrenci")
                        .IsRequired();
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Sınıf", b =>
                {
                    b.Navigation("Öğrenciler");
                });
#pragma warning restore 612, 618
        }
    }
}
