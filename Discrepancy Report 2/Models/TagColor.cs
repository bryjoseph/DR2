using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class TagColor
    {
        public int ID { get; set; }

        [Display(Name = "Color Description")]
        public string ColorDescription { get; set; }

        // navigation properties
        public ICollection<Part> Parts { get; set; }
    }
}
