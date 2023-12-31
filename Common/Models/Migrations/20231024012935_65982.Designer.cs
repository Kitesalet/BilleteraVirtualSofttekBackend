﻿// <auto-generated />
using System;
using IntegradorSofttekImanol.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231024012935_65982")]
    partial class _65982
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("account_balance");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("account_type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseAccount");
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("client_email");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("client_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("client_password");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 306, DateTimeKind.Local).AddTicks(1195),
                            Email = "1@1.com",
                            Name = "random",
                            Password = "389aec82d3ce947fd1ba75e52b2b49d5e7ffcebe7d8e059db3bb8c49594d0bbf"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 306, DateTimeKind.Local).AddTicks(1324),
                            Email = "2@2.com",
                            Name = "random",
                            Password = "389aec82d3ce947fd1ba75e52b2b49d5e7ffcebe7d8e059db3bb8c49594d0bbf"
                        });
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<int?>("DestinationAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int?>("SourceAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("SourceAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Accounts.CryptoAccount", b =>
                {
                    b.HasBaseType("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount");

                    b.Property<Guid>("UUID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accound_uuid");

                    b.ToTable("Accounts");

                    b.HasDiscriminator().HasValue("CryptoAccount");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Balance = 1000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 311, DateTimeKind.Local).AddTicks(1151),
                            Type = 3,
                            UUID = new Guid("c890eb9a-7c2b-4b1f-8c4d-9d7d3151597a")
                        },
                        new
                        {
                            Id = 6,
                            Balance = 2000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 311, DateTimeKind.Local).AddTicks(1156),
                            Type = 3,
                            UUID = new Guid("66eafada-15e6-4f94-b3da-c065b7f1ea35")
                        });
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Accounts.DollarAccount", b =>
                {
                    b.HasBaseType("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount");

                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("account_number");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("account_alias");

                    b.Property<int>("CBU")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("account_cbu");

                    b.ToTable("Accounts");

                    b.HasDiscriminator().HasValue("DollarAccount");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Balance = 2000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 310, DateTimeKind.Local).AddTicks(280),
                            Type = 2,
                            AccountNumber = 2,
                            Alias = "Trial.Hamen.Ryu",
                            CBU = 234567891
                        },
                        new
                        {
                            Id = 5,
                            Balance = 4000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 310, DateTimeKind.Local).AddTicks(284),
                            Type = 2,
                            AccountNumber = 56564345,
                            Alias = "Accordion.Lupin.Extract",
                            CBU = 654334523
                        });
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Accounts.PesoAccount", b =>
                {
                    b.HasBaseType("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount");

                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("account_number");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("account_alias");

                    b.Property<int>("CBU")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("account_cbu");

                    b.ToTable("Accounts");

                    b.HasDiscriminator().HasValue("PesoAccount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 1000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 308, DateTimeKind.Local).AddTicks(3371),
                            Type = 1,
                            AccountNumber = 134567544,
                            Alias = "Rock.Spy.Pink",
                            CBU = 123456789
                        },
                        new
                        {
                            Id = 4,
                            Balance = 2000m,
                            ClientId = 1,
                            CreatedDate = new DateTime(2023, 10, 23, 22, 29, 35, 308, DateTimeKind.Local).AddTicks(3376),
                            Type = 1,
                            AccountNumber = 434567346,
                            Alias = "Sword.Javelin.Coconut",
                            CBU = 532456234
                        });
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount", b =>
                {
                    b.HasOne("BilleteraVirtualSofttekBack.Models.Entities.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Transaction", b =>
                {
                    b.HasOne("BilleteraVirtualSofttekBack.Models.Entities.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount", "DestinationAccount")
                        .WithMany()
                        .HasForeignKey("DestinationAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BilleteraVirtualSofttekBack.Models.Entities.BaseAccount", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Client");

                    b.Navigation("DestinationAccount");

                    b.Navigation("SourceAccount");
                });

            modelBuilder.Entity("BilleteraVirtualSofttekBack.Models.Entities.Client", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
