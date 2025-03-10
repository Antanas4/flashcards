﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250310142632_CollectionsDescription")]
    partial class CollectionsDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("server.Models.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FlashcardsCollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlashcardsCollectionId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("server.Models.FlashcardsCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FlashcardsCollection");
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("server.Models.Flashcard", b =>
                {
                    b.HasOne("server.Models.FlashcardsCollection", null)
                        .WithMany("Flashcards")
                        .HasForeignKey("FlashcardsCollectionId");
                });

            modelBuilder.Entity("server.Models.FlashcardsCollection", b =>
                {
                    b.HasOne("server.Models.User", "User")
                        .WithMany("FlashcardsCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.Models.FlashcardsCollection", b =>
                {
                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Navigation("FlashcardsCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
