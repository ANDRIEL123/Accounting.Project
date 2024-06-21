﻿// <auto-generated />
using System;
using Accounting.Project.src.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accounting.Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240620234432_update200620242043")]
    partial class update200620242043
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Accounting.Project.src.Entities.Accounts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<long?>("MatchAccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("match_account_id");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("MatchAccountId");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Assets", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("purchase_price");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("selling_price");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("assets", (string)null);
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Notes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AssetId")
                        .HasColumnType("bigint")
                        .HasColumnName("asset_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<int>("Operation")
                        .HasColumnType("int")
                        .HasColumnName("operation");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    b.Property<int>("Signal")
                        .HasColumnType("int")
                        .HasColumnName("signal");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_amount");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("PersonId");

                    b.ToTable("notes", (string)null);
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.People", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cpf_cnpj");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("state");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("people", (string)null);
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Releases", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_amount");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("releases", (string)null);
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Accounts", b =>
                {
                    b.HasOne("Accounting.Project.src.Entities.Accounts", "MatchAccount")
                        .WithMany("MatchAccounts")
                        .HasForeignKey("MatchAccountId");

                    b.Navigation("MatchAccount");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Assets", b =>
                {
                    b.HasOne("Accounting.Project.src.Entities.Accounts", "Account")
                        .WithMany("Assets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Notes", b =>
                {
                    b.HasOne("Accounting.Project.src.Entities.Assets", "Asset")
                        .WithMany("Notes")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounting.Project.src.Entities.People", "Person")
                        .WithMany("Notes")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Releases", b =>
                {
                    b.HasOne("Accounting.Project.src.Entities.Accounts", "Account")
                        .WithMany("Releases")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Accounts", b =>
                {
                    b.Navigation("Assets");

                    b.Navigation("MatchAccounts");

                    b.Navigation("Releases");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.Assets", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Accounting.Project.src.Entities.People", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
