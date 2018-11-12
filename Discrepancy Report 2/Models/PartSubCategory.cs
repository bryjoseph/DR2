using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class PartSubCategory
    {
        // PK == ID
        public int ID { get; set; }

        [Display(Name = "Subcategory Manufacturer")]
        public string SubCategoryName { get; set; }

        // public int PartCategoryID { get; set; }
        // public int PartID { get; set; }

        // navigation properties
        // public ICollection<OrderForm> OrderForms { get; set; } old
        //public PartCategory PartCategory { get; set; }
        //public ICollection<Part> Parts { get; set; }

        // new Order form connection
        public ICollection<NewOrderForm> NewOrderForms { get; set; }

    }
}
