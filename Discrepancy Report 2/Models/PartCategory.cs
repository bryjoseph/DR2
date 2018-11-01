using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class PartCategory
    {
        // PK == ID
        public int ID { get; set; }

        [Display(Name = "System Category")]
        public string CategoryName { get; set; }

        [NotMapped]
        public int PartID { get; set; }

        [NotMapped]
        public int PartSubCategoryID { get; set; }

        // navigation properties
        public ICollection<OrderForm> OrderForms { get; set; }
    }
}
