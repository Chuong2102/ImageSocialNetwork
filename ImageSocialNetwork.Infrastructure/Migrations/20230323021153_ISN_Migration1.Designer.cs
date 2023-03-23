﻿// <auto-generated />
using System;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageSocialNetwork.Infrastructure.Migrations
{
    [DbContext(typeof(ImageSocialDbContext))]
    [Migration("20230323021153_ISN_Migration1")]
    partial class ISN_Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.AccountEntity", b =>
                {
                    b.Property<int>("AcountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AcountID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.CommentEntity", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.FollowerEntity", b =>
                {
                    b.Property<int>("FollowerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FollowerUserID")
                        .HasColumnType("int");

                    b.Property<int?>("FollowingUserID")
                        .HasColumnType("int");

                    b.HasKey("FollowerID");

                    b.HasIndex("FollowerUserID");

                    b.HasIndex("FollowingUserID");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.FollowingEntity", b =>
                {
                    b.Property<int>("FollowingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FollowerUserID")
                        .HasColumnType("int");

                    b.Property<int?>("FollowingUserID")
                        .HasColumnType("int");

                    b.HasKey("FollowingID");

                    b.HasIndex("FollowerUserID");

                    b.HasIndex("FollowingUserID");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.ImageEntity", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("PostID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.LikeEntity", b =>
                {
                    b.Property<int>("LikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LikeID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.PostEntity", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("LasLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.AccountEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "User")
                        .WithOne("Account")
                        .HasForeignKey("ImageSocialNetwork.Infrastructure.Entities.AccountEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.CommentEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.FollowerEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerUserID");

                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "Following")
                        .WithMany()
                        .HasForeignKey("FollowingUserID");

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.FollowingEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerUserID");

                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "Following")
                        .WithMany()
                        .HasForeignKey("FollowingUserID");

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.ImageEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.LikeEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.PostEntity", b =>
                {
                    b.HasOne("ImageSocialNetwork.Infrastructure.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImageSocialNetwork.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
