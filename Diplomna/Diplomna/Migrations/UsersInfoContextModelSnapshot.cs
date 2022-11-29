﻿// <auto-generated />
using Diplomna.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplomna.Migrations
{
    [DbContext(typeof(UsersInfoContext))]
    partial class UsersInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Diplomna.Entities.Courses", b =>
                {
                    b.Property<string>("Courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CoursName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Usersid")
                        .HasColumnType("text");

                    b.HasKey("Courseid");

                    b.HasIndex("Usersid");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Diplomna.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Usersid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Usersid");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "admin",
                            Usersid = "10"
                        });
                });

            modelBuilder.Entity("Diplomna.Entities.Users", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = "10",
                            email = "admin@gmail.com",
                            name = "Admin",
                            password = "1234"
                        });
                });

            modelBuilder.Entity("Diplomna.Entities.Videos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VideosCount")
                        .HasColumnType("integer");

                    b.Property<string>("courseNameCourseid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("courseNameCourseid");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("Diplomna.Entities.Courses", b =>
                {
                    b.HasOne("Diplomna.Entities.Users", null)
                        .WithMany("Corses")
                        .HasForeignKey("Usersid");
                });

            modelBuilder.Entity("Diplomna.Entities.Roles", b =>
                {
                    b.HasOne("Diplomna.Entities.Users", null)
                        .WithMany("Roles")
                        .HasForeignKey("Usersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplomna.Entities.Videos", b =>
                {
                    b.HasOne("Diplomna.Entities.Courses", "courseName")
                        .WithMany("Videos")
                        .HasForeignKey("courseNameCourseid");

                    b.Navigation("courseName");
                });

            modelBuilder.Entity("Diplomna.Entities.Courses", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("Diplomna.Entities.Users", b =>
                {
                    b.Navigation("Corses");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}