﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using habrbr.Infrastructure.Persistence.Contexts;

#nullable disable

namespace habrbr.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<int?>("BlogID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string[]>("Tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BlogID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Models.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("BlogName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentArticleID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("ParentArticleID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Models.Subscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<int?>("BlogID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("SubscriberID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SubscriptionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BlogID");

                    b.HasIndex("SubscriberID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserRightsInBlog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("BlogID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RightsAssignmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.Property<string>("UserRole")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BlogID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRightsInBlogs");
                });

            modelBuilder.Entity("Models.Article", b =>
                {
                    b.HasOne("Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("Models.Blog", null)
                        .WithMany("Articles")
                        .HasForeignKey("BlogID");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Models.Blog", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany("Blogs")
                        .HasForeignKey("CreatorID");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.HasOne("Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("Models.Article", "ParentArticle")
                        .WithMany("Comments")
                        .HasForeignKey("ParentArticleID");

                    b.Navigation("Author");

                    b.Navigation("ParentArticle");
                });

            modelBuilder.Entity("Models.Subscription", b =>
                {
                    b.HasOne("Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogID");

                    b.HasOne("Models.User", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberID");

                    b.Navigation("Author");

                    b.Navigation("Blog");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("Models.UserRightsInBlog", b =>
                {
                    b.HasOne("Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogID");

                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Models.Blog", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
