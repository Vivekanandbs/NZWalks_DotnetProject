﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksContext))]
    [Migration("20240709045415_AddingForeignKeyAndRoleTables")]
    partial class AddingForeignKeyAndRoleTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Entities.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region_image_url");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_modified");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("NZWalks.API.Entities.RolePrivilage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_modified");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<string>("RolePrivilageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_privilage_name");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePrivilages");
                });

            modelBuilder.Entity("NZWalks.API.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_modified");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_salt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnName("user_type");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<Guid?>("DifficultyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("difficulty_id");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float")
                        .HasColumnName("length_in_km");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("region_id");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("walk_image_url");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Entities.RolePrivilage", b =>
                {
                    b.HasOne("NZWalks.API.Entities.Role", "Role")
                        .WithMany("RolePrivilage")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Entities.Difficulty", "Difficulty")
                        .WithMany("Walk")
                        .HasForeignKey("DifficultyId");

                    b.HasOne("NZWalks.API.Entities.Region", "Region")
                        .WithMany("Walk")
                        .HasForeignKey("RegionId");

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Difficulty", b =>
                {
                    b.Navigation("Walk");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Region", b =>
                {
                    b.Navigation("Walk");
                });

            modelBuilder.Entity("NZWalks.API.Entities.Role", b =>
                {
                    b.Navigation("RolePrivilage");
                });
#pragma warning restore 612, 618
        }
    }
}
