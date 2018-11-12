using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class OrderStatus
    {
        // PK ==ID
        public int ID { get; set; }

        // Status description
        [Display(Name = "Status Description")]
        public string StatusDescription { get; set; }

        // navigation properties
        // public ICollection<OrderForm> OrderForms { get; set; } old

        // new Order Form connection
        public ICollection<NewOrderForm> NewOrderForms { get; set; }
    }
}
