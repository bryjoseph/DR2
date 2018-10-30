using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discrepancy_Report_2.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public int TitleID { get; set; }
        // public int CorrectiveActionID { get; set; }

        // navigation property
        // public ICollection<Title> Titles { get; set; }
        public Title Title { get; set; }
        // public ICollection<CorrectiveAction> CorrectiveActions { get; set; }
        public ICollection<DiscrepancyReportC> DiscrepancyReports { get; set; }
        // public ICollection<DiscrepancyAssignment> DiscrepancyAssignments { get; set; }
        public ICollection<RemovalInstallationForm> RemovalInstallationForms { get; set; }
    }
}
