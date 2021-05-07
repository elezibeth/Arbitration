﻿// <auto-generated />
using System;
using Arbitration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arbitration.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210507002747_Names")]
    partial class Names
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arbitration.Models.AnticipatedAffirmativeDefense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neutralization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("AnticipatedAffirmativeDefenses");
                });

            modelBuilder.Entity("Arbitration.Models.Arbiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardsToClaimants")
                        .HasColumnType("int");

                    b.Property<int>("AwardsToCompanies")
                        .HasColumnType("int");

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfCOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasStockInCompany")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<bool>("LegalExperience")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<bool>("RelationshipsWithParties")
                        .HasColumnType("bit");

                    b.Property<string>("VocationalIndustry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("Arbitrators");
                });

            modelBuilder.Entity("Arbitration.Models.Arbitrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardsToClaimants")
                        .HasColumnType("int");

                    b.Property<int>("AwardsToCompanies")
                        .HasColumnType("int");

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfCOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasStockInCompany")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LegalExperience")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<bool>("RelationshipsWithParties")
                        .HasColumnType("bit");

                    b.Property<string>("VocationalIndustry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("Arbitratorss");
                });

            modelBuilder.Entity("Arbitration.Models.CaseTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArbiterChair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoreTruth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("CaseThemes");
                });

            modelBuilder.Entity("Arbitration.Models.CaseTheory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsumerClaimantId")
                        .HasColumnType("int");

                    b.Property<string>("HowLawBroken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InArbitratiorAppointment")
                        .HasColumnType("bit");

                    b.Property<bool>("InArbitratorInvitation")
                        .HasColumnType("bit");

                    b.Property<bool>("InAward")
                        .HasColumnType("bit");

                    b.Property<bool>("InInitiation")
                        .HasColumnType("bit");

                    b.Property<bool>("InPreliminaryHearing")
                        .HasColumnType("bit");

                    b.Property<string>("LawBroken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perpetrator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProofOfIntent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerClaimantId");

                    b.ToTable("CaseTheories");
                });

            modelBuilder.Entity("Arbitration.Models.ConsumerClaimant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArbitrationLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDisputing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("InArbitration")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("ConsumerClaimants");
                });

            modelBuilder.Entity("Arbitration.Models.FactualTheory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("FactualTheories");
                });

            modelBuilder.Entity("Arbitration.Models.GeneralNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("GeneralNotes");
                });

            modelBuilder.Entity("Arbitration.Models.NamesViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArbitratorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondArbitratorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("Arbitration.Models.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AppointmentOfArbitrator")
                        .HasColumnType("bit");

                    b.Property<bool>("ArbitratorsDisclosures")
                        .HasColumnType("bit");

                    b.Property<bool>("CompletionOfHearing")
                        .HasColumnType("bit");

                    b.Property<int>("ConsumerClaimantId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoticeOfArbitratorSelection")
                        .HasColumnType("bit");

                    b.Property<bool>("NotificationOfFiling")
                        .HasColumnType("bit");

                    b.Property<bool>("Schedule")
                        .HasColumnType("bit");

                    b.Property<bool>("SchedulingOrder")
                        .HasColumnType("bit");

                    b.Property<bool>("SignedOathDocument")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerClaimantId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Arbitration.Models.PartyInvolved", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PartiesInvolved");
                });

            modelBuilder.Entity("Arbitration.Models.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AppointmentOfArbitrator")
                        .HasColumnType("bit");

                    b.Property<bool>("ArbitratorsDisclosures")
                        .HasColumnType("bit");

                    b.Property<bool>("CompletionOfHearing")
                        .HasColumnType("bit");

                    b.Property<int>("ConsumerClaimantId")
                        .HasColumnType("int");

                    b.Property<bool>("NoticeOfArbitratorSelection")
                        .HasColumnType("bit");

                    b.Property<bool>("NotificationOfFiling")
                        .HasColumnType("bit");

                    b.Property<bool>("Schedule")
                        .HasColumnType("bit");

                    b.Property<bool>("SchedulingOrder")
                        .HasColumnType("bit");

                    b.Property<bool>("SignedOathDocument")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerClaimantId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("Arbitration.Models.PreferencesForArbitrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardsToClaimants")
                        .HasColumnType("int");

                    b.Property<int>("AwardsToCompanies")
                        .HasColumnType("int");

                    b.Property<int>("CaseTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfCOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasStockInCompany")
                        .HasColumnType("bit");

                    b.Property<bool>("LegalExperience")
                        .HasColumnType("bit");

                    b.Property<bool>("RelationshipsWithParties")
                        .HasColumnType("bit");

                    b.Property<string>("VocationalIndustry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseTheoryId");

                    b.ToTable("PreferedArbitratorAttributes");
                });

            modelBuilder.Entity("Arbitration.Models.TheoryEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FactualTheoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactualTheoryId");

                    b.ToTable("TheoryEvents");
                });

            modelBuilder.Entity("Arbitration.Models.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AlarmDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConsumerClaimantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Item")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerClaimantId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a59de089-5677-470c-b4b6-8d6240738227",
                            ConcurrencyStamp = "20df11be-987d-421e-89aa-454ec4229502",
                            Name = "CommercialClaimant",
                            NormalizedName = "COMMERCIALCLAIMANT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Arbitration.Models.AnticipatedAffirmativeDefense", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.Arbiter", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.Arbitrator", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.CaseTheme", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.CaseTheory", b =>
                {
                    b.HasOne("Arbitration.Models.ConsumerClaimant", "ConsumerClaimant")
                        .WithMany()
                        .HasForeignKey("ConsumerClaimantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerClaimant");
                });

            modelBuilder.Entity("Arbitration.Models.ConsumerClaimant", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Arbitration.Models.FactualTheory", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.GeneralNotes", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.Notice", b =>
                {
                    b.HasOne("Arbitration.Models.ConsumerClaimant", "ConsumerClaimant")
                        .WithMany()
                        .HasForeignKey("ConsumerClaimantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerClaimant");
                });

            modelBuilder.Entity("Arbitration.Models.Phase", b =>
                {
                    b.HasOne("Arbitration.Models.ConsumerClaimant", "ConsumerClaimant")
                        .WithMany()
                        .HasForeignKey("ConsumerClaimantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerClaimant");
                });

            modelBuilder.Entity("Arbitration.Models.PreferencesForArbitrator", b =>
                {
                    b.HasOne("Arbitration.Models.CaseTheory", "CaseTheory")
                        .WithMany()
                        .HasForeignKey("CaseTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseTheory");
                });

            modelBuilder.Entity("Arbitration.Models.TheoryEvent", b =>
                {
                    b.HasOne("Arbitration.Models.FactualTheory", "FactualTheory")
                        .WithMany()
                        .HasForeignKey("FactualTheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FactualTheory");
                });

            modelBuilder.Entity("Arbitration.Models.ToDoItem", b =>
                {
                    b.HasOne("Arbitration.Models.ConsumerClaimant", "ConsumerClaimant")
                        .WithMany()
                        .HasForeignKey("ConsumerClaimantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerClaimant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
