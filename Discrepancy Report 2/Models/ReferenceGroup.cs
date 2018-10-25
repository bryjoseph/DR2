using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discrepancy_Report_2.Models
{
    public class ReferenceGroup
    {
        public int ID { get; set; }
        [Display(Name = "Reference Document 1")]
        public string ReferenceDocument1 { get; set; }
        [Display(Name = "Reference Document 2")]
        public string ReferenceDocument2 { get; set; }

        //Navigation Property
        // public ICollection<CorrectiveAction> CorrectiveActions { get; set; }
    }
}
