using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discrepancy_Report_2.Models
{
    public class CorrectiveAction
    {
        public int ID { get; set; }
        public string CorrectiveActionDescription { get; set; }
        public bool OpsCheckRequired { get; set; }
        public bool LeakCheck { get; set; }
        [Display(Name = "Mechanic Name")]
        public int EmployeeID { get; set; }
        public DateTime MechanicDateSigned { get; set; }
        [Display(Name = "QA Name")]
        public int EmployeeID1 { get; set; }
        public DateTime QaDateSigned { get; set; }
        [Display(Name = "Government Official Name")]
        public string GovernmentOfficial { get; set; }
        public DateTime GovOfficialDateSigned { get; set; }
        public int ReferenceGroupID { get; set; }
        public int DiscrepancyReportCID { get; set; }

        // Navigation Props
        // public DiscrepancyReportC DiscrepancyReportC { get; set; }
        // public Employee Employee { get; set; }
        // public ReferenceGroup ReferenceGroup { get; set; }
    }
}
