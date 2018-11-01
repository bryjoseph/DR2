using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class Part
    {
        // PK == ID
        public int ID { get; set; }

        [Required]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }

        [Required]
        [Display(Name = "Part Number")]
        public int PartNumber { get; set; }

        [Required]
        [Display(Name = "Part Serial Number")]
        public int PartSerialNumber { get; set; }

        [Display(Name = "Tag Color")]
        public int TagColorID { get; set; }

        public int SubCategoryID { get; set; }

        // navigation properties
        public ICollection<OrderForm> OrderForms { get; set; }
        public TagColor TagColor { get; set; }
    }
}
