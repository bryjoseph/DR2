﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discrepancy_Report_2.Models
{
    public class AircraftModel
    {
        public int ID { get; set; }
        [Display(Name = "Aircraft Model Type")]
        public string ModelType { get; set; }
        public string Manufacturer { get; set; }
        // public int AircraftID { get; set; }

        // Navigation properties
        // public Aircraft Aircraft { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set; }
    }
}
