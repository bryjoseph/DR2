using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discrepancy_Report_2.Models
{
    public class MaintenanceType
    {
        public int ID { get; set; }
        public string MaintenanceTypeDescription { get; set; }

        // Navigation Props
        public ICollection<DiscrepancyReportC> DiscrepancyReports { get; set; }
    }
}
