using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Discrepancy_Report_2.Models;

namespace Discrepancy_Report_2.Data
{
    public class MaintenanceDbContext : IdentityDbContext<ApplicationUser>
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : base(options)
        {
        }

        // creating the entity sets for the database
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftLocationAssignment> AircraftLocationAssignments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AircraftModel> AircraftModels { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DiscrepancyReportC> DiscrepancyReportCs { get; set; }
        public DbSet<AtaChapter> AtaChapters { get; set; }
        public DbSet<SignificantEvent> SignificantEvents { get; set; }
        public DbSet<MaintenanceType>MaintenanceTypes { get; set; }
        public DbSet<RemovalInstallationForm> RemovalInstallationForms { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<TagColor> TagColors { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartSubCategory> PartSubCategories { get; set; }
        public DbSet<PartCategory> PartCategories { get; set; }
        public DbSet<OrderForm> OrderForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Aircraft>().ToTable("Aircraft");
            modelBuilder.Entity<AircraftLocationAssignment>().ToTable("Aircraft_Location_Assignment");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<AircraftModel>().ToTable("Aircraft_Model");
            modelBuilder.Entity<Title>().ToTable("Title");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<DiscrepancyReportC>().ToTable("Discrepancy_Report");
            modelBuilder.Entity<AtaChapter>().ToTable("ATA_Chapter");
            modelBuilder.Entity<SignificantEvent>().ToTable("Significant_Event");
            modelBuilder.Entity<MaintenanceType>().ToTable("Maintenance_Type");
            modelBuilder.Entity<RemovalInstallationForm>().ToTable("Removal_Installation_Form");
            modelBuilder.Entity<OrderStatus>().ToTable("Order_Status");
            modelBuilder.Entity<TagColor>().ToTable("Tag_Color");
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<PartSubCategory>().ToTable("Part_Subcategory");
            modelBuilder.Entity<PartCategory>().ToTable("Part_Category");
            modelBuilder.Entity<OrderForm>().ToTable("Order_Form");
        }
    }
}
