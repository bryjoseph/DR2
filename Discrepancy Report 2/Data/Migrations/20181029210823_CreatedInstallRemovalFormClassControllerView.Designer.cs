﻿// <auto-generated />
using Discrepancy_Report_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Discrepancy_Report_2.Data.Migrations
{
    [DbContext(typeof(MaintenanceDbContext))]
    [Migration("20181029210823_CreatedInstallRemovalFormClassControllerView")]
    partial class CreatedInstallRemovalFormClassControllerView
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Discrepancy_Report_2.Models.Aircraft", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AircraftModelID");

                    b.Property<string>("EasaNumber");

                    b.Property<string>("FaaNumber");

                    b.Property<string>("TailNumber");

                    b.HasKey("ID");

                    b.HasIndex("AircraftModelID");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.AircraftLocationAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AircraftID");

                    b.Property<int>("LocationID");

                    b.Property<bool?>("Planned");

                    b.Property<bool?>("Unplanned");

                    b.HasKey("ID");

                    b.HasIndex("AircraftID");

                    b.HasIndex("LocationID");

                    b.ToTable("Aircraft_Location_Assignment");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.AircraftModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("ModelType");

                    b.HasKey("ID");

                    b.ToTable("Aircraft_Model");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

            modelBuilder.Entity("Discrepancy_Report_2.Models.AtaChapter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChapterNumber");

                    b.Property<string>("ChapterSummary");

                    b.HasKey("ID");

                    b.ToTable("ATA_Chapter");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.DiscrepancyReportC", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdvisoryMessage1");

                    b.Property<string>("AdvisoryMessage2");

                    b.Property<int>("AircraftID");

                    b.Property<bool>("AoG");

                    b.Property<bool>("Approach");

                    b.Property<string>("AtaChapterEnd");

                    b.Property<int>("AtaChapterID");

                    b.Property<bool>("BeforeTakeoff");

                    b.Property<bool>("Climb");

                    b.Property<string>("CorrectiveActionDescription");

                    b.Property<bool>("Cruise");

                    b.Property<DateTime?>("CustomerAcceptanceDate");

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("DateDiscovered");

                    b.Property<bool>("Descent");

                    b.Property<string>("DiscrepancyDescription");

                    b.Property<int>("EmployeeID");

                    b.Property<bool>("EngineStart");

                    b.Property<DateTime?>("GovOfficialDateSigned");

                    b.Property<string>("GovernmentOfficial");

                    b.Property<bool>("Landing");

                    b.Property<bool>("LeakCheck");

                    b.Property<int>("LocationID");

                    b.Property<int>("MaintenanceTypeID");

                    b.Property<bool>("MasterCaution");

                    b.Property<bool>("MasterWarning");

                    b.Property<bool>("OnTakeoffRoll");

                    b.Property<bool>("OpsCheckRequired");

                    b.Property<bool>("Postflight");

                    b.Property<DateTime?>("QaDateSigned");

                    b.Property<string>("QaName");

                    b.Property<string>("ReferenceDocument1");

                    b.Property<string>("ReferenceDocument2");

                    b.Property<string>("ReportRecord")
                        .IsRequired();

                    b.Property<bool>("Rii");

                    b.Property<bool>("Rollout");

                    b.Property<int>("SignificantEventID");

                    b.Property<DateTime?>("TechnicianDateSigned");

                    b.Property<string>("TechnicianName");

                    b.Property<string>("WarningMessage1");

                    b.Property<string>("WarningMessage2");

                    b.Property<string>("WarningMessageOther");

                    b.Property<string>("WorkInstructionsPlannedAction");

                    b.HasKey("ID");

                    b.HasIndex("AircraftID");

                    b.HasIndex("AtaChapterID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("LocationID");

                    b.HasIndex("MaintenanceTypeID");

                    b.HasIndex("SignificantEventID");

                    b.ToTable("Discrepancy_Report");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName");

                    b.Property<int>("TitleID");

                    b.HasKey("ID");

                    b.HasIndex("TitleID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocationCode");

                    b.Property<string>("RegionCode");

                    b.Property<string>("RegionName");

                    b.HasKey("ID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.MaintenanceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaintenanceTypeDescription");

                    b.HasKey("ID");

                    b.ToTable("Maintenance_Type");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.RemovalInstallationForm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CorrectedBy")
                        .IsRequired();

                    b.Property<DateTime?>("DateCorrected")
                        .IsRequired();

                    b.Property<DateTime?>("DateFiled");

                    b.Property<DateTime>("DateFormCreated");

                    b.Property<DateTime?>("DateInspected");

                    b.Property<int>("DiscrepancyReportCID");

                    b.Property<string>("FiledBy");

                    b.Property<string>("InspectedBy");

                    b.Property<string>("InstalledPartNumber1");

                    b.Property<string>("InstalledPartNumber2");

                    b.Property<string>("InstalledPartNumber3");

                    b.Property<string>("InstalledPartNumber4");

                    b.Property<string>("InstalledPartSerialNumber1");

                    b.Property<string>("InstalledPartSerialNumber2");

                    b.Property<string>("InstalledPartSerialNumber3");

                    b.Property<string>("InstalledPartSerialNumber4");

                    b.Property<string>("NomenclaturePart1");

                    b.Property<string>("NomenclaturePart2");

                    b.Property<string>("NomenclaturePart3");

                    b.Property<string>("NomenclaturePart4");

                    b.Property<string>("RemovedPartNumber1");

                    b.Property<string>("RemovedPartNumber2");

                    b.Property<string>("RemovedPartNumber3");

                    b.Property<string>("RemovedPartNumber4");

                    b.Property<string>("RemovedPartSerialNumber1");

                    b.Property<string>("RemovedPartSerialNumber2");

                    b.Property<string>("RemovedPartSerialNumber3");

                    b.Property<string>("RemovedPartSerialNumber4");

                    b.HasKey("ID");

                    b.HasIndex("DiscrepancyReportCID");

                    b.ToTable("Removal_Installation_Form");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.SignificantEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SignificantEventDescription");

                    b.HasKey("ID");

                    b.ToTable("Significant_Event");
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TitleName");

                    b.HasKey("ID");

                    b.ToTable("Title");
                });

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
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Discrepancy_Report_2.Models.Aircraft", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.AircraftModel", "AircraftModel")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AircraftModelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.AircraftLocationAssignment", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.Aircraft", "Aircraft")
                        .WithMany("AircraftLocationAssignments")
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.Location", "Location")
                        .WithMany("AircraftLocationAssignments")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.DiscrepancyReportC", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.Aircraft", "Aircraft")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.AtaChapter", "AtaChapter")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("AtaChapterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.Employee", "Employee")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.Location", "Location")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.MaintenanceType", "MaintenanceType")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("MaintenanceTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discrepancy_Report_2.Models.SignificantEvent", "SignificantEvent")
                        .WithMany("DiscrepancyReports")
                        .HasForeignKey("SignificantEventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.Employee", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.Title", "Title")
                        .WithMany("Employees")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Discrepancy_Report_2.Models.RemovalInstallationForm", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.DiscrepancyReportC", "DiscrepancyReportC")
                        .WithMany("RemovalInstallationForms")
                        .HasForeignKey("DiscrepancyReportCID")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("Discrepancy_Report_2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.ApplicationUser")
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

                    b.HasOne("Discrepancy_Report_2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Discrepancy_Report_2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
