using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discrepancy_Report_2.Models
{
    public class AtaChapter
    {
        // PK == ID (hidden)
        public int ID { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterSummary { get; set; }

        // Navigation Props
        public ICollection<DiscrepancyReportC> DiscrepancyReports { get; set; }
    }
}
