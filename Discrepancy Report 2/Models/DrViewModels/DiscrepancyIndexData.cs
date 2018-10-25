using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discrepancy_Report_2.Models.DrViewModels
{
    public class DiscrepancyIndexData
    {
        public IEnumerable<DiscrepancyReportC> DiscrepancyReport { get; set; }
        public IEnumerable<Aircraft> Aircraft { get; set; }
        public IEnumerable<AircraftModel> AircraftModel { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Title> Title { get; set; }
        public IEnumerable<AtaChapter> AtaChapter { get; set; }
        public IEnumerable<SignificantEvent> SignificantEvent { get; set; }
        public IEnumerable<MaintenanceType> MaintenanceType { get; set; }
    }
}
