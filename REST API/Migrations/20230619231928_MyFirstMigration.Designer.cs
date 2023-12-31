﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_API.Data;

#nullable disable

namespace REST_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230619231928_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("REST_API.Models.Dzīvoklis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Dzivojama_platiba")
                        .HasColumnType("float");

                    b.Property<int>("Iedzivotaju_skaits")
                        .HasColumnType("int");

                    b.Property<int>("Istabu_skaits")
                        .HasColumnType("int");

                    b.Property<int>("MājaId")
                        .HasColumnType("int");

                    b.Property<int>("Numurs")
                        .HasColumnType("int");

                    b.Property<double>("Pilna_platiba")
                        .HasColumnType("float");

                    b.Property<int>("Stavs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MājaId");

                    b.ToTable("Dzīvokļi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dzivojama_platiba = 60.509999999999998,
                            Iedzivotaju_skaits = 4,
                            Istabu_skaits = 4,
                            MājaId = 1,
                            Numurs = 21,
                            Pilna_platiba = 65.209999999999994,
                            Stavs = 6
                        },
                        new
                        {
                            Id = 2,
                            Dzivojama_platiba = 50.540999999999997,
                            Iedzivotaju_skaits = 4,
                            Istabu_skaits = 4,
                            MājaId = 1,
                            Numurs = 4,
                            Pilna_platiba = 52.109999999999999,
                            Stavs = 1
                        },
                        new
                        {
                            Id = 3,
                            Dzivojama_platiba = 44.43,
                            Iedzivotaju_skaits = 4,
                            Istabu_skaits = 3,
                            MājaId = 1,
                            Numurs = 32,
                            Pilna_platiba = 47.439999999999998,
                            Stavs = 2
                        },
                        new
                        {
                            Id = 4,
                            Dzivojama_platiba = 29.100000000000001,
                            Iedzivotaju_skaits = 2,
                            Istabu_skaits = 2,
                            MājaId = 2,
                            Numurs = 8,
                            Pilna_platiba = 31.199999999999999,
                            Stavs = 4
                        },
                        new
                        {
                            Id = 5,
                            Dzivojama_platiba = 24.399999999999999,
                            Iedzivotaju_skaits = 1,
                            Istabu_skaits = 1,
                            MājaId = 2,
                            Numurs = 16,
                            Pilna_platiba = 25.210000000000001,
                            Stavs = 9
                        });
                });

            modelBuilder.Entity("REST_API.Models.IedzīvotājiDzīvokļi", b =>
                {
                    b.Property<int>("IedzivotajaID")
                        .HasColumnType("int");

                    b.Property<int>("DzivoklaID")
                        .HasColumnType("int");

                    b.HasKey("IedzivotajaID", "DzivoklaID");

                    b.HasIndex("DzivoklaID");

                    b.ToTable("IedzīvotājiDzīvokļi");

                    b.HasData(
                        new
                        {
                            IedzivotajaID = 1,
                            DzivoklaID = 1
                        },
                        new
                        {
                            IedzivotajaID = 3,
                            DzivoklaID = 1
                        },
                        new
                        {
                            IedzivotajaID = 3,
                            DzivoklaID = 2
                        },
                        new
                        {
                            IedzivotajaID = 4,
                            DzivoklaID = 3
                        },
                        new
                        {
                            IedzivotajaID = 3,
                            DzivoklaID = 3
                        },
                        new
                        {
                            IedzivotajaID = 1,
                            DzivoklaID = 4
                        },
                        new
                        {
                            IedzivotajaID = 2,
                            DzivoklaID = 4
                        },
                        new
                        {
                            IedzivotajaID = 4,
                            DzivoklaID = 5
                        });
                });

            modelBuilder.Entity("REST_API.Models.Iedzīvotājs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dzimsanas_datums")
                        .HasColumnType("datetime2");

                    b.Property<string>("Epasts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Personas_kods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefons")
                        .HasColumnType("int");

                    b.Property<string>("Uzvards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Iedzīvotāji");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dzimsanas_datums = new DateTime(1991, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Epasts = "bob@inbox.lv",
                            IsOwner = false,
                            Personas_kods = "12412-220191",
                            Telefons = 22132451,
                            Uzvards = "Bērzins",
                            Vards = "Jānis"
                        },
                        new
                        {
                            Id = 2,
                            Dzimsanas_datums = new DateTime(1992, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Epasts = "testers@gmail.com",
                            IsOwner = false,
                            Personas_kods = "12345-230292",
                            Telefons = 24371234,
                            Uzvards = "Zveja",
                            Vards = "Andris"
                        },
                        new
                        {
                            Id = 3,
                            Dzimsanas_datums = new DateTime(1999, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Epasts = "programmetajs@inbox.lv",
                            IsOwner = false,
                            Personas_kods = "58214-020599",
                            Telefons = 24352357,
                            Uzvards = "Liepa",
                            Vards = "Anna"
                        },
                        new
                        {
                            Id = 4,
                            Dzimsanas_datums = new DateTime(1981, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Epasts = "epastsepasts@inbox.lv",
                            IsOwner = false,
                            Personas_kods = "14561-111181",
                            Telefons = 27545345,
                            Uzvards = "Modre",
                            Vards = "Marija"
                        });
                });

            modelBuilder.Entity("REST_API.Models.Māja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Iela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numurs")
                        .HasColumnType("int");

                    b.Property<string>("Pasta_indekss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pilseta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valsts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mājas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Iela = "Ganibu",
                            Numurs = 21,
                            Pasta_indekss = "LV3007",
                            Pilseta = "Riga",
                            Valsts = "Latvija"
                        },
                        new
                        {
                            Id = 2,
                            Iela = "Zvejnieku",
                            Numurs = 30,
                            Pasta_indekss = "LV3011",
                            Pilseta = "Jelgava",
                            Valsts = "Latvija"
                        });
                });

            modelBuilder.Entity("REST_API.Models.Dzīvoklis", b =>
                {
                    b.HasOne("REST_API.Models.Māja", "Māja")
                        .WithMany("Dzīvokļi")
                        .HasForeignKey("MājaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Māja");
                });

            modelBuilder.Entity("REST_API.Models.IedzīvotājiDzīvokļi", b =>
                {
                    b.HasOne("REST_API.Models.Dzīvoklis", "Dzīvoklis")
                        .WithMany("IedzīvotājiDzīvokļi")
                        .HasForeignKey("DzivoklaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REST_API.Models.Iedzīvotājs", "Iedzīvotājs")
                        .WithMany("IedzīvotājiDzīvokļi")
                        .HasForeignKey("IedzivotajaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dzīvoklis");

                    b.Navigation("Iedzīvotājs");
                });

            modelBuilder.Entity("REST_API.Models.Dzīvoklis", b =>
                {
                    b.Navigation("IedzīvotājiDzīvokļi");
                });

            modelBuilder.Entity("REST_API.Models.Iedzīvotājs", b =>
                {
                    b.Navigation("IedzīvotājiDzīvokļi");
                });

            modelBuilder.Entity("REST_API.Models.Māja", b =>
                {
                    b.Navigation("Dzīvokļi");
                });
#pragma warning restore 612, 618
        }
    }
}
