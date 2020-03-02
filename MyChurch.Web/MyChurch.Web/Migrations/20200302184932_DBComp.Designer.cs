﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChurch.Web.Data;

namespace MyChurch.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200302184932_DBComp")]
    partial class DBComp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.ChurchEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DiscipleId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("MentorId");

                    b.Property<int?>("MinistryId");

                    b.Property<decimal>("Price");

                    b.Property<string>("Remarks")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("DiscipleId");

                    b.HasIndex("MentorId");

                    b.HasIndex("MinistryId");

                    b.ToTable("ChurchEvents");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Disciple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Disciples");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.FollowUpHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("MinistryId");

                    b.Property<string>("Remarks");

                    b.Property<int?>("ServiceTypeId");

                    b.HasKey("Id");

                    b.HasIndex("MinistryId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("FollowUpHistories");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Ministry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId");

                    b.Property<string>("BiblicalWord")
                        .IsRequired();

                    b.Property<int?>("DiscipleId");

                    b.Property<decimal>("Fund");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Leader")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("MeetEndDate");

                    b.Property<DateTime>("MeetStartDate");

                    b.Property<int?>("MentorId");

                    b.Property<int?>("MinistryTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark");

                    b.Property<string>("SubLeader")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("DiscipleId");

                    b.HasIndex("MentorId");

                    b.HasIndex("MinistryTypeId");

                    b.ToTable("Ministries");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.MinistryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MinistryTypes");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyChurch.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Admin", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.ChurchEvent", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.Admin", "Admin")
                        .WithMany("ChurchEvents")
                        .HasForeignKey("AdminId");

                    b.HasOne("MyChurch.Web.Data.Entities.Disciple", "Disciple")
                        .WithMany("ChurchEvents")
                        .HasForeignKey("DiscipleId");

                    b.HasOne("MyChurch.Web.Data.Entities.Mentor", "Mentor")
                        .WithMany("ChurchEvents")
                        .HasForeignKey("MentorId");

                    b.HasOne("MyChurch.Web.Data.Entities.Ministry", "Ministry")
                        .WithMany()
                        .HasForeignKey("MinistryId");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Disciple", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.FollowUpHistory", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.Ministry", "Ministry")
                        .WithMany("FollowUpHistories")
                        .HasForeignKey("MinistryId");

                    b.HasOne("MyChurch.Web.Data.Entities.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Mentor", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyChurch.Web.Data.Entities.Ministry", b =>
                {
                    b.HasOne("MyChurch.Web.Data.Entities.Admin", "Admin")
                        .WithMany("Ministries")
                        .HasForeignKey("AdminId");

                    b.HasOne("MyChurch.Web.Data.Entities.Disciple", "Disciple")
                        .WithMany()
                        .HasForeignKey("DiscipleId");

                    b.HasOne("MyChurch.Web.Data.Entities.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");

                    b.HasOne("MyChurch.Web.Data.Entities.MinistryType", "MinistryType")
                        .WithMany()
                        .HasForeignKey("MinistryTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
