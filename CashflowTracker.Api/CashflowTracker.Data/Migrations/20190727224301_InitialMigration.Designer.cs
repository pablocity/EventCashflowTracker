﻿// <auto-generated />
using System;
using CashflowTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashflowTracker.Data.Migrations
{
    [DbContext(typeof(CashflowTrackerContext))]
    [Migration("20190727224301_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashflowTracker.Models.CostItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EventId");

                    b.Property<bool>("IsPaid");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("CostItems");
                });

            modelBuilder.Entity("CashflowTracker.Models.Debt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CostItemId");

                    b.Property<decimal>("DebtAmount");

                    b.Property<long>("DebtHolderId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CostItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("CashflowTracker.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EventDate");

                    b.Property<string>("EventName");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CashflowTracker.Models.EventUser", b =>
                {
                    b.Property<long>("EventId");

                    b.Property<long>("UserId");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUsers");
                });

            modelBuilder.Entity("CashflowTracker.Models.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("CostItemId");

                    b.Property<bool>("IsApproved");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CostItemId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CashflowTracker.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RoleTypeId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CashflowTracker.Models.RoleType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleTypes");
                });

            modelBuilder.Entity("CashflowTracker.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("UniqueIdentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CashflowTracker.Models.CostItem", b =>
                {
                    b.HasOne("CashflowTracker.Models.Event", "Event")
                        .WithMany("CostItems")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashflowTracker.Models.Debt", b =>
                {
                    b.HasOne("CashflowTracker.Models.CostItem", "CostItem")
                        .WithMany()
                        .HasForeignKey("CostItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashflowTracker.Models.User")
                        .WithMany("Debts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashflowTracker.Models.EventUser", b =>
                {
                    b.HasOne("CashflowTracker.Models.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashflowTracker.Models.User", "User")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashflowTracker.Models.Payment", b =>
                {
                    b.HasOne("CashflowTracker.Models.CostItem", "CostItem")
                        .WithMany("Payments")
                        .HasForeignKey("CostItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashflowTracker.Models.Role", b =>
                {
                    b.HasOne("CashflowTracker.Models.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashflowTracker.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
