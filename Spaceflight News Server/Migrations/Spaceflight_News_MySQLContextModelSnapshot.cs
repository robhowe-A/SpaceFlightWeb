﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spaceflight_News_Server.Data;

#nullable disable

namespace Spaceflight_News_Server.Migrations
{
    [DbContext(typeof(Spaceflight_News_MySQLContext))]
    partial class Spaceflight_News_MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Spaceflight_News_Server.Models.APOD", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apodtitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "explanation");

                    b.Property<string>("hdurl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "url");

                    b.Property<string>("media")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "media_type");

                    b.HasKey("id");

                    b.ToTable("APOD");
                });

            modelBuilder.Entity("Spaceflight_News_Server.Models.Article", b =>
                {
                    b.Property<int>("articleNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("articleNum"));

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "publishedAt");

                    b.Property<bool>("featured")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("textURL")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "imageUrl");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("articleNum");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Spaceflight_News_Server.Models.Launch", b =>
                {
                    b.Property<int>("launchNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("launchNum"));

                    b.Property<int?>("articleNum")
                        .HasColumnType("int");

                    b.Property<string>("id")
                        .HasColumnType("longtext");

                    b.Property<string>("provider")
                        .HasColumnType("longtext");

                    b.HasKey("launchNum");

                    b.HasIndex("articleNum");

                    b.ToTable("Launch");
                });

            modelBuilder.Entity("Spaceflight_News_Server.Models.Launch", b =>
                {
                    b.HasOne("Spaceflight_News_Server.Models.Article", null)
                        .WithMany("launches")
                        .HasForeignKey("articleNum");
                });

            modelBuilder.Entity("Spaceflight_News_Server.Models.Article", b =>
                {
                    b.Navigation("launches");
                });
#pragma warning restore 612, 618
        }
    }
}