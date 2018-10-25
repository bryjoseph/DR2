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
        // public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
        // public DbSet<ReferenceGroup> ReferenceGroups { get; set; }

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
            // modelBuilder.Entity<CorrectiveAction>().ToTable("Corrective_Action");
            // modelBuilder.Entity<ReferenceGroup>().ToTable("Reference_Group");
        }

        public DbSet<Discrepancy_Report_2.Models.DiscrepancyReportC> DiscrepancyReportC { get; set; }
    }
}
