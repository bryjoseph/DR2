using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discrepancy_Report_2.Models
{
    public class DiscrepancyReportC
    {
        // PK == ID (will be created by DB and stay unique per record)
        public int ID { get; set; }
        
        // Report ID the user will create (and will be displayed)
        [Required]
        [Display(Name = "Report Record #")]
        public string ReportRecord { get; set; }
        
        // Associated Aircraft
        [Required]
        [Display(Name ="Aircraft FAA/EASA Number")]
        public int AircraftID { get; set; }

        // Employee record who found the issue
        [Required]
        [Display(Name = "Discovered By")]
        public int EmployeeID { get; set; }

        // Date discovered
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Discovered")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDiscovered { get; set; }

        // Location of DR Creation
        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        
        // ATA Start (what data type is this???)
        [Display(Name = "ATA Start")]
        public int AtaChapterID { get; set; }
        
        // ATA Finish (what data type is this???)
        [Display(Name = "ATA Finish")]
        public string AtaChapterEnd { get; set; }
        
        // Phases of Flight Checkboxes
        [Display(Name = "Engine Start")]
        public bool EngineStart { get; set; }
        [Display(Name = "Before Takeoff")]
        public bool BeforeTakeoff { get; set; }
        [Display(Name = "On Takeoff Roll")]
        public bool OnTakeoffRoll { get; set; }
        public bool Climb { get; set; }
        public bool Cruise { get; set; }
        public bool Descent { get; set; }
        public bool Approach { get; set; }
        public bool Landing { get; set; }
        public bool Rollout { get; set; }
        public bool Postflight { get; set; }

        //Significant Event
        [Display(Name = "Significant Event")]
        public int SignificantEventID { get; set; }

        //Type Mix
        [Display(Name = "Maintenance Type")]
        public int MaintenanceTypeID { get; set; }

        // Types of Warnings
        [Display(Name = "Master Warning")]
        public bool MasterWarning { get; set; }
        [Display(Name = "Master Caution")]
        public bool MasterCaution { get; set; }
        
        //Types of Messages
        [Display(Name = "Warning Message #1")]
        public string WarningMessage1 { get; set; }
        [Display(Name = "Warning Message #2")]
        public string WarningMessage2 { get; set; }
        [Display(Name = "Advisory Message #1")]
        public string AdvisoryMessage1 { get; set; }
        [Display(Name = "Advisory Message #2")]
        public string AdvisoryMessage2 { get; set; }
        [Display(Name = "Warning Other")]
        public string WarningMessageOther { get; set; }

        // The Discrepancy Description
        [Display(Name = "Discrepancy Description")]
        public string DiscrepancyDescription { get; set; }

        // Aircraft on Ground
        [Display(Name = "Aircraft On Ground")]
        public bool AoG { get; set; }

        // RII
        [Display(Name = "RII")]
        public bool Rii { get; set; }

        // Work Instructions
        [Display(Name = "Work Instructions and Planned Action")]
        public string WorkInstructionsPlannedAction { get; set; }

        //Corrective Action Data
        [Display(Name = "Deferral and/or Corrective Action")]
        public string CorrectiveActionDescription { get; set; }
        [Display(Name = "OPS Check")]
        public bool OpsCheckRequired { get; set; }
        [Display(Name = "Leak Check")]
        public bool LeakCheck { get; set; }

        [Display(Name = "Technician Name")]
        public string TechnicianName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Technician Date Signed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TechnicianDateSigned { get; set; }

        [Display(Name = "QA Name")]
        public string QaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "QA Date Signed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QaDateSigned { get; set; }

        [Display(Name = "Government Official Name")]
        public string GovernmentOfficial { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Gov Official Signed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GovOfficialDateSigned { get; set; }

        [Display(Name = "Reference Document 1")]
        public string ReferenceDocument1 { get; set; }
        [Display(Name = "Reference Document 2")]
        public string ReferenceDocument2 { get; set; }

        // Removal & Installation Form Data NOT ADDED YET
        // [Display(Name = "Removal / Installation Form")]
        // public int RemovalInstallationFormID { get; set; }

        // Order Form Data NOT ADDED YET
        // [Display(Name = "Order Form")]
        // public int OrderFormID { get; set; }

        // Customer Acceptance Data
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Customer Accepted")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CustomerAcceptanceDate { get; set; }

        // Navigation Properties
        public Aircraft Aircraft { get; set; }
        public Employee Employee { get; set; } // discovered many-to-many relationship here
        public Location Location { get; set; }
        public AtaChapter AtaChapter { get; set; }
        public SignificantEvent SignificantEvent { get; set; }
        public MaintenanceType MaintenanceType { get; set; }
        public ICollection<RemovalInstallationForm> RemovalInstallationForms { get; set; }
        // public ICollection<DiscrepancyAssignment> DiscrepancyAssignments { get; set; }
        // public CorrectiveAction CorrectiveAction { get; set; } adding this data to the DR
        // public RemovalInstallationForm RemovalInstallationForm { get; set; }
        // public OrderForm OrderForm { get; set; }
    }
}
