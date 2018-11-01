using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class OrderForm
    {
        // ID == PK (created by EF)
        public int ID { get; set; }
        // Order Number similar to DR Report Record (created by user)
        [Required]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        // Who created the order
        [Required]
        [Display(Name = "Ordered By")]
        public int EmployeeID { get; set; }
        // Date Ordered
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date & Time Ordered")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOrderCreated { get; set; }

        // Part Data
        // first the category
        [Display(Name = "Part Category")]
        public int? PartCategoryID { get; set; }
        // then the sub category
        [Display(Name = "Part Subcategory")]
        public int? PartSubCategoryID { get; set; }
        // next the part
        [Display(Name = "Part")]
        public int? PartID { get; set; }
        // UI whatever this means
        [Display(Name = "UI")]
        public string Ui { get; set; }
        // part quantity for order
        [Display(Name = "Part Quantity")]
        public int? PartQuantity { get; set; }
        // reference document #
        [Display(Name = "Part Document #")]
        public string PartDocumentNumber { get; set; }

        // Tracking Data
        [Display(Name = "Tracking Number")]
        public string TrackingNumber { get; set; }
        // EDD for order
        [DataType(DataType.Date)]
        [Display(Name = "EDD")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Edd { get; set; }
        // Status of order
        public int OrderStatusID { get; set; }

        // navigation properties
        public Employee Employee { get; set; }
        public PartCategory PartCategory { get; set; }
        public PartSubCategory PartSubCategory { get; set; }
        public Part Part { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
