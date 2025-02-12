﻿// <auto-generated />
using System;
using IdentityServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("text");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("CompanyManager")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IndustryType")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsRegisteredForVAT")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTaxpayer")
                        .HasColumnType("boolean");

                    b.Property<string>("LegalRepresentative")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("TradeRegistryNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WebsiteUrl")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.HasIndex("TaxNumber")
                        .IsUnique();

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("Consent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConsentType")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateGiven")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Consents");
                });

            modelBuilder.Entity("IdentityServer.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("LoginAttempt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AttemptDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("text");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.Property<bool>("Success")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("LoginAttempts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUserRole<Guid>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OAuthProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClientID")
                        .HasColumnType("text");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("text");

                    b.Property<string>("ProviderName")
                        .HasColumnType("text");

                    b.Property<string>("RedirectUrl")
                        .HasColumnType("text");

                    b.Property<string>("Scopes")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OAuthProviders");
                });

            modelBuilder.Entity("PasswordReset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UsedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PermissionName")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PermissionID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("SecurityQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnswerHash")
                        .HasColumnType("text");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SecurityQuestions");
                });

            modelBuilder.Entity("Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DeviceInfo")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiresDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("TwoFactorAuth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RecoveryCodes")
                        .HasColumnType("text");

                    b.Property<string>("SecretKey")
                        .HasColumnType("text");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("TwoFactorAuths");
                });

            modelBuilder.Entity("UserOAuth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccessToken")
                        .HasColumnType("text");

                    b.Property<Guid>("OAuthProviderID")
                        .HasColumnType("uuid");

                    b.Property<string>("ProviderUserID")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("TokenExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OAuthProviderID");

                    b.HasIndex("UserID");

                    b.ToTable("UserOAuths");
                });

            modelBuilder.Entity("UserSecurityQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnswerHash")
                        .HasColumnType("text");

                    b.Property<Guid>("SecurityQuestionID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SecurityQuestionID");

                    b.HasIndex("UserID");

                    b.ToTable("UserSecurityQuestions");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("ApplicationRole", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company", null)
                        .WithMany("Roles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AuditLog", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("AuditLogs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Consent", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("Consents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IdentityServer.Models.ApplicationUser", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company", null)
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LoginAttempt", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PasswordReset", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("PasswordResets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.HasOne("Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationRole", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Session", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwoFactorAuth", b =>
                {
                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("TwoFactorAuths")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserOAuth", b =>
                {
                    b.HasOne("OAuthProvider", "OAuthProvider")
                        .WithMany()
                        .HasForeignKey("OAuthProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("UserOAuths")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OAuthProvider");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserSecurityQuestion", b =>
                {
                    b.HasOne("SecurityQuestion", "SecurityQuestion")
                        .WithMany()
                        .HasForeignKey("SecurityQuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("UserSecurityQuestions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SecurityQuestion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId1");

                    b.HasOne("IdentityServer.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationRole", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("IdentityServer.Models.ApplicationUser", b =>
                {
                    b.Navigation("AuditLogs");

                    b.Navigation("Consents");

                    b.Navigation("LoginAttempts");

                    b.Navigation("PasswordResets");

                    b.Navigation("Sessions");

                    b.Navigation("TwoFactorAuths");

                    b.Navigation("UserOAuths");

                    b.Navigation("UserRoles");

                    b.Navigation("UserSecurityQuestions");
                });

            modelBuilder.Entity("Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
