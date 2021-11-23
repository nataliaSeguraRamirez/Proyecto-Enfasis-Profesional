﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tutorias.Data;

#nullable disable

namespace Tutorias.Migrations
{
    [DbContext(typeof(TutorshipContext))]
    [Migration("20211123211641_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tutorias.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.Tutor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<float?>("AverageScore")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FacebookLink")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("InstagramLink")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TwitterLink")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Tutor", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.TutorCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TutorID");

                    b.ToTable("TutorCategory", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.Tutorship", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Score")
                        .HasColumnType("real");

                    b.Property<bool>("Sent")
                        .HasColumnType("bit");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TutorID");

                    b.ToTable("Tutorship", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.TutorSubject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TutorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TutorID");

                    b.ToTable("TutorSubject", (string)null);
                });

            modelBuilder.Entity("Tutorias.Models.Subject", b =>
                {
                    b.HasOne("Tutorias.Models.Category", null)
                        .WithMany("Subjects")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("Tutorias.Models.TutorCategory", b =>
                {
                    b.HasOne("Tutorias.Models.Category", null)
                        .WithMany("TutorCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutorias.Models.Tutor", null)
                        .WithMany("TutorCategories")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutorias.Models.Tutorship", b =>
                {
                    b.HasOne("Tutorias.Models.Student", null)
                        .WithMany("Tutorships")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutorias.Models.Tutor", null)
                        .WithMany("Tutorships")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutorias.Models.TutorSubject", b =>
                {
                    b.HasOne("Tutorias.Models.Subject", null)
                        .WithMany("TutorSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutorias.Models.Tutor", null)
                        .WithMany("TutorSubjects")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutorias.Models.Category", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("TutorCategories");
                });

            modelBuilder.Entity("Tutorias.Models.Student", b =>
                {
                    b.Navigation("Tutorships");
                });

            modelBuilder.Entity("Tutorias.Models.Subject", b =>
                {
                    b.Navigation("TutorSubjects");
                });

            modelBuilder.Entity("Tutorias.Models.Tutor", b =>
                {
                    b.Navigation("TutorCategories");

                    b.Navigation("TutorSubjects");

                    b.Navigation("Tutorships");
                });
#pragma warning restore 612, 618
        }
    }
}
