﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _13638_WEBAPI.Data;

#nullable disable

namespace _13638_WEBAPI.Data.Migrations
{
    [DbContext(typeof(GeneralDBContext))]
    partial class GeneralDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_13638_WEBAPI.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("GradeNum")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("_13638_WEBAPI.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GradeID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GradeID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("_13638_WEBAPI.Models.Student", b =>
                {
                    b.HasOne("_13638_WEBAPI.Models.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeID");

                    b.Navigation("Grade");
                });
#pragma warning restore 612, 618
        }
    }
}
