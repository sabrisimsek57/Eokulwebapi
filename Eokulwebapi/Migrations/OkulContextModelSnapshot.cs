﻿// <auto-generated />
using System;
using Eokulwebapi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eokulwebapi.Migrations
{
    [DbContext(typeof(OkulContext))]
    partial class OkulContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eokulwebapi.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Eokulwebapi.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("ÖğrenciId")
                        .HasColumnType("int");

                    b.Property<int?>("ÖğretmenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ÖğrenciId")
                        .IsUnique()
                        .HasFilter("[ÖğrenciId] IS NOT NULL");

                    b.HasIndex("ÖğretmenId")
                        .IsUnique()
                        .HasFilter("[ÖğretmenId] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

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

            modelBuilder.Entity("Eokulwebapi.Entities.Devamsızlık", b =>
                {
                    b.Property<int>("DevamsızlıkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DevamsızlıkId"), 1L, 1);

                    b.Property<bool>("NöbetçiMi")
                        .HasColumnType("bit");

                    b.Property<bool>("RaporluMu")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("ÖğrenciId")
                        .HasColumnType("int");

                    b.HasKey("DevamsızlıkId");

                    b.HasIndex("ÖğrenciId");

                    b.ToTable("Devamsızlıks");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.İlişkisiKesilen", b =>
                {
                    b.Property<int>("İlişkisiKesilenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("İlişkisiKesilenId"), 1L, 1);

                    b.Property<string>("Gerekçe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ÖğrenciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("İlişkisiKesilmeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("İlişkisiKesilenId");

                    b.HasIndex("ÖğrenciId")
                        .IsUnique();

                    b.ToTable("İlişkisiKesilens");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Not", b =>
                {
                    b.Property<int>("NotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotId"), 1L, 1);

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("NotDeğeri")
                        .HasColumnType("int");

                    b.Property<int>("ÖğrenciId")
                        .HasColumnType("int");

                    b.HasKey("NotId");

                    b.HasIndex("DersId");

                    b.HasIndex("ÖğrenciId");

                    b.ToTable("Nots");
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

                    b.Property<string>("Görevi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sıra")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Eokulwebapi.Entities.AppUser", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Öğrenci", "Öğrenci")
                        .WithOne("AppUser")
                        .HasForeignKey("Eokulwebapi.Entities.AppUser", "ÖğrenciId");

                    b.HasOne("Eokulwebapi.Entities.Öğretmen", "Öğretmen")
                        .WithOne("AppUser")
                        .HasForeignKey("Eokulwebapi.Entities.AppUser", "ÖğretmenId");

                    b.Navigation("Öğrenci");

                    b.Navigation("Öğretmen");
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

            modelBuilder.Entity("Eokulwebapi.Entities.Devamsızlık", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Öğrenci", "Öğrenci")
                        .WithMany("Devamsızlıklar")
                        .HasForeignKey("ÖğrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Öğrenci");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.İlişkisiKesilen", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Öğrenci", "Öğrenci")
                        .WithOne("İlişkisiKesilen")
                        .HasForeignKey("Eokulwebapi.Entities.İlişkisiKesilen", "ÖğrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Öğrenci");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Not", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.Ders", "Ders")
                        .WithMany()
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eokulwebapi.Entities.Öğrenci", "Öğrenci")
                        .WithMany()
                        .HasForeignKey("ÖğrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Öğrenci");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eokulwebapi.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Eokulwebapi.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Ders", b =>
                {
                    b.Navigation("DersProgramları");
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğrenci", b =>
                {
                    b.Navigation("AppUser")
                        .IsRequired();

                    b.Navigation("Devamsızlıklar");

                    b.Navigation("İlişkisiKesilen")
                        .IsRequired();
                });

            modelBuilder.Entity("Eokulwebapi.Entities.Öğretmen", b =>
                {
                    b.Navigation("AppUser")
                        .IsRequired();

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
