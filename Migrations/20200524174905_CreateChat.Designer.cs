﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SupService;

namespace SupService.Migrations
{
    [DbContext(typeof(SupServiceContext))]
    [Migration("20200524174905_CreateChat")]
    partial class CreateChat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SupService.Models.Client.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrgID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrgID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SupService.Models.Message.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Sender")
                        .HasColumnType("integer");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StuffId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StuffId");

                    b.HasIndex("TicketId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SupService.Models.Organization.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SupService.Models.Project.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SupService.Models.ProjectStaffMan.ProjectStuffMan", b =>
                {
                    b.Property<Guid>("StaffId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("StaffId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectStuffMans");
                });

            modelBuilder.Entity("SupService.Models.Stuff.Stuff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("SupService.Models.Ticket.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SupService.Models.Client.Client", b =>
                {
                    b.HasOne("SupService.Models.Organization.Organization", "Organization")
                        .WithMany("Clients")
                        .HasForeignKey("OrgID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupService.Models.Message.Message", b =>
                {
                    b.HasOne("SupService.Models.Stuff.Stuff", null)
                        .WithMany("Messages")
                        .HasForeignKey("StuffId");

                    b.HasOne("SupService.Models.Ticket.Ticket", "Ticket")
                        .WithMany("Messages")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupService.Models.Project.Project", b =>
                {
                    b.HasOne("SupService.Models.Client.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupService.Models.ProjectStaffMan.ProjectStuffMan", b =>
                {
                    b.HasOne("SupService.Models.Project.Project", "Project")
                        .WithMany("Managers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupService.Models.Stuff.Stuff", "Manager")
                        .WithMany("Projects")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupService.Models.Ticket.Ticket", b =>
                {
                    b.HasOne("SupService.Models.Stuff.Stuff", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupService.Models.Project.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
