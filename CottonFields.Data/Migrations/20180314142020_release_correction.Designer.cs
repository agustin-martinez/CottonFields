﻿// <auto-generated />
using CottonFields.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CottonFields.Data.Migrations
{
    [DbContext(typeof(CottonContext))]
    [Migration("20180314142020_release_correction")]
    partial class release_correction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CottonFields.Domain.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Members");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.HasKey("ID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("CottonFields.Domain.Label", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("CottonFields.Domain.MatrixNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number");

                    b.Property<int?>("ReleaseID");

                    b.HasKey("ID");

                    b.HasIndex("ReleaseID");

                    b.ToTable("MatrixNumbers");
                });

            modelBuilder.Entity("CottonFields.Domain.Release", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<int?>("ArtistID");

                    b.Property<string>("Label");

                    b.Property<int?>("LabelID");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("LabelID");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("CottonFields.Domain.Track", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ReleaseID");

                    b.HasKey("ID");

                    b.HasIndex("ReleaseID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CottonFields.Domain.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Password");

                    b.Property<int>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CottonFields.Domain.UserRelease", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("ReleaseID");

                    b.HasKey("UserID", "ReleaseID");

                    b.HasIndex("ReleaseID");

                    b.ToTable("UserRelease");
                });

            modelBuilder.Entity("CottonFields.Domain.MatrixNumber", b =>
                {
                    b.HasOne("CottonFields.Domain.Release")
                        .WithMany("MatrixNumbers")
                        .HasForeignKey("ReleaseID");
                });

            modelBuilder.Entity("CottonFields.Domain.Release", b =>
                {
                    b.HasOne("CottonFields.Domain.Artist")
                        .WithMany("Releases")
                        .HasForeignKey("ArtistID");

                    b.HasOne("CottonFields.Domain.Label")
                        .WithMany("Releases")
                        .HasForeignKey("LabelID");
                });

            modelBuilder.Entity("CottonFields.Domain.Track", b =>
                {
                    b.HasOne("CottonFields.Domain.Release")
                        .WithMany("Tracks")
                        .HasForeignKey("ReleaseID");
                });

            modelBuilder.Entity("CottonFields.Domain.UserRelease", b =>
                {
                    b.HasOne("CottonFields.Domain.Release", "Release")
                        .WithMany("Users")
                        .HasForeignKey("ReleaseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CottonFields.Domain.User", "User")
                        .WithMany("Releases")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
