﻿// <auto-generated />
using System;
using ApiPractice.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPractice.Infrastructure.Migrations
{
    [DbContext(typeof(UniversityManagementContext))]
    partial class UniversityManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPractice.Domain.Entities.Club", b =>
                {
                    b.Property<string>("ClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("ClubStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.ClubRegistration", b =>
                {
                    b.Property<int>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No"));

                    b.Property<string>("ClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("No");

                    b.HasIndex("ClubId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClubRegistrations");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.Major", b =>
                {
                    b.Property<string>("MajorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("MajorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("MajorStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("MajorId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.StudentMajor", b =>
                {
                    b.Property<int>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No"));

                    b.Property<string>("MajorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("No");

                    b.HasIndex("MajorId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentMajors");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.ClubRegistration", b =>
                {
                    b.HasOne("ApiPractice.Domain.Entities.Club", "Club")
                        .WithMany("ClubRegistrations")
                        .HasForeignKey("ClubId");

                    b.HasOne("ApiPractice.Domain.Entities.Student", "Student")
                        .WithMany("ClubRegistrations")
                        .HasForeignKey("StudentId");

                    b.Navigation("Club");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.StudentMajor", b =>
                {
                    b.HasOne("ApiPractice.Domain.Entities.Major", "Major")
                        .WithMany("StudentMajors")
                        .HasForeignKey("MajorId");

                    b.HasOne("ApiPractice.Domain.Entities.Student", "Student")
                        .WithMany("StudentMajors")
                        .HasForeignKey("StudentId");

                    b.Navigation("Major");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.Club", b =>
                {
                    b.Navigation("ClubRegistrations");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.Major", b =>
                {
                    b.Navigation("StudentMajors");
                });

            modelBuilder.Entity("ApiPractice.Domain.Entities.Student", b =>
                {
                    b.Navigation("ClubRegistrations");

                    b.Navigation("StudentMajors");
                });
#pragma warning restore 612, 618
        }
    }
}
