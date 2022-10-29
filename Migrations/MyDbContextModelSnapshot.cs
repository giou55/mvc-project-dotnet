﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc_project_dotnet.Models;

#nullable disable

namespace mvc_project_dotnet.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Author", b =>
                {
                    b.Property<int?>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Books")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("AuthorID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("mvc_project_dotnet.Models.Book", b =>
                {
                    b.Property<int?>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedTimestamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
