using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discrepancy_Report_2.Models
{
    public class Aircraft
    {
        // ID == PK
        public int ID { get; set; }
        // the string property is already nullable if not a US aircraft
        [Display(Name = "FAA Number")]
        public string FaaNumber { get; set; }
        // the string property is already nullable if not a EU aircraft
        [Display(Name = "EASA Number")]
        public string EasaNumber { get; set; }
        [Display(Name = "Tail Number")]
        public string TailNumber { get; set; }
        public int AircraftModelID { get; set; }

        // navigation properties
        public ICollection<AircraftLocationAssignment> AircraftLocationAssignments { get; set; }
        // public ICollection<AircraftModel> AircraftModels { get; set; }
        public AircraftModel AircraftModel { get; set; }
        public ICollection<DiscrepancyReportC> DiscrepancyReports { get; set; }
    }
}
