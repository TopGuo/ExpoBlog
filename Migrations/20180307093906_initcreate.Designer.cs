﻿// <auto-generated />
using ExpoBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ExpoBlog.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20180307093906_initcreate")]
    partial class initcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ExpoBlog.Models.BlogRoll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AvatarId");

                    b.Property<string>("GitHubId")
                        .HasMaxLength(64);

                    b.Property<string>("NickName")
                        .HasMaxLength(64);

                    b.Property<int>("Type");

                    b.Property<string>("URL")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("GitHubId");

                    b.ToTable("BlogRolls");
                });

            modelBuilder.Entity("ExpoBlog.Models.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PRI");

                    b.Property<string>("Title");

                    b.Property<string>("Url")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("PRI");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("ExpoBlog.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CatalogId");

                    b.Property<string>("Content");

                    b.Property<bool>("IsPage");

                    b.Property<string>("Summary");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.Property<string>("Url")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.HasIndex("IsPage");

                    b.HasIndex("Time");

                    b.HasIndex("Title")
                        .HasAnnotation("MySql:FullTextIndex", true);

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ExpoBlog.Models.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PostId");

                    b.Property<string>("Tag")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("Tag");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("Pomelo.AspNetCore.Extensions.BlobStorage.Models.Blob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Bytes");

                    b.Property<long>("ContentLength");

                    b.Property<string>("ContentType")
                        .HasMaxLength(128);

                    b.Property<string>("FileName")
                        .HasMaxLength(128);

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("FileName");

                    b.HasIndex("Time");

                    b.ToTable("Blobs");
                });

            modelBuilder.Entity("ExpoBlog.Models.BlogRoll", b =>
                {
                    b.HasOne("Pomelo.AspNetCore.Extensions.BlobStorage.Models.Blob", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");
                });

            modelBuilder.Entity("ExpoBlog.Models.Post", b =>
                {
                    b.HasOne("ExpoBlog.Models.Catalog", "Catalog")
                        .WithMany("Posts")
                        .HasForeignKey("CatalogId");
                });

            modelBuilder.Entity("ExpoBlog.Models.PostTag", b =>
                {
                    b.HasOne("ExpoBlog.Models.Post", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
