using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discrepancy_Report_2.Models
{
    public class Title
    {
        public int ID { get; set; }
        public string TitleName { get; set; }
        // public int EmployeeID { get; set; }

        // navigation properties
        // public Employee Employee { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
