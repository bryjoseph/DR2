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

        public int CategoryID { get; set; }

        // navigation properties
        public ICollection<OrderForm> OrderForms { get; set; }
    }
}
