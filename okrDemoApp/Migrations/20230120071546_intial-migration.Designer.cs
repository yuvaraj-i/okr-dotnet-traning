﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using okrDemoApp.DBContex;

#nullable disable

namespace okrDemoApp.Migrations
{
    [DbContext(typeof(AppDbContex))]
    [Migration("20230120071546_intial-migration")]
    partial class intialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("okrDemoApp.Models.AccomplishmentModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.Property<DateTime>("accomplishedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("accomplishmentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("accomplishmentTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("accomplishmentType")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("accomplishments");
                });

            modelBuilder.Entity("okrDemoApp.Models.ActivityLog", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("acctivityAction")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("topicType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("activityLogs");
                });

            modelBuilder.Entity("okrDemoApp.Models.Skill", b =>
                {
                    b.Property<int>("skillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("skillDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("skillId");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("okrDemoApp.Models.SkillSetMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.HasIndex("skillId");

                    b.ToTable("skillSetMappings");
                });

            modelBuilder.Entity("okrDemoApp.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("okrDemoApp.Models.AccomplishmentModel", b =>
                {
                    b.HasOne("okrDemoApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("okrDemoApp.Models.ActivityLog", b =>
                {
                    b.HasOne("okrDemoApp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("okrDemoApp.Models.SkillSetMapping", b =>
                {
                    b.HasOne("okrDemoApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("okrDemoApp.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
