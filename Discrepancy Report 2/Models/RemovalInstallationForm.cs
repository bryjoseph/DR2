using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discrepancy_Report_2.Models
{
    public class RemovalInstallationForm
    {
        public int ID { get; set; }
        // connects this installation /removal form to a DR
        [Required]
        [Display(Name = "Discrepancy Report Record")]
        public int DiscrepancyReportCID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Install/Removal Form Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFormCreated { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public int EmployeeID { get; set; }

        //Removed Part Data
        [Display(Name = "1st Removed Part #")]
        public string RemovedPartNumber1 { get; set; }
        [Display(Name = "1st Removed Serial #")]
        public string RemovedPartSerialNumber1 { get; set; }
        [Display(Name = "Nomenclature")]
        public string NomenclaturePart1 { get; set; }

        [Display(Name = "2nd Removed Part #")]
        public string RemovedPartNumber2 { get; set; }
        [Display(Name = "2nd Removed Serial #")]
        public string RemovedPartSerialNumber2 { get; set; }
        [Display(Name = "Nomenclature")]
        public string NomenclaturePart2 { get; set; }

        [Display(Name = "3rd Removed Part #")]
        public string RemovedPartNumber3 { get; set; }
        [Display(Name = "3rd Removed Serial #")]
        public string RemovedPartSerialNumber3 { get; set; }
        [Display(Name = "Nomenclature")]
        public string NomenclaturePart3 { get; set; }

        [Display(Name = "4th Removed Part #")]
        public string RemovedPartNumber4 { get; set; }
        [Display(Name = "4th Removed Serial #")]
        public string RemovedPartSerialNumber4 { get; set; }
        [Display(Name = "Nomenclature")]
        public string NomenclaturePart4 { get; set; }

        //Installed Part Data
        [Display(Name = "1st Installed Part #")]
        public string InstalledPartNumber1 { get; set; }
        [Display(Name = "1st Installed Serial #")]
        public string InstalledPartSerialNumber1 { get; set; }

        [Display(Name = "2nd Installed Part #")]
        public string InstalledPartNumber2 { get; set; }
        [Display(Name = "2nd Installed Serial #")]
        public string InstalledPartSerialNumber2 { get; set; }

        [Display(Name = "3rd Installed Part #")]
        public string InstalledPartNumber3 { get; set; }
        [Display(Name = "3rd Installed Serial #")]
        public string InstalledPartSerialNumber3 { get; set; }

        [Display(Name = "4th Installed Part #")]
        public string InstalledPartNumber4 { get; set; }
        [Display(Name = "4th Installed Serial #")]
        public string InstalledPartSerialNumber4 { get; set; }

        // Dates and Inspectors
        [Required]
        [Display(Name = "Corrected By")]
        public string CorrectedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Corrected")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCorrected { get; set; }

        [Display(Name = "Inspected By")]
        public string InspectedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Inspected")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateInspected { get; set; }

        [Display(Name = "Filed By")]
        public string FiledBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Filed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFiled { get; set; }

        // navigation properties
        public DiscrepancyReportC DiscrepancyReportC { get; set; }
        public Employee Employee { get; set; }
    }
}
